using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine.Component
{
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
    }
}
