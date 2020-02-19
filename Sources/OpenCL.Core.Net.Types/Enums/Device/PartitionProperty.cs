namespace OpenCL.Types.Core.Net.Enums.Device
{
    /* 1.2 */
    // cl_device_partition_property
    public enum DevicePartitionProperty : long
    {
        Equally = 0x1086,
        ByCounts = 0x1087,
        ByCountsListEnd = 0x0,
        ByAffinityDomain = 0x1088
    }
}