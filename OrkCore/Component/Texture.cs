using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine.Component
{
    public struct Texture : IEquatable<Texture>
    {
        public Texture(float x, float y) : this()
        {
            X = x;
            Y = y;
        }

        public float X { get; private set; }
        public float Y { get; private set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Texture texture))
                return false;

            return this.X == texture.X &&
                   this.Y == texture.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public static bool operator ==(Texture left, Texture right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Texture left, Texture right)
        {
            return !(left == right);
        }

        public bool Equals(Texture other)
        {
            if (!(other is Texture texture))
                return false;

            return this.X == texture.X &&
                   this.Y == texture.Y;
        }
    }
}
