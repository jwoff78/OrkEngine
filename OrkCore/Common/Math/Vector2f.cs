using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    public class Vector2f : IEquatable<Vector2f>
    {
        private float m_x;
        private float m_y;

        public Vector2f(float x, float y)
        {
            m_x = x;
            m_y = y;
        }

		public float X
        {
			get
            {
				return m_x;
            }

			set
            {
				m_x = value;
            }
        }

		public float Y
		{
			get
			{
				return m_y;
			}

			set
			{
				m_y = value;
			}
		}

		public float Length
        {
            get
            {
                return (float)Math.Sqrt(m_x * m_x + m_y * m_y);
            }
        }

        public float Max
        {
            get
            {
                return Math.Max(m_x, m_y);
            }
        }

		public float Dot(Vector2f r)
		{
			return m_x * r.X + m_y * r.Y;
		}

		public Vector2f Normalized()
		{
			float length = Length;

			return new Vector2f(m_x / length, m_y / length);
		}

		public float Cross(Vector2f r)
		{
			return m_x * r.Y - m_y * r.X;
		}

		public Vector2f Lerp(Vector2f dest, float lerpFactor)
		{
			return dest.Sub(this).Mul(lerpFactor).Add(this);
		}

		//was temp fixed
		public Vector2f Rotate(float angle)
		{
			double rad = ToRadians(angle);
			double cos = Math.Cos(rad);
			double sin = Math.Sin(rad);

			return new Vector2f((float)( m_x * cos - m_y * sin ), (float)( m_x * sin + m_y * cos ));
		}

		//temp fix
		public double ToRadians(double val)
		{
			return ( Math.PI / 180 ) * val;
		}

		public Vector2f Add(Vector2f r)
		{
			return new Vector2f(m_x + r.X, m_y + r.Y);
		}

		public Vector2f Add(float r)
		{
			return new Vector2f(m_x + r, m_y + r);
		}

		public Vector2f Sub(Vector2f r)
		{
			return new Vector2f(m_x - r.X, m_y - r.Y);
		}

		public Vector2f Sub(float r)
		{
			return new Vector2f(m_x - r, m_y - r);
		}

		public Vector2f Mul(Vector2f r)
		{
			return new Vector2f(m_x * r.X, m_y * r.Y);
		}

		public Vector2f Mul(float r)
		{
			return new Vector2f(m_x * r, m_y * r);
		}

		public Vector2f Div(Vector2f r)
		{
			return new Vector2f(m_x / r.X, m_y / r.Y);
		}

		public Vector2f Div(float r)
		{
			return new Vector2f(m_x / r, m_y / r);
		}

		public Vector2f Abs()
		{
			return new Vector2f(Math.Abs(m_x), Math.Abs(m_y));
		}

		public Vector2f Set(float x, float y)
		{ 
			m_x = x; m_y = y; 
			return this;
		}

		public Vector2f Set(Vector2f r) 
		{ 
			Set(r.X, r.Y);
			return this; 
		}

        public override string ToString()
        {
			return "(" + m_x + " " + m_y + ")";
		}

        public bool Equals(Vector2f r)
        {
			return m_x == r.X && m_y == r.Y;
		}
    }

}
