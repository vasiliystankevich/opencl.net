using OpenCL.Core.Net.Types.Primitives;
using OpenCL.Types.Core.Net.Enums.Mem;

namespace OpenCL.Core.Net.Types
{
    /* 1.2 */
    public struct ImageDesc
    {
        MemObjectType ImageType;
        SizeT ImageWidth;
        SizeT ImageHeight;
        SizeT ImageDepth;
        SizeT ImageArraySize;
        SizeT ImageRowPitch;
        SizeT ImageSlicePitch;
        uint NumMipLevels;
        uint NumSamples;

        // Instead of union, buffer is represented by mem_object.
        Mem MemObject;
    }
}