using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    public class DirectionalLight : BaseLight
    {
        public DirectionalLight(Vector3f color, float intensity) : base (color, intensity)
        {
            //Set shader to a new copy of itself and its the forward directional
        }

        public Vector3f Direction
        {
            get; private set;
            //Get Transform Get Transform Rot Get Forward
        }
    }
}
