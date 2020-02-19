using System;

namespace OpenCL.Core.Net.Types.Enums.Command
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