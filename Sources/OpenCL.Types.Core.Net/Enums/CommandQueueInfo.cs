namespace OpenCL.Types.Core.Net.Enums
{
    // cl_command_queue_info
    public enum CommandQueueInfo : uint
    {
        Context = 0x1090,
        Device = 0x1091,
        ReferenceCount = 0x1092,
        Properties = 0x1093,
        /* 2.0 */
        Size = 0x1094,
        /* 2.1 */
        DeviceDefault = 0x1095
    }
}