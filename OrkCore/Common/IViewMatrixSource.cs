﻿using OpenTK;

namespace OrkEngine
{
    /// <summary>
	/// Provides a view matrix.
	/// </summary>
    public interface IViewMatrixSource
    {
        /// <summary>
        /// Gets the view matrix
        /// </summary>
        Matrix4 GetViewMatrix(Camera camera);
    }
}
