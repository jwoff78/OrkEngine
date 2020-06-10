#region --- License ---
/*
Copyright (c) 2006 - 2008 The Open Toolkit library.

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */
/*
The conversion functions are derived from OpenEXR's implementation and are
governed by the following license:

Copyright (c) 2002, Industrial Light & Magic, a division of Lucas
Digital Ltd. LLC

All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are
met:
*       Redistributions of source code must retain the above copyright
notice, this list of conditions and the following disclaimer.
*       Redistributions in binary form must reproduce the above
copyright notice, this list of conditions and the following disclaimer
in the documentation and/or other materials provided with the
distribution.
*       Neither the name of Industrial Light & Magic nor the names of
its contributors may be used to endorse or promote products derived
from this software without specific prior written permission. 

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
#endregion --- License ---


using System;
using System.Collections.Generic;
using System.Text;

namespace OrkEngine.Mathematics
{
    /// <summary>
    /// Represents a cubic bezier curve with two anchor and two control points.
    /// </summary>
    [Serializable]
    public struct BezierCurveCubic
    {
        #region Fields

        /// <summary>
        /// Start anchor point.
        /// </summary>
        public Vector2 StartAnchor;

        /// <summary>
        /// End anchor point.
        /// </summary>
        public Vector2 EndAnchor;

        /// <summary>
        /// First control point, controls the direction of the curve start.
        /// </summary>
        public Vector2 FirstControlPoint;

        /// <summary>
        /// Second control point, controls the direction of the curve end.
        /// </summary>
        public Vector2 SecondControlPoint;

        /// <summary>
        /// Gets or sets the parallel value.
        /// </summary>
        /// <remarks>This value defines whether the curve should be calculated as a
        /// parallel curve to the original bezier curve. A value of 0.0f represents
        /// the original curve, 5.0f i.e. stands for a curve that has always a distance
        /// of 5.f to the orignal curve at any point.</remarks>
        public float Parallel;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new <see cref="BezierCurveCubic"/>.
        /// </summary>
        /// <param name="startAnchor">The start anchor point.</param>
        /// <param name="endAnchor">The end anchor point.</param>
        /// <param name="firstControlPoint">The first control point.</param>
        /// <param name="secondControlPoint">The second control point.</param>
        public BezierCurveCubic(Vector2 startAnchor, Vector2 endAnchor, Vector2 firstControlPoint, Vector2 secondControlPoint)
        {
            this.StartAnchor = startAnchor;
            this.EndAnchor = endAnchor;
            this.FirstControlPoint = firstControlPoint;
            this.SecondControlPoint = secondControlPoint;
            this.Parallel = 0.0f;
        }

        /// <summary>
        /// Constructs a new <see cref="BezierCurveCubic"/>.
        /// </summary>
        /// <param name="parallel">The parallel value.</param>
        /// <param name="startAnchor">The start anchor point.</param>
        /// <param name="endAnchor">The end anchor point.</param>
        /// <param name="firstControlPoint">The first control point.</param>
        /// <param name="secondControlPoint">The second control point.</param>
        public BezierCurveCubic(float parallel, Vector2 startAnchor, Vector2 endAnchor, Vector2 firstControlPoint, Vector2 secondControlPoint)
        {
            this.Parallel = parallel;
            this.StartAnchor = startAnchor;
            this.EndAnchor = endAnchor;
            this.FirstControlPoint = firstControlPoint;
            this.SecondControlPoint = secondControlPoint;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Calculates the point with the specified t.
        /// </summary>
        /// <param name="t">The t value, between 0.0f and 1.0f.</param>
        /// <returns>Resulting point.</returns>
        public Vector2 CalculatePoint(float t)
        {
            Vector2 r = new Vector2();
            float c = 1.0f - t;

            r.X = (StartAnchor.X * c * c * c) + (FirstControlPoint.X * 3 * t * c * c) + (SecondControlPoint.X * 3 * t * t * c)
                + EndAnchor.X * t * t * t;
            r.Y = (StartAnchor.Y * c * c * c) + (FirstControlPoint.Y * 3 * t * c * c) + (SecondControlPoint.Y * 3 * t * t * c)
                + EndAnchor.Y * t * t * t;

            if (Parallel == 0.0f)
                return r;

            Vector2 perpendicular = new Vector2();

            if (t == 0.0f)
                perpendicular = FirstControlPoint - StartAnchor;
            else
                perpendicular = r - CalculatePointOfDerivative(t);

            return r + Vector2.Normalize(perpendicular).PerpendicularRight * Parallel;
        }

        /// <summary>
        /// Calculates the point with the specified t of the derivative of this function.
        /// </summary>
        /// <param name="t">The t, value between 0.0f and 1.0f.</param>
        /// <returns>Resulting point.</returns>
        private Vector2 CalculatePointOfDerivative(float t)
        {
            Vector2 r = new Vector2();
            float c = 1.0f - t;

            r.X = (c * c * StartAnchor.X) + (2 * t * c * FirstControlPoint.X) + (t * t * SecondControlPoint.X);
            r.Y = (c * c * StartAnchor.Y) + (2 * t * c * FirstControlPoint.Y) + (t * t * SecondControlPoint.Y);

            return r;
        }

        /// <summary>
        /// Calculates the length of this bezier curve.
        /// </summary>
        /// <param name="precision">The precision.</param>
        /// <returns>Length of the curve.</returns>
        /// <remarks>The precision gets better when the <paramref name="precision"/>
        /// value gets smaller.</remarks>
        public float CalculateLength(float precision)
        {
            float length = 0.0f;
            Vector2 old = CalculatePoint(0.0f);

            for (float i = precision; i < (1.0f + precision); i += precision)
            {
                Vector2 n = CalculatePoint(i);
                length += (n - old).Length;
                old = n;
            }

            return length;
        }

        #endregion
    }
}
