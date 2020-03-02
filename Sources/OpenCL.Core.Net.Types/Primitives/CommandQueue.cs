using System;

namespace OpenCL.Core.Net.Types.Primitives
{
    public struct CommandQueue
    {
        public CommandQueue(int value) => Value = new IntPtr(value);

        public CommandQueue(uint value) => Value = new IntPtr((int)value);

        public CommandQueue(long value) => Value = new IntPtr(value);

        public CommandQueue(ulong value) => Value = new IntPtr((long)value);

        public static implicit operator int(CommandQueue data) => data.Value.ToInt32();

        public static implicit operator uint(CommandQueue data) => (uint)data.Value;

        public static implicit operator long(CommandQueue data) => data.Value.ToInt64();

        public static implicit operator ulong(CommandQueue data) => (ulong)data.Value;

        public static implicit operator CommandQueue(int value) => new CommandQueue(value);

        public static implicit operator CommandQueue(uint value) => new CommandQueue(value);

        public static implicit operator CommandQueue(long value) => new CommandQueue(value);

        public static implicit operator CommandQueue(ulong value) => new CommandQueue(value);

        public static bool operator !=(CommandQueue val1, CommandQueue val2) => val1.Value != val2.Value;

        public static bool operator ==(CommandQueue val1, CommandQueue val2) => val1.Value == val2.Value;

        public override bool Equals(object obj) => obj is CommandQueue data && Value.Equals(data.Value);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Convert.ToInt32(HashCode);

		static readonly uint HashCode = 0xcf0d0a44;

        IntPtr Value;
    }
} 	
