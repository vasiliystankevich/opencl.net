using System;

namespace CASS.OpenCL.Types.Enums
{
    // cl_map_flags - bitfield
    [Flags]
    public enum CLMapFlags : ulong
    {
        Read = 1 << 0,
        Write = 1 << 1,
        /* 1.2 */
        WriteInvalidateRegion = 1 << 2,
    }
}