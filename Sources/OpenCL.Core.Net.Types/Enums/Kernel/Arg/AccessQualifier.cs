namespace OpenCL.Core.Net.Types.Enums.Kernel.Arg
{
    /* 1.2 */
    /* cl_kernel_arg_access_qualifier */
    public enum KernelArgAccessQualifier : uint
    {
        ReadOnly = 0x11A0,
        WriteOnly = 0x11A1,
        ReadWrite = 0x11A2,
        None = 0x11A3
    }
}