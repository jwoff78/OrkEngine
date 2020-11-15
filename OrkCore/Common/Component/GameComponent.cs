using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    public class GameComponent
    {
        private GameObject m_parent;

        public void Input(float delta) { }

        public void Update(float delta) { }

        public void Render(Shader shader, RenderingEngine renderingEngine) { }

        public GameObject Parent
        {
            set
            {
                m_parent = value;
            }
        }

        public Transform Transform
        {
            get;
           // {
           //     return m_parent.GetTransformation();
           // }
        }

        public void AddToEngine() { }
    }
}
