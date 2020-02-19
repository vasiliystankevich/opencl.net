﻿namespace OpenCL.Core.Net.Types.Enums
{
    // cl_event_info
    public enum EventInfo : uint
    {
        CommandQueue = 0x11D0,
        CommandType = 0x11D1,
        ReferenceCount = 0x11D2,
        CommandExecutionStatus = 0x11D3,
        /* 1.1 */
        Context = 0x11D4
    }
}