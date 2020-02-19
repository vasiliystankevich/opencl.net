using System;

namespace OpenCL.Core.Net.Types.Enums.Kernel.Arg
{
    /* 1.2 */
    /* cl_kernel_arg_type_qualifier */
    [Flags]
    public enum KernelArgTypeQualifier : ulong
    {
        None = 0,
        Const = 1 << 0,
        Restrict = 1 << 1,
        Volatile = 1 << 2,
        /* 2.0 */
        Pipe = 1 << 3
    }
}