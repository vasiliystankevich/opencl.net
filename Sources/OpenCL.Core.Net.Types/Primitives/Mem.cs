using System;

namespace OpenCL.Core.Net.Types.Primitives
{
    public struct Mem
    {
        public Mem(int value) => Value = new IntPtr(value);

        public Mem(uint value) => Value = new IntPtr((int)value);

        public Mem(long value) => Value = new IntPtr(value);

        public Mem(ulong value) => Value = new IntPtr((long)value);

        public static implicit operator int(Mem data) => data.Value.ToInt32();

        public static implicit operator uint(Mem data) => (uint)data.Value;

        public static implicit operator long(Mem data) => data.Value.ToInt64();

        public static implicit operator ulong(Mem data) => (ulong)data.Value;

        public static implicit operator Mem(int value) => new Mem(value);

        public static implicit operator Mem(uint value) => new Mem(value);

        public static implicit operator Mem(long value) => new Mem(value);

        public static implicit operator Mem(ulong value) => new Mem(value);

        public static bool operator !=(Mem val1, Mem val2) => val1.Value != val2.Value;

        public static bool operator ==(Mem val1, Mem val2) => val1.Value == val2.Value;

        public override bool Equals(object obj) => obj is Mem data && Value.Equals(data.Value);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Convert.ToInt32(HashCode);

		static readonly uint HashCode = 0xaa410acb;

        IntPtr Value;
    }
} 	
