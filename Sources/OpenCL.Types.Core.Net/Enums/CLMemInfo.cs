namespace OpenCL.Types.Core.Net.Enums
{
    // cl_mem_info
    public enum MemInfo : uint
    {
        Type = 0x1100,
        Flags = 0x1101,
        Size = 0x1102,
        HostPtr = 0x1103,
        MapCount = 0x1104,
        ReferenceCount = 0x1105,
        Context = 0x1106,
        /* 1.1 */
        AssociatedMemObject = 0x1107,
        Offset = 0x1108,
        /* 2.0 */
        UsesSvmPointer = 0x1109
    }
}