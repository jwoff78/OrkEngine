using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine.Graphics
{
    public class GameObject
    {
        public string name = "OBJECT";
        private Vector3 pos = new Vector3(0,0,0);
        private Vector3 rot = new Vector3(0,0,0);
        private Vector3 scl    = new Vector3(1,1,1);
        public TransformOffset offset = new TransformOffset();

        public List<Model> models = new List<Model>();
        public int modelIndex = 0;

        public List<GameObject> Children = new List<GameObject>();

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
                return rot.Normalized() * Vector3.UnitX;
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
    }
}
