using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
	public class Quaternion : IEquatable<Quaternion>
	{
		private float m_x;
		private float m_y;
		private float m_z;
		private float m_w;

		public Quaternion(float x, float y, float z, float w)
		{
			this.m_x = x;
			this.m_y = y;
			this.m_z = z;
			this.m_w = w;
		}

		public Quaternion(Vector3f axis, float angle)
		{
			float sinHalfAngle = (float)Math.Sin(angle / 2);
			float cosHalfAngle = (float)Math.Cos(angle / 2);

			this.m_x = axis.X * sinHalfAngle;
			this.m_y = axis.Y * sinHalfAngle;
			this.m_z = axis.Z * sinHalfAngle;
			this.m_w = cosHalfAngle;
		}

		public float Length()
		{
			return (float)Math.Sqrt(m_x * m_x + m_y * m_y + m_z * m_z + m_w * m_w);
		}

		public Quaternion Normalized()
		{
			float length = Length();

			return new Quaternion(m_x / length, m_y / length, m_z / length, m_w / length);
		}

		public Quaternion Conjugate()
		{
			return new Quaternion(-m_x, -m_y, -m_z, m_w);
		}

		public Quaternion Mul(float r)
		{
			return new Quaternion(m_x * r, m_y * r, m_z * r, m_w * r);
		}

		public Quaternion Mul(Quaternion r)
		{
			float w_ = m_w * r.W - m_x * r.X - m_y * r.Y - m_z * r.Z;
			float x_ = m_x * r.W + m_w * r.X + m_y * r.Z - m_z * r.Y;
			float y_ = m_y * r.W + m_w * r.Y + m_z * r.X - m_x * r.Z;
			float z_ = m_z * r.W + m_w * r.Z + m_x * r.Y - m_y * r.X;

			return new Quaternion(x_, y_, z_, w_);
		}

		public Quaternion Mul(Vector3f r)
		{
			float w_ = -m_x * r.X - m_y * r.Y - m_z * r.Z;
			float x_ =  m_w * r.X + m_y * r.Z - m_z * r.Y;
			float y_ =  m_w * r.Y + m_z * r.X - m_x * r.Z;
			float z_ =  m_w * r.Z + m_x * r.Y - m_y * r.X;

			return new Quaternion(x_, y_, z_, w_);
		}

		public Quaternion Sub(Quaternion r)
		{
			return new Quaternion(m_x - r.X, m_y - r.Y, m_z - r.Z, m_w - r.W);
		}

		public Quaternion Add(Quaternion r)
		{
			return new Quaternion(m_x + r.X, m_y + r.Y, m_z + r.Z, m_w + r.W);
		}

		public Matrix4f ToRotationMatrix()
		{
			Vector3f forward =  new Vector3f(2.0f * (m_x * m_z - m_w * m_y), 2.0f * (m_y * m_z + m_w * m_x), 1.0f - 2.0f * (m_x * m_x + m_y * m_y));
			Vector3f up = new Vector3f(2.0f * (m_x * m_y + m_w * m_z), 1.0f - 2.0f * (m_x * m_x + m_z * m_z), 2.0f * (m_y * m_z - m_w * m_x));
			Vector3f right = new Vector3f(1.0f - 2.0f * (m_y * m_y + m_z * m_z), 2.0f * (m_x * m_y - m_w * m_z), 2.0f * (m_x * m_z + m_w * m_y));

			return new Matrix4f().InitRotation(forward, up, right);
		}

		public float Dot(Quaternion r)
		{
			return m_x * r.X + m_y * r.Y + m_z * r.Z + m_w * r.W;
		}

		public Quaternion NLerp(Quaternion dest, float lerpFactor, bool shortest)
		{
			Quaternion correctedDest = dest;

			if (shortest && this.Dot(dest) < 0)
				correctedDest = new Quaternion(-dest.X, -dest.Y, -dest.Z, -dest.W);

			return correctedDest.Sub(this).Mul(lerpFactor).Add(this).Normalized();
		}

		public Quaternion SLerp(Quaternion dest, float lerpFactor, bool shortest)
		{
			float EPSILON = 1e3f; //const

			float cos = this.Dot(dest);
			Quaternion correctedDest = dest;

			if (shortest && cos < 0)
			{
				cos = -cos;
				correctedDest = new Quaternion(-dest.X, -dest.Y, -dest.Z, -dest.W);
			}

			if (Math.Abs(cos) >= 1 - EPSILON)
				return NLerp(correctedDest, lerpFactor, false);

			float sin = (float)Math.Sqrt(1.0f - cos * cos);
			float angle = (float)Math.Atan2(sin, cos);
			float invSin =  1.0f/sin;

			float srcFactor = (float)Math.Sin((1.0f - lerpFactor) * angle) * invSin;
			float destFactor = (float)Math.Sin((lerpFactor) * angle) * invSin;

			return Mul(srcFactor).Add(correctedDest.Mul(destFactor));
		}

		//From Ken Shoemake's "Quaternion Calculus and Fast Animation" article
		public Quaternion(Matrix4f rot)
		{
			float trace = rot.Get(0, 0) + rot.Get(1, 1) + rot.Get(2, 2);

			if (trace > 0)
			{
				float s = 0.5f / (float)Math.Sqrt(trace+ 1.0f);
				m_w = 0.25f / s;
				m_x = ( rot.Get(1, 2) - rot.Get(2, 1) ) * s;
				m_y = ( rot.Get(2, 0) - rot.Get(0, 2) ) * s;
				m_z = ( rot.Get(0, 1) - rot.Get(1, 0) ) * s;
			}
			else
			{
				if (rot.Get(0, 0) > rot.Get(1, 1) && rot.Get(0, 0) > rot.Get(2, 2))
				{
					float s = 2.0f * (float)Math.Sqrt(1.0f + rot.Get(0, 0) - rot.Get(1, 1) - rot.Get(2, 2));
					m_w = ( rot.Get(1, 2) - rot.Get(2, 1) ) / s;
					m_x = 0.25f * s;
					m_y = ( rot.Get(1, 0) + rot.Get(0, 1) ) / s;
					m_z = ( rot.Get(2, 0) + rot.Get(0, 2) ) / s;
				}
				else if (rot.Get(1, 1) > rot.Get(2, 2))
				{
					float s = 2.0f * (float)Math.Sqrt(1.0f + rot.Get(1, 1) - rot.Get(0, 0) - rot.Get(2, 2));
					m_w = ( rot.Get(2, 0) - rot.Get(0, 2) ) / s;
					m_x = ( rot.Get(1, 0) + rot.Get(0, 1) ) / s;
					m_y = 0.25f * s;
					m_z = ( rot.Get(2, 1) + rot.Get(1, 2) ) / s;
				}
				else
				{
					float s = 2.0f * (float)Math.Sqrt(1.0f + rot.Get(2, 2) - rot.Get(0, 0) - rot.Get(1, 1));
					m_w = ( rot.Get(0, 1) - rot.Get(1, 0) ) / s;
					m_x = ( rot.Get(2, 0) + rot.Get(0, 2) ) / s;
					m_y = ( rot.Get(1, 2) + rot.Get(2, 1) ) / s;
					m_z = 0.25f * s;
				}
			}

			float length = (float)Math.Sqrt(m_x * m_x + m_y * m_y + m_z * m_z + m_w * m_w);
			m_x /= length;
			m_y /= length;
			m_z /= length;
			m_w /= length;
		}

		public Vector3f GetForward()
		{
			return new Vector3f(0, 0, 1).Rotate(this);
		}

		public Vector3f GetBack()
		{
			return new Vector3f(0, 0, -1).Rotate(this);
		}

		public Vector3f GetUp()
		{
			return new Vector3f(0, 1, 0).Rotate(this);
		}

		public Vector3f GetDown()
		{
			return new Vector3f(0, -1, 0).Rotate(this);
		}

		public Vector3f GetRight()
		{
			return new Vector3f(1, 0, 0).Rotate(this);
		}

		public Vector3f GetLeft()
		{
			return new Vector3f(-1, 0, 0).Rotate(this);
		}

		public Quaternion Set(float x, float y, float z, float w)
		{
			this.m_x = x;
			this.m_y = y;
			this.m_z = z;
			this.m_w = w;
			return this;
		}

		public Quaternion Set(Quaternion r)
		{
			Set(r.X, r.Y, r.Z, r.W);
			return this;
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

		public float Z
		{
			get
			{
				return m_z;
			}
			set
			{
				m_z = value;
			}
		}

		public float W
		{
			get
			{
				return m_w;
			}
			set
			{
				m_w = value;
			}
		}

        public bool Equals(Quaternion r)
        {
			return m_x == r.X && m_y == r.Y && m_z == r.Z && m_w == r.W;
		}
    }
}