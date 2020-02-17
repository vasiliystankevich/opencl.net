namespace OpenCL.Types.Core.Net.Enums
{
    // cl_kernel_work_group_info
    public enum CLKernelWorkGroupInfo : uint
    {
        WorkGroupSize = 0x11B0,
        CompileWithWorkGroupSize = 0x11B1,
        LocalMemSize = 0x11B2,
        /* 1.1 */
        PreferredWorkGroupSizeMultiple = 0x11B3,
        PrivateMemSize = 0x11B4,
        /* 1.2 */
        GlobalWorkSize = 0x11B5,
    }
}