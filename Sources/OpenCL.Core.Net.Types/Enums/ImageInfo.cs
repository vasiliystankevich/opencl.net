namespace OpenCL.Types.Core.Net.Enums
{
    // cl_image_info
    public enum ImageInfo : uint
    {
        Format = 0x1110,
        ElementSize = 0x1111,
        RowPitch = 0x1112,
        SlicePitch = 0x1113,
        Width = 0x1114,
        Height = 0x1115,
        Depth = 0x1116,
        /* 1.2 */
        ArraySize = 0x1117,
        Buffer = 0x1118,
        NumMipLevels = 0x1119,
        NumSamples = 0x111A
    }
}