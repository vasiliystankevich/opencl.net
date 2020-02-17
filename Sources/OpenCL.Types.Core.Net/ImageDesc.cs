using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Primitives;

namespace OpenCL.Types.Core.Net
{
    /* 1.2 */
    public struct ImageDesc
    {
        CLMemObjectType ImageType;
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