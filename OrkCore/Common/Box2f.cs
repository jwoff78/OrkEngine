using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine.Common
{
    /// <summary>
    /// 2D box with float sizes.
    /// </summary>
    public struct Box2f
    {
        private float m_top;
        private float m_bottom;
        private float m_left;
        private float m_right;

        /// <summary>
		/// Creates a new Box2f
		/// </summary>
        public Box2f(float top, float bottom, float left, float right)
        {
            m_top = top;
            m_bottom = bottom;
            m_left = left;
            m_right = right;
        }

        /// <summary>
		/// Gets or sets distance to top border.
		/// </summary>
        public float Top
        {
            get => m_top;

            set// => m_top = value;
            {
                m_top = value;
            }
        }

        /// <summary>
		/// Gets or sets distance to bottom border.
		/// </summary>
        public float Bottom
        {
            get => m_bottom;

            set
            {
                m_bottom = value;
            }
        }

        /// <summary>
		/// Gets or sets distance to left border.
		/// </summary>
        public float Left
        {
            get => m_left;

            set
            {
                m_left = value;
            }
        }

        /// <summary>
		/// Gets or sets distance to right border.
		/// </summary>
        public float Right
        {
            get => m_right;

            set
            {
                m_right = value;
            }
        }

        /// <summary>
        /// Gets The Width 
        /// </summary>
        public float Width
        {
            get
            {
                return m_right - m_left;
            }
        }

        /// <summary>
        /// Gets The Height 
        /// </summary>
        public float Height
        {
            get
            {
                return m_bottom - m_top;
            }
        }

    }
}