using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine.Common
{
    /// <summary>
    /// 2D box with long sizes.
    /// </summary>
    public struct Box2l
    {
        private long m_top;
        private long m_bottom;
        private long m_left;
        private long m_right;

        /// <summary>
		/// Creates a new Box2l
		/// </summary>
        public Box2l(long top, long bottom, long left, long right)
        {
            m_top = top;
            m_bottom = bottom;
            m_left = left;
            m_right = right;
        }

        /// <summary>
		/// Gets or sets distance to top border.
		/// </summary>
        public long Top
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
        public long Bottom
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
        public long Left
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
        public long Right
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
        public long Width
        {
            get
            {
                return m_right - m_left;
            }
        }

        /// <summary>
        /// Gets The Height 
        /// </summary>
        public long Height
        {
            get
            {
                return m_bottom - m_top;
            }
        }
    }
}
