using System;

namespace OpenCL.Core.Net.Types.Primitives
{
    public struct Program
    {
        public Program(int value) => Value = new IntPtr(value);

        public Program(uint value) => Value = new IntPtr((int)value);

        public Program(long value) => Value = new IntPtr(value);

        public Program(ulong value) => Value = new IntPtr((long)value);

        public static implicit operator int(Program data) => data.Value.ToInt32();

        public static implicit operator uint(Program data) => (uint)data.Value;

        public static implicit operator long(Program data) => data.Value.ToInt64();

        public static implicit operator ulong(Program data) => (ulong)data.Value;

        public static implicit operator Program(int value) => new Program(value);

        public static implicit operator Program(uint value) => new Program(value);

        public static implicit operator Program(long value) => new Program(value);

        public static implicit operator Program(ulong value) => new Program(value);

        public static bool operator !=(Program val1, Program val2) => val1.Value != val2.Value;

        public static bool operator ==(Program val1, Program val2) => val1.Value == val2.Value;

        public override bool Equals(object obj) => obj is Program data && Value.Equals(data.Value);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Convert.ToInt32(HashCode);

		static readonly uint HashCode = 0x15ece097;

        IntPtr Value;
    }
} 	
