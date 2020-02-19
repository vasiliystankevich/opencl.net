﻿using System;

namespace OpenCL.Core.Net.Types.Enums.Device
{
    // cl_device_fp_config - bitfield
    [Flags]
    public enum DeviceFpConfig : ulong
    {
        Denorm = 1 << 0,
        InfNan = 1 << 1,
        RoundToNearest = 1 << 2,
        RoundToZero = 1 << 3,
        RoundToInf = 1 << 4,
        Fma = 1 << 5,
        /* 1.1 */
        SoftFloat = 1 << 6,
        /* 1.2 */
        CorrectlyRoundedDivideSqrt = 1 << 7
    }
}