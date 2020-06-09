using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkCore.Component
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

        ////TODO FIX EQUALS #2
        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
