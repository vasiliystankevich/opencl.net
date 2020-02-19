namespace OpenCL.Types.Core.Net.Enums
{
    // cl_platform_info
    public enum PlatformInfo : uint
    {
        Profile = 0x0900,
        Version = 0x0901,
        Name = 0x0902,
        Vendor = 0x0903,
        Extensions = 0x0904,
        /* 2.1 */
        HostTimerResolution = 0x0905
    }
}