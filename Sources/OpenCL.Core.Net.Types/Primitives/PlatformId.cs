using System;

namespace OpenCL.Core.Net.Types.Primitives
{
    public struct PlatformId
    {
        public PlatformId(int value) => Value = new IntPtr(value);

        public PlatformId(uint value) => Value = new IntPtr((int)value);

        public PlatformId(long value) => Value = new IntPtr(value);

        public PlatformId(ulong value) => Value = new IntPtr((long)value);

        public PlatformId(IntPtr value) => Value = value;

        public static implicit operator int(PlatformId data) => data.Value.ToInt32();

        public static implicit operator uint(PlatformId data) => (uint)data.Value;

        public static implicit operator long(PlatformId data) => data.Value.ToInt64();

        public static implicit operator ulong(PlatformId data) => (ulong)data.Value;

        public static implicit operator IntPtr(PlatformId data) => data.Value;

        public static implicit operator PlatformId(int value) => new PlatformId(value);

        public static implicit operator PlatformId(uint value) => new PlatformId(value);

        public static implicit operator PlatformId(long value) => new PlatformId(value);

        public static implicit operator PlatformId(ulong value) => new PlatformId(value);

        public static implicit operator PlatformId(IntPtr value) => new PlatformId(value);

        public static bool operator !=(PlatformId val1, PlatformId val2) => val1.Value != val2.Value;

        public static bool operator ==(PlatformId val1, PlatformId val2) => val1.Value == val2.Value;

        public override bool Equals(object obj) => Value.Equals(obj);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        IntPtr Value;
    }
}