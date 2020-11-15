using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    public class Attenuation : Vector3f
    {
        public Attenuation(float constant, float linear, float exponent)
            : base(constant, linear, exponent) { }

        public float Constant
        {
            get
            {
                return X;
            }
        }

        public float Linear
        {
            get
            {
                return Y;
            }
        }

        public float Exponent
        {
            get
            {
                return Z;
            }
        }
    }
}
