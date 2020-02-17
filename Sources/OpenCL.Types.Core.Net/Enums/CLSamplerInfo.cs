namespace OpenCL.Types.Core.Net.Enums
{
    // cl_sampler_info
    public enum CLSamplerInfo : uint
    {
        ReferenceCount = 0x1150,
        Context = 0x1151,
        NormalizedCoords = 0x1152,
        AddressingMode = 0x1153,
        FilterMode = 0x1154,
        /* 2.0 */
        MIPFilterMode = 0x1155,
        LODMin = 0x1156,
        LODMax = 0x1157,
    }
}