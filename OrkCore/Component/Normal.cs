using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkCore.Component
{
    public struct Normal : IEquatable<Normal>
    {
        public Normal(float x, float y, float z) : this()
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
            if (!(obj is Normal normal))
                return false;

            return this.X == normal.X &&
                   this.Y == normal.Y &&
                   this.Z == normal.Z;
                   
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();
        }

        public static bool operator ==(Normal left, Normal right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Normal left, Normal right)
        {
            return !(left == right);
            
        }

        public bool Equals(Normal other)
        {
            if (!(other is Normal normal))
                return false;

            return this.X == normal.X &&
                   this.Y == normal.Y &&
                   this.Z == normal.Z;
        }
    }
}
