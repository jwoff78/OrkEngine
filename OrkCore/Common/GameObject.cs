using OpenTK;
using OpenTK.Graphics.ES30;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace OrkEngine
{
    
    public class GameObject : Transform
    {
        #region Private Fields
        private IDictionary<Type, Component> m_components;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the name of this GameObject.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets a list with all the models associated with the current GameObject.
        /// </summary>
        public List<Model> Models { get; private set; }

        /// <summary>
        /// Gets or sets the index for the current model.
        /// </summary>
        public int ModelIndex { get; set; }

        /// <summary>
        /// Gets or sets the action to execute on this object.
        /// </summary>
        public Func<Dictionary<string, object>, object> Action { get; set; }

        /// <summary>
        /// Gets a collection of parameters used in the current action.
        /// </summary>
        public Dictionary<string, object> ActionData { get; set; }
        
        /// <summary>
        /// Gets whether the current GameObject is visible or not.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Gets the active model for this GameObject.
        /// </summary>
        public Model ActiveModel => Models[ModelIndex];

        /// <summary>
        /// Gets the game instance that has this GameObject attached.
        /// </summary>
        public OrkGame Game { get; internal set; }
        #endregion

        #region Component System
        /// <summary>
        /// Adds a component to this game object.
        /// </summary>
        /// <typeparam name="T">Type of the component.</typeparam>
        public void AddComponent<T>() where T : Component, new()
        {
            if (!m_components.ContainsKey(typeof(T)))
            {
                var instanceOfT = Activator.CreateInstance<T>();
                instanceOfT.GameObject = this;
                m_components.Add(typeof(T), instanceOfT);
            }
        }

        /// <summary>
        /// Removes the first instance of a component previously attached to this GameObject.
        /// </summary>
        /// <typeparam name="T">Type of the component to remove.</typeparam>
        public void RemoveComponent<T>() where T : Component => m_components.Remove(typeof(T));

        /// <summary>
        /// Gets a component that was previously added to the object.
        /// </summary>
        /// <typeparam name="T">Type of the component.</typeparam>
        /// <returns>Component (if there is any matching the type parameter, otherwise default(T)).</returns>
        public T GetComponent<T>() where T : Component =>
            m_components.TryGetValue(typeof(T), out var component) ? (T)component : default;
        #endregion

        #region GameObject Events
        /// <summary>
        /// Gets called when the GameObject is attached to the game instance.
        /// </summary>
        internal void OnStart()
        {
            foreach (var component in m_components.Values)
                component?.OnStart();

         //   foreach (var children in Children)
         //       children?.OnStart();
        }

        /// <summary>
        /// Gets called by the game loop for each game object.
        /// </summary>
        /// <param name="deltaTime">Time elapsed since the last frame.</param>
        internal void OnUpdate(double deltaTime)
        {
            foreach (var component in m_components.Values)
                component?.OnUpdate(deltaTime);

           // foreach (var children in Children)
           //     children?.OnUpdate(deltaTime);
        }

        /// <summary>
        /// Gets called after detaching the game object from the game instance.
        /// </summary>
        internal void OnDestroy()
        {
         //   foreach (var children in Children)
          //      children?.OnDestroy();

            foreach (var component in m_components.Values)
                component?.OnDestroy();
        }
        #endregion

        #region CallAction
        /*
        public object CallAction()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>(ActionData);

            dict.Add("POSITION", Position + Offset.Position + RotateAroundParent());
            dict.Add("ROTATION", Rotation); //+ offset.rot);
            dict.Add("SCALE", Scale * Offset.Scale);

            dict.Add("POS_UP", Up);
            dict.Add("POS_FORWARD", Forward);

            return Action(dict);
        }

        public object CallAction(string extraval, object value)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>(ActionData);

            dictionary.Add(extraval, value);

            dictionary.Add("POSITION", Position + Offset.Position + RotateAroundParent());
            dictionary.Add("ROTATION", Rotation); //+ offset.rot);
            dictionary.Add("SCALE", Scale * Offset.Scale);

            dictionary.Add("POS_UP", Up);
            dictionary.Add("POS_FORWARD", LocalForward);

            return Action(dictionary);
        }*/
        #endregion

        #region Physical versions of non-physical objects (e.g.: cameras or lights)
        public static GameObject Camera(float aspectRatio)
        {
            GameObject camera = new GameObject("camera")
            {
                Action = (data) =>
                {
                    if (data.ContainsKey("viewMatrix"))
                        return Matrix4.LookAt((Vector3)data["POSITION"],
                                              (Vector3)data["POSITION"] + (Vector3)data["POS_FORWARD"],
                                              (Vector3)data["POS_UP"]);

                    if (data.ContainsKey("projectionMatrix"))
                        return Matrix4.CreatePerspectiveFieldOfView((float)data["FOV"], (float)data["ASPECT"], .1f, 100);

                    return null;
                }
            };

            camera.ActionData.Add("FOV", MathHelper.PiOver2);
            camera.ActionData.Add("ASPECT", aspectRatio);

            return camera;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of the GameObject class with all the default values.
        /// </summary>
        public GameObject() : this(null, null) {  }

        public GameObject(string name) 
            : this(name, null) { }

        public GameObject(string name, Vector3 position) 
            : this(name, position, Vector3.Zero, Vector3.One, null) { }

        public GameObject(string name, Vector3 position, Vector3 rotation) 
            : this(name, position, rotation, Vector3.One, null) { }

        public GameObject(string name, Vector3 position, Vector3 rotation, Vector3 scale)
            : this(name, position, rotation, scale, null) { }

        /// <summary>
        /// Creates a new instance of the GameObject class with a default model.
        /// </summary>
        /// <param name="name">Name of this GameObject.</param>
        /// <param name="model">Default model used in this GameObject.</param>
        public GameObject(string name, Model model) 
            : this(name, Vector3.Zero, Vector3.Zero, Vector3.One, model) { }

        /// <summary>
        /// Creates a new instance of the GameObject class.
        /// </summary>
        /// <param name="name">Name of this GameObject.</param>
        /// <param name="position">Initial position of this object.</param>
        /// <param name="rotation">Initial rotation of this object.</param>
        /// <param name="scale">Initial scale of this object.</param>
        /// <param name="model">Default/first model used in this model.</param>
        public GameObject(string name, Vector3 position, Vector3 rotation, Vector3 scale, Model model) : base()
        {
            if (string.IsNullOrEmpty(name))
                name = "GameObject";

            if (name.Contains(':'))
                throw new ArgumentException($"{nameof(name)} contains invalid characters.");

            m_components = new Dictionary<Type, Component>();
            Models = new List<Model>();
            ActionData = new Dictionary<string, object>();
            ModelIndex = 0;

            Name = name;

           // Offset.Position = position;
          //  Offset.Rotation = rotation;
          //  Offset.Scale = scale;

            if (model is object)
                Models.Add(model);
        }
        #endregion
    }
}
