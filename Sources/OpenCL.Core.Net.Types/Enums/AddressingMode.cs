namespace OpenCL.Core.Net.Types.Enums
{
    // cl_addressing_mode
    public enum AddressingMode : uint
    {
        None = 0x1130,
        ClampToEdge = 0x1131,
        Clamp = 0x1132,
        Repeat = 0x1133,
        /* 1.1 */
        MirroredRepeat = 0x1134
    }
}