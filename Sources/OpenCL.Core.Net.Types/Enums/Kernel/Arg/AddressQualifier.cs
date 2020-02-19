namespace OpenCL.Types.Core.Net.Enums.Kernel.Arg
{
    /* 1.2 */
    /* cl_kernel_arg_address_qualifier */
    public enum KernelArgAddressQualifier : uint
    {
        Global = 0x119B,
        Local = 0x119C,
        Constant = 0x119D,
        Private = 0x119E
    }
}