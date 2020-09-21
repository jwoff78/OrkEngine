using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine.Common
{
    /// <summary>
    /// 2D box with integer sizes.
    /// </summary>
    public struct Box2i
    {
        private int m_top;
        private int m_bottom;
        private int m_left;
        private int m_right;

        /// <summary>
		/// Creates a new Box2i
		/// </summary>
        public Box2i(int top, int bottom, int left, int right)
        {
            m_top = top;
            m_bottom = bottom;
            m_left = left;
            m_right = right;
        }

        /// <summary>
		/// Gets or sets distance to top border.
		/// </summary>
        public int Top
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
        public int Bottom
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
        public int Left
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
        public int Right
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
        public int Width
        {
            get
            {
                return m_right - m_left;
            }
        }

        /// <summary>
        /// Gets The Height 
        /// </summary>
        public int Height
        {
            get
            {
                return m_bottom - m_top;
            }
        }


    }
}
