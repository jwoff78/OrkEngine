using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    public struct Ray
    {
        /// <summary>
		/// Gets or sets the origin.
		/// </summary>
        public Vector3 Origin;

        /// <summary>
		/// Gets or sets the direction.
		/// </summary>
        public Vector3 Direction;

        /// <summary>
		/// Creates a new ray.
		/// </summary>
		/// <param name="origin">Origin of the ray.</param>
		/// <param name="direction">Direction of the ray.</param>
		/// <remarks>Direction gets normalized.</remarks>
        public Ray(Vector3 origin, Vector3 direction)
        {
            Origin = origin;
            Direction = direction;
        }
    }
}
