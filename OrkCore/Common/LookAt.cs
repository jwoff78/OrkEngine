using System;
using OpenTK;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    /// <summary>
    /// LookAt View Matrix
    /// </summary>
    public class LookAt : IViewMatrixSource
    {
        public LookAt() :this(Vector3.Zero, Vector3.UnitZ) { }

        public LookAt(Vector3 position, Vector3 target)
        {
            Position = position;
            Target = target;
        }

        /// <summary>
        /// Gets or sets the camera position;
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// Gets or sets the camera target;
        /// </summary>

        public Vector3 Target { get; set; }

        /// <summary>
        /// Gets the view matrix
        /// </summary>
        public Matrix4 GetViewMatrix(Camera camera)
        {
            return Matrix4.LookAt(Position, Target, Vector3.UnitY);
        }
    }
}
