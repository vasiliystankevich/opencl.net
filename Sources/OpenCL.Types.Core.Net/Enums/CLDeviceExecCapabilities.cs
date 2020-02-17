using System;

namespace OpenCL.Types.Core.Net.Enums
{
    // cl_device_exec_capabilities - bitfield
    [Flags]
    public enum CLDeviceExecCapabilities : ulong
    {
        Kernel = (1 << 0),
        NativeKernel = (1 << 1),
    }
}