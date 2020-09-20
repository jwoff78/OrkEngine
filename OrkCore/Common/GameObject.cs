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
        public string Name = "OBJECT";

        public List<Model> Models = new List<Model>();
        public int ModelIndex = 0;


        public Func<Dictionary<string, object>, object> Action;
        public Dictionary<string, object> ActionData = new Dictionary<string, object>();

      
        public bool visible = true;

        public GameObject() { Offset.Scale = new Vector3(1); }
        public GameObject(string _name)
        {
            Name = _name;
            Offset.Scale = new Vector3(1);
            Offset.Position = new Vector3(0);
            Offset.Rotation = new Vector3(0);
        }
        public GameObject(string _name, Model model)
        {
            Name = _name;
            Models.Add(model);
            Offset.Scale = new Vector3(1);
            Offset.Position = new Vector3(0);
            Offset.Rotation = new Vector3(0);
        }

        public Model ActiveModel
        {
            get
            {
                return Models[ModelIndex];
            }
        }

      

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
        }

        //Physical versions of non physical objects (like cameras or lights)

        public static GameObject Camera(float aspectRatio)
        {
            GameObject camera = new GameObject("camera");

            camera.Action = CameraAction;
            camera.ActionData.Add("FOV", MathHelper.PiOver2);
            camera.ActionData.Add("ASPECT", aspectRatio);

            return camera;
        }

        static object CameraAction(Dictionary<string, object> data)
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
