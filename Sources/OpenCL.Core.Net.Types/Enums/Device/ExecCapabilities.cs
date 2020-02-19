using System;

namespace OpenCL.Core.Net.Types.Enums.Device
{
    // cl_device_exec_capabilities - bitfield
    [Flags]
    public enum DeviceExecCapabilities : ulong
    {
        Kernel = 1 << 0,
        NativeKernel = 1 << 1
    }
}