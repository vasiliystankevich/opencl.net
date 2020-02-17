namespace OpenCL.Types.Core.Net.Enums
{
    // cl_sampler_info
    public enum SamplerInfo : uint
    {
        ReferenceCount = 0x1150,
        Context = 0x1151,
        NormalizedCoords = 0x1152,
        AddressingMode = 0x1153,
        FilterMode = 0x1154,
        /* 2.0 */
        MipFilterMode = 0x1155,
        LodMin = 0x1156,
        LodMax = 0x1157,
    }
}