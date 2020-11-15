using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine.Common.ResourceManagement
{
    public class MappedValues
    {
        private Dictionary<string, Vector3f> m_vector3f;
        private Dictionary<string, float>    m_float;

        public MappedValues()
        {
            m_vector3f = new Dictionary<string, Vector3f>();
            m_float = new Dictionary<string, float>();
        }

        public void AddVector3f(string name, Vector3f vector3f) 
        { 
            m_vector3f.Add(name, vector3f);
        }

        public void AddFloat(string name, float floatValue) 
        { 
            m_float.Add(name, floatValue); 
        }

        public Vector3f GetVector3f(string name)
        {
            Vector3f result = m_vector3f[name];
            if (result != null)
                return result;

            return new Vector3f(0, 0, 0);
        }

        public float GetFloat(String name)
        {
            float result = m_float[name];

            return result;
        }
    }
}
