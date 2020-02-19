using System;

namespace OpenCL.Core.Net.Types.Enums
{
    /* 2.0 */
    // cl_svm_mem_flags - bitfield
    [Flags]
    public enum SvmMemFlags : ulong
    {
        ReadWrite = 1 << 0,
        WriteOnly = 1 << 1,
        ReadOnly = 1 << 2,

        /* 2.0 */
        SvmFineGrainBuffer = 1 << 10,   /* used by cl_svm_mem_flags only */
        SvmAtomics = 1 << 11           /* used by cl_svm_mem_flags only */
    }
}