using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    public class BaseLight : Component
    {
        private Vector3f m_color;
        private float m_intensity;
        private Shader m_shader;

        public BaseLight(Vector3f color, float intensity)
        {
            m_color = color;
            m_intensity = intensity;
        }

        //Engine core param
        public void AddToEngine()
        {
            //Rendering Engine AddLight(this);
        }

        public Shader Shader
        {
            get
            {
               return m_shader;
            }

            set
            {
                m_shader = value;
            }
        }

        public Vector3f Color
        {
            get
            {
                return m_color;
            }

            set
            {
                m_color = value;
            }
        }

        public float Intensity
        {
            get
            {
                return m_intensity;
            }
            set
            {
                m_intensity = value;
            }
        }
    }
}
