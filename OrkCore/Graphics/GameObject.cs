using OpenTK;
using OpenTK.Graphics.ES30;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using BEPUphysics.Entities;
using BEPUphysics.Entities.Prefabs;
using numVec3 = System.Numerics.Vector3;
using BEPUphysics.BroadPhaseEntries;

namespace OrkEngine.Graphics
{
    public class GameObject
    {
        #region new shit
        private static long s_latestAssignedID = 0;
        private readonly MultiValueDictionary<Type, OrkComponent> _components = new MultiValueDictionary<Type, OrkComponent>();

        private SystemRegistry _registry;
        private bool _enabled = true;
        private bool _enabledInHierarchy = true;

        public string Name { get; set; }

        public ulong ID { get; }

        public Transform Transform { get; }

        public bool Enabled
        {
            get { return _enabled; }
            set { if (value != _enabled) { SetEnabled(value); } }
        }

        public bool EnabledInHierarchy => _enabledInHierarchy;

        internal static event Action<GameObject> InternalConstructed;
        internal static event Action<GameObject> InternalDestroyRequested;
        internal static event Action<GameObject> InternalDestroyCommitted;

        public event Action<GameObject> Destroyed;

        public GameObject() : this(Guid.NewGuid().ToString())
        { }

        public GameObject(string name)
        {
            Transform t = new Transform();
            t.ParentChanged += OnTransformParentChanged;
            AddComponent(t);
            Transform = t;
            Name = name;
            InternalConstructed?.Invoke(this);
            ID = GetNextID();
        }

        private ulong GetNextID()
        {
            ulong newID = unchecked((ulong)Interlocked.Increment(ref s_latestAssignedID));
            Debug.Assert(newID != 0); // Overflow
            return newID;
        }

        public void AddComponent(OrkComponent component)
        {
            _components.Add(component.GetType(), component);
            component.AttachToGameObject(this, _registry);
        }

        public void AddComponent<T>(T component) where T : OrkComponent
        {
            _components.Add(typeof(T), component);
            component.AttachToGameObject(this, _registry);
        }

        public void RemoveAll<T>() where T : OrkComponent
        {
            IReadOnlyCollection<OrkComponent> components;
            if (_components.TryGetValue(typeof(T), out components))
            {
                foreach (OrkComponent c in components)
                {
                    c.InternalRemoved(_registry);
                }

                _components.Remove(typeof(T));
            }
        }

        public void RemoveComponent<T>(T component) where T : OrkComponent
        {
            component.InternalRemoved(_registry);
            _components.Remove(typeof(T), component);
        }

        public void RemoveComponent(OrkComponent component)
        {
            _components.Remove(component.GetType(), component);
            component.InternalRemoved(_registry);
        }

        public T GetComponent<T>() where T : OrkComponent
        {
            return (T)GetComponent(typeof(T));
        }

        public OrkComponent GetComponent(Type type)
        {
            IReadOnlyCollection<OrkComponent> components;
            if (!_components.TryGetValue(type, out components))
            {
                foreach (var kvp in _components)
                {
                    if (type.GetTypeInfo().IsAssignableFrom(kvp.Key))
                    {
                        if (kvp.Value.Any())
                        {
                            return kvp.Value.First();
                        }
                    }
                }
            }
            else
            {
                return components.First();
            }

            return null;
        }

        public IEnumerable<T> GetComponentsByInterface<T>()
        {
            foreach (var kvp in _components)
            {
                foreach (var component in kvp.Value)
                {
                    if (component is T)
                    {
                        yield return (T)(object)component;
                    }
                }
            }
        }

        public T GetComponentByInterface<T>()
        {
            return GetComponentsByInterface<T>().FirstOrDefault();
        }

        internal void SetRegistry(SystemRegistry systemRegistry)
        {
            _registry = systemRegistry;
        }

        public IEnumerable<T> GetComponents<T>() where T : OrkComponent
        {
            IReadOnlyCollection<OrkComponent> components;
            if (!_components.TryGetValue(typeof(T), out components))
            {
                foreach (var kvp in _components.ToArray())
                {
                    if (typeof(T).GetTypeInfo().IsAssignableFrom(kvp.Key))
                    {
                        foreach (var comp in kvp.Value.ToArray())
                        {
                            yield return (T)comp;
                        }
                    }
                }
            }
            else
            {
                foreach (var comp in components)
                {
                    yield return (T)comp;
                }
            }
        }

