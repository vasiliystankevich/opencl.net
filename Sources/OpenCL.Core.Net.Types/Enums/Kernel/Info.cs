namespace OpenCL.Types.Core.Net.Enums.Kernel
{
    // cl_kernel_info
    public enum KernelInfo : uint
    {
        FunctionName = 0x1190,
        NumArgs = 0x1191,
        ReferenceCount = 0x1192,
        Context = 0x1193,
        Program = 0x1194,
        /* 1.2 */
        Attributes = 0x1195,
        /* 2.1 */
        MaxNumSubGroups = 0x11B9,
        CompileNumSubGroups = 0x11BA
    }
}