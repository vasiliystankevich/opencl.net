using System;

namespace OpenCL.Core.Net.Types.Primitives
{
    public struct Event
    {
        public Event(int value) => Value = new IntPtr(value);

        public Event(uint value) => Value = new IntPtr((int)value);

        public Event(long value) => Value = new IntPtr(value);

        public Event(ulong value) => Value = new IntPtr((long)value);

        public static implicit operator int(Event data) => data.Value.ToInt32();

        public static implicit operator uint(Event data) => (uint)data.Value;

        public static implicit operator long(Event data) => data.Value.ToInt64();

        public static implicit operator ulong(Event data) => (ulong)data.Value;

        public static implicit operator Event(int value) => new Event(value);

        public static implicit operator Event(uint value) => new Event(value);

        public static implicit operator Event(long value) => new Event(value);

        public static implicit operator Event(ulong value) => new Event(value);

        public static bool operator !=(Event val1, Event val2) => val1.Value != val2.Value;

        public static bool operator ==(Event val1, Event val2) => val1.Value == val2.Value;

        public override bool Equals(object obj) => obj is Event data && Value.Equals(data.Value);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Convert.ToInt32(HashCode);

		static readonly uint HashCode = 0x927176ef;

        IntPtr Value;
    }
} 	
