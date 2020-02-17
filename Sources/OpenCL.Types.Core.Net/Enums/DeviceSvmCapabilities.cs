using System;

namespace OpenCL.Types.Core.Net.Enums
{
    /* 2.0 */
    // cl_device_svm_capabilities - bitfield
    [Flags]
    public enum DeviceSvmCapabilities : ulong
    {
        CoarseGrainBuffer = 1 << 0,
        FineGrainBuffer = 1 << 1,
        FineGrainSystem = 1 << 2,
        Atomics = 1 << 3
    }
}