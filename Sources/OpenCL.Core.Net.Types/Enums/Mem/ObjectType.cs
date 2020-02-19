﻿namespace OpenCL.Core.Net.Types.Enums.Mem
{
    // cl_mem_object_type
    public enum MemObjectType : uint
    {
        Buffer = 0x10F0,
        Image2D = 0x10F1,
        Image3D = 0x10F2,
        /* 1.2 */
        Image2DArray = 0x10F3,
        Image1D = 0x10F4,
        Image1DArray = 0x10F5,
        Image1DBuffer = 0x10F6,
        /* 2.0 */
        Pipe = 0x10F7
    }
}