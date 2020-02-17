namespace OpenCL.Types.Core.Net.Enums.Context
{
    // cl_context_info
    public enum ContextInfo : uint
    {
        ReferenceCount = 0x1080,
        Devices = 0x1081,
        Properties = 0x1082,
        /* 1.1 */
        NumDevices = 0x1083
    }
}