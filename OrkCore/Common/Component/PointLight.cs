using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    public class PointLight : BaseLight
    {
        private const int COLOR_DEPTH = 256;

        private Attenuation m_attenuation;

        private float m_range;

        public PointLight(Vector3f color, float intensity, Attenuation attenuation)
                         : base(color, intensity)
        {
            m_attenuation = attenuation;

            //a
            float exponent = attenuation.Exponent;
            //b
            float linear = attenuation.Linear;
            //c
            float constant = attenuation.Constant - COLOR_DEPTH * Intensity * Color.Max;

            m_range = (float)( ( -linear + Math.Sqrt(linear * linear - 4 * exponent * constant) ) / ( 2 * exponent ) );

            //set shader new copy of itself forward point
        }

        public float Range
        {
            get
            {
                return m_range;
            }
            set
            {
                m_range = value;
            }
        }

        public Attenuation Attenuation
        {
            get
            {
                return m_attenuation;
            }
        }
    }
}
