using System;

namespace OpenCL.Types.Core.Net.Enums.Device
{
    // cl_device_type - bitfield
    [Flags]
    public enum DeviceType : ulong
    {
        Default = 1 << 0,
        Cpu = 1 << 1,
        Gpu = 1 << 2,
        Accelerator = 1 << 3,
        /* 1.2 */
        Custom = 1 << 4,
        All = 0xFFFFFFFF,
    }
}