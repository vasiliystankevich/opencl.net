using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Primitives;

namespace OpenCL.Types.Core.Net
{
    /* 1.2 */
    public struct CLImageDesc
    {
        CLMemObjectType image_type;
        SizeT image_width;
        SizeT image_height;
        SizeT image_depth;
        SizeT image_array_size;
        SizeT image_row_pitch;
        SizeT image_slice_pitch;
        uint num_mip_levels;
        uint num_samples;

        // Instead of union, buffer is represented by mem_object.
        CLMem mem_object;
    }
}