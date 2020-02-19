using System;

namespace OpenCL.Core.Net.Types.Enums
{
    // cl_map_flags - bitfield
    [Flags]
    public enum MapFlags : ulong
    {
        Read = 1 << 0,
        Write = 1 << 1,
        /* 1.2 */
        WriteInvalidateRegion = 1 << 2
    }
}