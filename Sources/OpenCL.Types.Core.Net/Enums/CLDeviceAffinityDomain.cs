using System;

namespace OpenCL.Types.Core.Net.Enums
{
    /* 1.2 */
    // cl_device_affinity_domain
    [Flags]
    public enum CLDeviceAffinityDomain : ulong
    {
        NUMA = 1 << 0,
        L4Cache = 1 << 1,
        L3Cache = 1 << 2,
        L2Cache = 1 << 3,
        L1Cache = 1 << 4,
        NextPartitionable = 1 << 5
    }
}