        public T GetComponentInParent<T>() where T : OrkComponent
        {
            T component;
            GameObject parent = this;
            while ((parent = parent.Transform.Parent?.GameObject) != null)
            {
                component = parent.GetComponent<T>();
                if (component != null)
                {
                    return component;
                }
            }

            return null;
        }

        public T GetComponentInParentOrSelf<T>() where T : OrkComponent
        {
            T component;
            component = GetComponentInParent<T>();
            if (component == null)
            {
                component = GetComponent<T>();
            }

            return component;
        }

        public T GetComponentInChildren<T>() where T : OrkComponent
        {
            return (T)GetComponentInChildren(typeof(T));
        }

        public OrkComponent GetComponentInChildren(Type componentType)
        {
            foreach (var child in Transform.Children)
            {
                OrkComponent ret = child.GameObject.GetComponent(componentType) ?? child.GameObject.GetComponentInChildren(componentType);
                if (ret != null)
                {
                    return ret;
                }
            }

            return null;
        }

        public void Destroy()
        {
            InternalDestroyRequested.Invoke(this);
        }

        internal void CommitDestroy()
        {
            foreach (var child in Transform.Children.ToArray())
            {
                child.GameObject.CommitDestroy();
            }

            foreach (var componentList in _components)
            {
                foreach (var component in componentList.Value)
                {
                    component.InternalRemoved(_registry);
                }
            }

            _components.Clear();

            Destroyed?.Invoke(this);
            InternalDestroyCommitted.Invoke(this);
        }

        private void SetEnabled(bool state)
        {
            _enabled = state;

            foreach (var child in Transform.Children)
            {
                child.GameObject.HierarchyEnabledStateChanged();
            }

            HierarchyEnabledStateChanged();
        }

        private void OnTransformParentChanged(Transform t, Transform oldParent, Transform newParent)
        {
            HierarchyEnabledStateChanged();
        }

        private void HierarchyEnabledStateChanged()
        {
            bool newState = _enabled && IsParentEnabled();
            if (_enabledInHierarchy != newState)
            {
                CoreHierarchyEnabledStateChanged(newState);
            }
        }

        private void CoreHierarchyEnabledStateChanged(bool newState)
        {
            Debug.Assert(newState != _enabledInHierarchy);
            _enabledInHierarchy = newState;
            foreach (var component in GetComponents<OrkComponent>())
            {
                component.HierarchyEnabledStateChanged();
            }
        }

        private bool IsParentEnabled()
        {
            return Transform.Parent == null || Transform.Parent.GameObject.Enabled;
        }

        public override string ToString()
        {
            return $"{Name}, {_components.Values.Sum(irc => irc.Count)} components";
        }


        #endregion



        //old shit
        public string name = "OBJECT";
        private Vector3 pos = new Vector3(0,0,0);
        public Vector3 rot = new Vector3(0,0,0);
        private Vector3 scl    = new Vector3(1,1,1);
        public TransformOffset offset = new TransformOffset();

        public Entity entity;
        public StaticMesh staticMesh;

        private bool eos = false;

        public bool EntityOrStatic
        {
            get
            {
                return eos;
            }
            set
            {
                eos = value;

                if (value)
                {
                    try
                    {
                        //staticMesh = Model.ConvertToStaticMesh(ActiveModel);
                    }
                    catch{}
                }
            }
        }

        public List<Model> models = new List<Model>();
        public int modelIndex = 0;

        public List<GameObject> Children = new List<GameObject>();

        public Func<Dictionary<string, object>, object> action;
        public Dictionary<string, object> actionData = new Dictionary<string, object>();

        public Vector3 position
        {
            get { return pos; }
            set
            {
                pos = value;
                entity.Position = new numVec3(value.X, value.Y, value.Z);
            }
        }
        public Vector3 rotation
        {
            get { return rot; }
            set
            {
                rot = value;
                Quaternion q = new Quaternion(value);
                entity.Orientation = new System.Numerics.Quaternion(q.X, q.Y, q.Z,q.W);
            }
        }
        public Vector3 scale
        {
            get { return scl; }
            set
            {
                scl = value;
                foreach (GameObject g in Children)
                {
                    g.offset.scl = scl;
                    g.offset.pos *= scl;
                }
            }
        }
        public Vector3 forward
        {
            get
            {
                return (convertToActuallGoodQuaternion(entity.Orientation)).Normalized() * -Vector3.UnitZ;
            }
        }
        public Vector3 up
        {
            get
            {
                return (convertToActuallGoodQuaternion(entity.Orientation)).Normalized() * Vector3.UnitY;
            }
        }
        public Vector3 right
        {
            get
            {
                return (convertToActuallGoodQuaternion(entity.Orientation)).Normalized() * Vector3.UnitX;
            }
        }

