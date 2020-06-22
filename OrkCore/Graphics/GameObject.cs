using OpenTK;
using OpenTK.Graphics.ES30;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace OrkEngine.Graphics
{
    public class GameObject
    {
        public string name = "OBJECT";
        private Vector3 pos = new Vector3(0,0,0);
        public Vector3 rot = new Vector3(0,0,0);
        private Vector3 scl    = new Vector3(1,1,1);
        public TransformOffset offset = new TransformOffset();

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
                foreach (GameObject g in Children)
                {
                    g.offset.pos = pos;
                }
            }
        }
        public Vector3 rotation
        {
            get { return rot; }
            set
            {
                rot = value;
                foreach (GameObject g in Children)
                {
                    g.offset.rot = value;
                }
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
                return (Quaternion.FromEulerAngles(rot) + Quaternion.FromEulerAngles(offset.rot)).Normalized() * -Vector3.UnitZ;
            }
        }
        public Vector3 up
        {
            get
            {
                return (Quaternion.FromEulerAngles(rot) + Quaternion.FromEulerAngles(offset.rot)).Normalized() * Vector3.UnitY;
            }
        }
        public Vector3 right
        {
            get
            {
                return (Quaternion.FromEulerAngles(rot) + Quaternion.FromEulerAngles(offset.rot)).Normalized() * Vector3.UnitX;
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

        public GameObject() { offset.scl = new Vector3(1); }
        public GameObject(string _name)
        {
            name = _name;
            offset.scl = new Vector3(1);
            offset.pos = new Vector3(0);
            offset.rot = new Vector3(0);
        }
        public GameObject(string _name, Model model)
        {
            name = _name;
            models.Add(model);
            offset.scl = new Vector3(1);
            offset.pos = new Vector3(0);
            offset.rot = new Vector3(0);
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

            dict.Add("POSITION", position + offset.pos + rotateAroundParent());
            dict.Add("ROTATION", rotation); //+ offset.rot);
            dict.Add("SCALE", scale * offset.scl);

            dict.Add("POS_UP", up);
            dict.Add("POS_FORWARD", localForward);

            return action(dict);
        }

        //Physical versions of non physical objects (like cameras or lights)

        public static GameObject camera(float aspectRatio)
        {
            GameObject cam = new GameObject("camera");

            cam.action = camAction;
            cam.actionData.Add("FOV", MathHelper.PiOver2);
            cam.actionData.Add("ASPECT", aspectRatio);

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
