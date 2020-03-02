using System;

namespace OpenCL.Core.Net.Types.Primitives
{
    public struct DeviceId
    {
        public DeviceId(int value) => Value = new IntPtr(value);

        public DeviceId(uint value) => Value = new IntPtr((int)value);

        public DeviceId(long value) => Value = new IntPtr(value);

        public DeviceId(ulong value) => Value = new IntPtr((long)value);

        public static implicit operator int(DeviceId data) => data.Value.ToInt32();

        public static implicit operator uint(DeviceId data) => (uint)data.Value;

        public static implicit operator long(DeviceId data) => data.Value.ToInt64();

        public static implicit operator ulong(DeviceId data) => (ulong)data.Value;

        public static implicit operator DeviceId(int value) => new DeviceId(value);

        public static implicit operator DeviceId(uint value) => new DeviceId(value);

        public static implicit operator DeviceId(long value) => new DeviceId(value);

        public static implicit operator DeviceId(ulong value) => new DeviceId(value);

        public static bool operator !=(DeviceId val1, DeviceId val2) => val1.Value != val2.Value;

        public static bool operator ==(DeviceId val1, DeviceId val2) => val1.Value == val2.Value;

        public override bool Equals(object obj) => obj is DeviceId data && Value.Equals(data.Value);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Convert.ToInt32(HashCode);

		static readonly uint HashCode = 0xc29ecdad;

        IntPtr Value;
    }
} 	
