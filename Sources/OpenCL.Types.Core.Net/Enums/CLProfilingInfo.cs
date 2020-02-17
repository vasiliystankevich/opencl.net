﻿namespace OpenCL.Types.Core.Net.Enums
{
    // cl_profiling_info
    public enum CLProfilingInfo : uint
    {
        Queued = 0x1280,
        Submit = 0x1281,
        Start = 0x1282,
        End = 0x1283,
        /* 2.0 */
        Complete = 0x1284,
    }
}