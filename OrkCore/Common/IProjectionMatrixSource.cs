using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    /// <summary>
    /// Provides a projection matrix
    /// </summary>
    public interface IProjectionMatrixSource
    {
        /// <summary>
        /// Gets the projection matrix
        /// </summary>
        Matrix4 GetProjectionMatrix(Camera camera);
    }
}
