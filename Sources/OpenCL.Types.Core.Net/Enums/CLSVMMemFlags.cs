using System;

namespace OpenCL.Types.Core.Net.Enums
{
    /* 2.0 */
    // cl_svm_mem_flags - bitfield
    [Flags]
    public enum CLSVMMemFlags : ulong
    {
        ReadWrite = 1 << 0,
        WriteOnly = 1 << 1,
        ReadOnly = 1 << 2,

        /* 2.0 */
        SVMFineGrainBuffer = 1 << 10,   /* used by cl_svm_mem_flags only */
        SVMAtomics = 1 << 11,           /* used by cl_svm_mem_flags only */
    }
}