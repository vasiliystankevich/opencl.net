namespace CASS.OpenCL.Types.Enums
{
    // cl_channel_order
    public enum CLChannelOrder : uint
    {
        R = 0x10B0,
        A = 0x10B1,
        RG = 0x10B2,
        RA = 0x10B3,
        RGB = 0x10B4,
        RGBA = 0x10B5,
        BGRA = 0x10B6,
        ARGB = 0x10B7,
        Intensity = 0x10B8,
        Luminance = 0x10B9,
        /* 1.1 */
        Rx = 0x10BA,
        RGx = 0x10BB,
        RGBx = 0x10BC,
        /* 1.2 */
        Depth = 0x10BD,
        DepthStencil = 0x10BE,
        /* 2.0 */
        sRGB = 0x10BF,
        sRGBx = 0x10C0,
        sRGBA = 0x10C1,
        sBGRA = 0x10C2,
        ABGR = 0x10C3,
    }
}