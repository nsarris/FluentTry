using System;

namespace FluentTry
{
    public struct Void : IEquatable<Void>, IComparable<Void>
    {
        public static Void Value { get; } = new Void();
        public override bool Equals(object obj) => true;
        public override int GetHashCode() => 0;
        public bool Equals(Void other) => true;
        int IComparable<Void>.CompareTo(Void other) => 0;
        public static bool operator ==(Void x, Void y) => true;
        public static bool operator !=(Void x, Void y) => false;
    }
}