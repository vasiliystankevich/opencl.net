namespace OpenCL.Types.Core.Net.Enums
{
    // cl_command_type
    public enum CommandType : uint
    {
        NdRangeKernel = 0x11F0,
        Task = 0x11F1,
        NativeKernel = 0x11F2,
        ReadBuffer = 0x11F3,
        WriteBuffer = 0x11F4,
        CopyBuffer = 0x11F5,
        ReadImage = 0x11F6,
        WriteImage = 0x11F7,
        CopyImage = 0x11F8,
        CopyImageToBuffer = 0x11F9,
        CopyBufferToImage = 0x11FA,
        MapBuffer = 0x11FB,
        MapImage = 0x11FC,
        UnmapMemObject = 0x11FD,
        Marker = 0x11FE,
        AcquireGlObjects = 0x11FF,
        ReleaseGlObjects = 0x1200,
        /* 1.1 */
        ReadBufferRect = 0x1201,
        WriteBufferRect = 0x1202,
        CopyBufferRect = 0x1203,
        User = 0x1204,
        /* 1.2 */
        Barrier = 0x1205,
        MigrateMemObjects = 0x1206,
        FillBuffer = 0x1207,
        FillImage = 0x1208,
        /* 2.0 */
        SvmFree = 0x1209,
        SvmMemcpy = 0x120A,
        SvmMemFill = 0x120B,
        SvmMap = 0x120C,
        SvmUnmap = 0x120D
    }
}