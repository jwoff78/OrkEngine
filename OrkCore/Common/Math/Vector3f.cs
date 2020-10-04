using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    public class Vector3f : IEquatable<Vector3f>
    {
        private float m_x;
        private float m_y;
        private float m_z;

        public Vector3f(float x, float y, float z)
        {
            m_x = x;
            m_y = y;
            m_z = z;
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

        public Vector2f XY
        {
            get
            {
                return new Vector2f(m_x, m_y);
            }
        }

        public Vector2f YZ
        {
            get
            {
                return new Vector2f(m_y, m_z);
            }

        }
        public Vector2f ZX
        {
            get
            {
                return new Vector2f(m_z, m_x);
            }

        }

        public Vector2f YX
        {
            get
            {
                return new Vector2f(m_y, m_x);
            }

        }

        public Vector2f ZY
        {
            get
            {
                return new Vector2f(m_z, m_y);
            }

        }

        public Vector2f XZ
        {
            get
            {
                return new Vector2f(m_x, m_z);
            }

        }

        public float Length
        {
            get
            {
                return (float)Math.Sqrt(m_x * m_x + m_y * m_y + m_z * m_z);
            }

        }

        public float Max
        {
            get
            {
                return Math.Max(m_x, Math.Max(m_y, m_z));
            }

        }

        public float Dot(Vector3f r)
        {
            return m_x * r.X + m_y * r.Y + m_z * r.Z;
        }

        public Vector3f Cross(Vector3f r)
        {
            float x_ = m_y * r.Z - m_z * r.Y;
            float y_ = m_z * r.X - m_x * r.Z;
            float z_ = m_x * r.Y - m_y * r.X;

            return new Vector3f(x_, y_, z_);
        }

        public Vector3f Normalized()
        {
            float length = Length;

            return new Vector3f(m_x / length, m_y / length, m_z / length);
        }

        public Vector3f Rotate(Vector3f axis, float angle)
        {
            float sinAngle = (float)Math.Sin(-angle);
            float cosAngle = (float)Math.Cos(-angle);

            return this.Cross(
                axis.Mul(sinAngle)).Add(           //Rotation on local X
                    ( this.Mul(cosAngle) ).Add(                     //Rotation on local Z
                            axis.Mul(this.Dot(axis.Mul(1 - cosAngle))))); //Rotation on local Y
        }

        public Vector3f Rotate(Quaternion rotation)
        {
            Quaternion conjugate = rotation.Conjugate();

            Quaternion w = rotation.Mul(this).Mul(conjugate);

            return new Vector3f(w.X, w.Y, w.Z);
        }

        public Vector3f Lerp(Vector3f dest, float lerpFactor)
        {
            return dest.Sub(this).Mul(lerpFactor).Add(this);
        }

        public Vector3f Add(Vector3f r)
        {
            return new Vector3f(m_x + r.X, m_y + r.Y, m_z + r.Z);
        }

        public Vector3f Add(float r)
        {
            return new Vector3f(m_x + r, m_y + r, m_z + r);
        }

        public Vector3f Sub(Vector3f r)
        {
            return new Vector3f(m_x - r.X, m_y - r.Y, m_z - r.Z);
        }

        public Vector3f Sub(float r)
        {
            return new Vector3f(m_x - r, m_y - r, m_z - r);
        }

        public Vector3f Mul(Vector3f r)
        {
            return new Vector3f(m_x * r.X, m_y * r.Y, m_z * r.Z);
        }

        public Vector3f Mul(float r)
        {
            return new Vector3f(m_x * r, m_y * r, m_z * r);
        }

        public Vector3f Div(Vector3f r)
        {
            return new Vector3f(m_x / r.X, m_y / r.Y, m_z / r.Z);
        }

        public Vector3f Div(float r)
        {
            return new Vector3f(m_x / r, m_y / r, m_z / r);
        }

        public Vector3f Abs()
        {
            return new Vector3f(Math.Abs(m_x), Math.Abs(m_y), Math.Abs(m_z));
        }

        public Vector3f Set(float x, float y, float z) 
        {
            m_x = x;
            m_y = y;
            m_z = z; 
            return this; 
        }

        public Vector3f Set(Vector3f r) {
            Set(r.X, r.Y, r.Z); 
            return this; 
        }

        public override string ToString()
        {
            return "(" + m_x + " " + m_y + " " + m_z + ")";
        }

        public bool Equals(Vector3f r)
        {
            return m_x == r.X && m_y == r.Y && m_z == r.Z;
        }
    }
}