        public Vector3 localForward
        {
            get
            {
                return (Quaternion.FromEulerAngles(rot)).Normalized() * -Vector3.UnitZ;
            }
        }
        public bool visible = true;

        public void GameeObject() { offset.scl = new Vector3(1); entity = new Box(numVec3.Zero ,scale.X, scale.Y, scale.Z); }
        public void GameeObject(string _name)
        {
            name = _name;
            offset.scl = new Vector3(1);
            offset.pos = new Vector3(0);
            offset.rot = new Vector3(0);
            entity = new Box(numVec3.Zero, scale.X, scale.Y, scale.Z);
        }
        public GameObject(string _name, Model model)
        {
            name = _name;
            models.Add(model);
            offset.scl = new Vector3(1);
            offset.pos = new Vector3(0);
            offset.rot = new Vector3(0);
            entity = new Box(numVec3.Zero, scale.X, scale.Y, scale.Z);
        }

        public Model ActiveModel
        {
            get
            {
                return models[modelIndex];
            }
        }

        public struct TransformOffset
        {
            public Vector3 pos;
            public Vector3 rot;
            public Vector3 scl;
        }

        public Vector3 rotateAroundParent()
        {
            float distance = Vector3.Distance(position, offset.pos);
            Vector3 rotationInRads = new Vector3((float)Math.PI / 180 * offset.rot.X, (float)Math.PI / 180 * offset.rot.Y, (float)Math.PI / 180 * offset.rot.Z);
            Vector3 v3 = new Vector3(
                (float)(distance * Math.Cos(rotationInRads.X) * Math.Cos(rotationInRads.Y)),
                (float)(distance * Math.Cos(rotationInRads.X) * Math.Sin(rotationInRads.Y)),
                (float)(distance * Math.Sin(rotationInRads.Y))
                );
            return v3;
        }

        public object callAction()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>(actionData);

            dict.Add("POSITION", position + offset.pos + rotateAroundParent());
            dict.Add("ROTATION", rotation); //+ offset.rot);
            dict.Add("SCALE", scale * offset.scl);

            dict.Add("POS_UP", up);
            dict.Add("POS_FORWARD", forward);

            return action(dict);
        }
        public object callAction(string extraval, object value)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>(actionData);

            dict.Add(extraval, value);

            dict.Add("POSITION", new Vector3(entity.Position.X, entity.Position.Y, entity.Position.Z));
            dict.Add("ROTATION", entity.Orientation); //+ offset.rot);
            dict.Add("SCALE", scale);

            dict.Add("POS_UP", up);
            dict.Add("POS_FORWARD", forward);

            return action(dict);
        }

        public static Quaternion convertToActuallGoodQuaternion(System.Numerics.Quaternion qek)
        {
            Quaternion q = new Quaternion();
            q.X = qek.X;
            q.Y = qek.Y;
            q.Z = qek.Z;
            q.W = qek.W;
            return q;
        }

        //Physical versions of non physical objects (like cameras or lights)

        public static GameObject camera(float aspectRatio)
        {
            GameObject cam = new GameObject("camera");

            cam.action = camAction;
            cam.actionData.Add("FOV", OpenTK.MathHelper.PiOver2);
            cam.actionData.Add("ASPECT", aspectRatio);

            cam.entity = new Box(numVec3.Zero, 2,2,2,1);

            return cam;
        }

        static object camAction(Dictionary<string, object> data)
        {
            if (data.ContainsKey("viewMatrix"))
            {
                return Matrix4.LookAt((Vector3)data["POSITION"], (Vector3)data["POSITION"] + (Vector3)data["POS_FORWARD"], (Vector3)data["POS_UP"]);
            }
            else if (data.ContainsKey("projectionMatrix"))
            {
                return Matrix4.CreatePerspectiveFieldOfView((float)data["FOV"], (float)data["ASPECT"], 0.1f, 100);
            }

            return null;
        }
    }
}
