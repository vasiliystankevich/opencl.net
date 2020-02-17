namespace OpenCL.Types.Core.Net.Enums
{
    /* 1.2 */
    /* cl_kernel_arg_access_qualifier */
    public enum CLKernelArgAccessQualifier : uint
    {
        ReadOnly = 0x11A0,
        WriteOnly = 0x11A1,
        ReadWrite = 0x11A2,
        None = 0x11A3,
    }
}