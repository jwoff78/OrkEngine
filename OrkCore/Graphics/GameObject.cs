﻿using OpenTK;
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
        public string Name = "OBJECT";
        public TransformOffset Offset = new TransformOffset();
        private Vector3 m_pos = new Vector3(0,0,0);
        private Vector3 m_rotation = new Vector3(0,0,0);
        private Vector3 m_scale    = new Vector3(1,1,1);

        public List<Model> Models = new List<Model>();
        public int ModelIndex = 0;

        public List<GameObject> Children = new List<GameObject>();

        public Func<Dictionary<string, object>, object> Action;
        public Dictionary<string, object> ActionData = new Dictionary<string, object>();

        public Vector3 Position
        {
            get { return m_pos; }
            set
            {
                m_pos = value;
                foreach (GameObject g in Children)
                {
                    g.Offset.Position = m_pos;
                }
            }
        }
        public Vector3 Rotation
        {
            get { return m_rotation; }
            set
            {
                m_rotation = value;
                foreach (GameObject g in Children)
                {
                    g.Offset.Rotation = value;
                }
            }
        }
        public Vector3 Scale
        {
            get { return m_scale; }
            set
            {
                m_scale = value;
                foreach (GameObject g in Children)
                {
                    g.Offset.Scale = m_scale;
                    g.Offset.Position *= m_scale;
                }
            }
        }
        public Vector3 Forward
        {
            get
            {
                return (Quaternion.FromEulerAngles(m_rotation) + Quaternion.FromEulerAngles(Offset.Rotation)).Normalized() * -Vector3.UnitZ;
            }
        }
        public Vector3 Up
        {
            get
            {
                return (Quaternion.FromEulerAngles(m_rotation) + Quaternion.FromEulerAngles(Offset.Rotation)).Normalized() * Vector3.UnitY;
            }
        }
        public Vector3 Right
        {
            get
            {
                return (Quaternion.FromEulerAngles(m_rotation) + Quaternion.FromEulerAngles(Offset.Rotation)).Normalized() * Vector3.UnitX;
            }
        }

        public Vector3 LocalForward
        {
            get
            {
                return (Quaternion.FromEulerAngles(m_rotation)).Normalized() * -Vector3.UnitZ;
            }
        }
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

        public struct TransformOffset
        {
            public Vector3 Position;
            public Vector3 Rotation;
            public Vector3 Scale;
        }

        public Vector3 RotateAroundParent()
        {
            float distance = Vector3.Distance(Position, Offset.Position);
            Vector3 rotationInRads = new Vector3((float)Math.PI / 180 * Offset.Rotation.X, (float)Math.PI / 180 * Offset.Rotation.Y, (float)Math.PI / 180 * Offset.Rotation.Z);
            Vector3 v3 = new Vector3(
                (float)(distance * Math.Cos(rotationInRads.X) * Math.Cos(rotationInRads.Y)),
                (float)(distance * Math.Cos(rotationInRads.X) * Math.Sin(rotationInRads.Y)),
                (float)(distance * Math.Sin(rotationInRads.Y))
                );
            return v3;
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
