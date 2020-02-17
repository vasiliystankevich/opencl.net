using System;

namespace CASS.OpenCL.Types.Enums
{
    // cl_device_type - bitfield
    [Flags]
    public enum CLDeviceType : ulong
    {
        Default = (1 << 0),
        CPU = (1 << 1),
        GPU = (1 << 2),
        Accelerator = (1 << 3),
        /* 1.2 */
        Custom = 1 << 4,
        All = 0xFFFFFFFF,
    }
}
