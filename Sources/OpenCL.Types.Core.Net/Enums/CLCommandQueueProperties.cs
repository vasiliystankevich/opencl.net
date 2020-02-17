using System;

namespace OpenCL.Types.Core.Net.Enums
{
    // cl_command_queue_properties - bitfield
    [Flags]
    public enum CommandQueueProperties : ulong
    {
        OutOfOrderExecModeEnable = 1 << 0,
        ProfilingEnable = 1 << 1,
        /* 2.0 */
        OnDevice = 1 << 2,
        OnDeviceDefault = 1 << 3
    }
}