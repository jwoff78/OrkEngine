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

        //TODO FIX EQUALS #1
        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
