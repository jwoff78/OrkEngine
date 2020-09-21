using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine.Common
{
    /// <summary>
    /// 2D box with double sizes.
    /// </summary>
    public struct Box2d
    {
        private double m_top;
        private double m_bottom;
        private double m_left;
        private double m_right;

        /// <summary>
		/// Creates a new Box2d
		/// </summary>
        public Box2d(double top, double bottom, double left, double right)
        {
            m_top = top;
            m_bottom = bottom;
            m_left = left;
            m_right = right;
        }

        /// <summary>
		/// Gets or sets distance to top border.
		/// </summary>
        public double Top
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
        public double Bottom
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
        public double Left
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
        public double Right
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
        public double Width
        {
            get
            {
                return m_right - m_left;
            }
        }

        /// <summary>
        /// Gets The Height 
        /// </summary>
        public double Height
        {
            get
            {
                return m_bottom - m_top;
            }
        }

    }
}
