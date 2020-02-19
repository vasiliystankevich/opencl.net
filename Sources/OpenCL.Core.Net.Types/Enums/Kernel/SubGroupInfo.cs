namespace OpenCL.Types.Core.Net.Enums.Kernel
{
    /* 2.1 */
    // cl_kernel_sub_group_info
    public enum KernelSubGroupInfo : uint
    {
        MaxSubGroupSizeForNdRange = 0x2033,
        SubGroupCountForNdRange = 0x2034,
        LocalSizeForSubGroupCount = 0x11B8
    }
}