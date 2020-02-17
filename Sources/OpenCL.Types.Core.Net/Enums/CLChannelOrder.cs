namespace OpenCL.Types.Core.Net.Enums
{
    // cl_channel_order
    public enum ChannelOrder : uint
    {
        R = 0x10B0,
        A = 0x10B1,
        Rg = 0x10B2,
        Ra = 0x10B3,
        Rgb = 0x10B4,
        Rgba = 0x10B5,
        Bgra = 0x10B6,
        Argb = 0x10B7,
        Intensity = 0x10B8,
        Luminance = 0x10B9,
        /* 1.1 */
        Rx = 0x10BA,
        Rgx = 0x10BB,
        Rgbx = 0x10BC,
        /* 1.2 */
        Depth = 0x10BD,
        DepthStencil = 0x10BE,
        /* 2.0 */
        Srgb = 0x10BF,
        Srgbx = 0x10C0,
        Srgba = 0x10C1,
        Sbgra = 0x10C2,
        Abgr = 0x10C3
    }
}