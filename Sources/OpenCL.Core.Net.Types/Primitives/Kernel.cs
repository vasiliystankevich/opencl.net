using System;

namespace OpenCL.Core.Net.Types.Primitives
{
    public struct Kernel
    {
        public Kernel(int value) => Value = new IntPtr(value);

        public Kernel(uint value) => Value = new IntPtr((int)value);

        public Kernel(long value) => Value = new IntPtr(value);

        public Kernel(ulong value) => Value = new IntPtr((long)value);

        public static implicit operator int(Kernel data) => data.Value.ToInt32();

        public static implicit operator uint(Kernel data) => (uint)data.Value;

        public static implicit operator long(Kernel data) => data.Value.ToInt64();

        public static implicit operator ulong(Kernel data) => (ulong)data.Value;

        public static implicit operator Kernel(int value) => new Kernel(value);

        public static implicit operator Kernel(uint value) => new Kernel(value);

        public static implicit operator Kernel(long value) => new Kernel(value);

        public static implicit operator Kernel(ulong value) => new Kernel(value);

        public static bool operator !=(Kernel val1, Kernel val2) => val1.Value != val2.Value;

        public static bool operator ==(Kernel val1, Kernel val2) => val1.Value == val2.Value;

        public override bool Equals(object obj) => obj is Kernel data && Value.Equals(data.Value);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Convert.ToInt32(HashCode);

		static readonly uint HashCode = 0x5db89a2a;

        IntPtr Value;
    }
} 	
