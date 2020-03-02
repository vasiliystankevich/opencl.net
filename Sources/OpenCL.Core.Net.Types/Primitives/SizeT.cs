using System;

namespace OpenCL.Core.Net.Types.Primitives
{
    public struct SizeT
    {
        public SizeT(int value) => Value = new IntPtr(value);

        public SizeT(uint value) => Value = new IntPtr((int)value);

        public SizeT(long value) => Value = new IntPtr(value);

        public SizeT(ulong value) => Value = new IntPtr((long)value);

        public static implicit operator int(SizeT data) => data.Value.ToInt32();

        public static implicit operator uint(SizeT data) => (uint)data.Value;

        public static implicit operator long(SizeT data) => data.Value.ToInt64();

        public static implicit operator ulong(SizeT data) => (ulong)data.Value;

        public static implicit operator SizeT(int value) => new SizeT(value);

        public static implicit operator SizeT(uint value) => new SizeT(value);

        public static implicit operator SizeT(long value) => new SizeT(value);

        public static implicit operator SizeT(ulong value) => new SizeT(value);

        public static bool operator !=(SizeT val1, SizeT val2) => val1.Value != val2.Value;

        public static bool operator ==(SizeT val1, SizeT val2) => val1.Value == val2.Value;

        public override bool Equals(object obj) => obj is SizeT element && Value.Equals(element.Value);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Convert.ToInt32(0xE67B7141);

        IntPtr Value;
    }
}