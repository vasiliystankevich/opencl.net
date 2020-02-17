namespace OpenCL.Types.Core.Net.Enums.Channel
{
    // cl_channel_type
    public enum ChannelType : uint
    {
        SnormInt8 = 0x10D0,
        SnormInt16 = 0x10D1,
        UnormInt8 = 0x10D2,
        UnormInt16 = 0x10D3,
        UnormShort565 = 0x10D4,
        UnormShort555 = 0x10D5,
        UnormInt101010 = 0x10D6,
        SignedInt8 = 0x10D7,
        SignedInt16 = 0x10D8,
        SignedInt32 = 0x10D9,
        UnSignedInt8 = 0x10DA,
        UnSignedInt16 = 0x10DB,
        UnSignedInt32 = 0x10DC,
        HalfFloat = 0x10DD,
        Float = 0x10DE,
        /* 1.2 */
        UnormInt24 = 0x10DF,
        /* 2.1 */
        UnormInt1010102 = 0x10E0
    }
}