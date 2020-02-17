namespace OpenCL.Types.Core.Net.Enums
{
    /* 2.1 */
    // cl_kernel_sub_group_info
    public enum CLKernelSubGroupInfo : uint
    {
        MaxSubGroupSizeForNDRange = 0x2033,
        SubGroupCountForNDRange = 0x2034,
        LocalSizeForSubGroupCount = 0x11B8,
    }
}