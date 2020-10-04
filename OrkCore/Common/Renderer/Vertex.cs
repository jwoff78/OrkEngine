using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    public class Vertex
    {
        public const int SIZE = 11;

        private Vector3f m_position;
        private Vector2f m_texCoord;
        private Vector3f m_normal;
        private Vector3f m_tangent;


        public Vertex(Vector3f positon) : this(positon, new Vector2f(0, 0)) { }

        public Vertex(Vector3f position, Vector2f texCoord) : this(position, texCoord, new Vector3f(0, 0, 0)) { }

        public Vertex(Vector3f position, Vector2f texCoord, Vector3f normal) : this(position, texCoord, normal, new Vector3f(0, 0, 0)) { }

        public Vertex(Vector3f position, Vector2f texCoord, Vector3f normal, Vector3f tangent)
        {
            m_position = position;
            m_texCoord = texCoord;
            m_normal = normal;
            m_tangent = tangent;
        }

        public Vector3f Tangent
        {
            get
            {
                return m_tangent;
            }

            set
            {
                m_tangent = value;
            }

        }

        public Vector3f Position
        {
            get
            {
                return m_position;
            }

            set
            {
                m_position = value;
            }
        }

        public Vector2f TexCoord
        {
            get
            {
                return m_texCoord;
            }

            set
            {
                m_texCoord = value;
            }
        }

        public Vector3f Normal
        {
            get
            {
                return m_normal;
            }

            set
            {
                m_normal = value;
            }
        }
    }
    /*
    public struct Vertex : IEquatable<Vertex>
    {
        public Vertex(float x, float y, float z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Vertex vertex))
                return false;

            return this.X == vertex.X &&
                   this.Y == vertex.Y &&
                   this.Z == vertex.Z;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();
        }

        public static bool operator ==(Vertex left, Vertex right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vertex left, Vertex right)
        {
            return !(left == right);
        }

        public bool Equals(Vertex other)
        {
            if (!(other is Vertex vertex))
                return false;

            return this.X == vertex.X &&
                   this.Y == vertex.Y &&
                   this.Z == vertex.Z;
        }
    }*/
}
