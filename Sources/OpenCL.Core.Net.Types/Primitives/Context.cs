using System;

namespace OpenCL.Core.Net.Types.Primitives
{
    public struct Context
    {
        public Context(int value) => Value = new IntPtr(value);

        public Context(uint value) => Value = new IntPtr((int)value);

        public Context(long value) => Value = new IntPtr(value);

        public Context(ulong value) => Value = new IntPtr((long)value);

        public static implicit operator int(Context data) => data.Value.ToInt32();

        public static implicit operator uint(Context data) => (uint)data.Value;

        public static implicit operator long(Context data) => data.Value.ToInt64();

        public static implicit operator ulong(Context data) => (ulong)data.Value;

        public static implicit operator Context(int value) => new Context(value);

        public static implicit operator Context(uint value) => new Context(value);

        public static implicit operator Context(long value) => new Context(value);

        public static implicit operator Context(ulong value) => new Context(value);

        public static bool operator !=(Context val1, Context val2) => val1.Value != val2.Value;

        public static bool operator ==(Context val1, Context val2) => val1.Value == val2.Value;

        public override bool Equals(object obj) => obj is Context data && Value.Equals(data.Value);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Convert.ToInt32(HashCode);

		static readonly uint HashCode = 0x49e7d151;

        IntPtr Value;
    }
} 	
