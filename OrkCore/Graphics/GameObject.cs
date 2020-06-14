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
        public Vector3 position = new Vector3(0,0,0);
        public Vector3 rotation = new Vector3(0,0,0);
        public Vector3 scale    = new Vector3(1,1,1);

        public List<Model> models = new List<Model>();
        public int modelIndex = 0;

        public bool visible = true;

        public GameObject() { }
        public GameObject(string _name)
        {
            name = _name;
        }
        public GameObject(string _name, Model model)
        {
            name = _name;
            models.Add(model);
        }

        public Model ActiveModel
        {
            get
            {
                return models[modelIndex];
            }
        }
    }
}
