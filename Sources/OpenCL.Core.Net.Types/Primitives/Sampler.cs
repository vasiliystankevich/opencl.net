using System;

namespace OpenCL.Core.Net.Types.Primitives
{
    public struct Sampler
    {
        public Sampler(int value) => Value = new IntPtr(value);

        public Sampler(uint value) => Value = new IntPtr((int)value);

        public Sampler(long value) => Value = new IntPtr(value);

        public Sampler(ulong value) => Value = new IntPtr((long)value);

        public static implicit operator int(Sampler data) => data.Value.ToInt32();

        public static implicit operator uint(Sampler data) => (uint)data.Value;

        public static implicit operator long(Sampler data) => data.Value.ToInt64();

        public static implicit operator ulong(Sampler data) => (ulong)data.Value;

        public static implicit operator Sampler(int value) => new Sampler(value);

        public static implicit operator Sampler(uint value) => new Sampler(value);

        public static implicit operator Sampler(long value) => new Sampler(value);

        public static implicit operator Sampler(ulong value) => new Sampler(value);

        public static bool operator !=(Sampler val1, Sampler val2) => val1.Value != val2.Value;

        public static bool operator ==(Sampler val1, Sampler val2) => val1.Value == val2.Value;

        public override bool Equals(object obj) => obj is Sampler data && Value.Equals(data.Value);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Convert.ToInt32(HashCode);

		static readonly uint HashCode = 0xf08403c6;

        IntPtr Value;
    }
} 	
