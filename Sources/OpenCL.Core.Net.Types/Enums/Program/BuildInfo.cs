namespace OpenCL.Types.Core.Net.Enums.Program
{
    // cl_program_build_info
    public enum ProgramBuildInfo : uint
    {
        Status = 0x1181,
        Options = 0x1182,
        Log = 0x1183,
        /* 1.2 */
        BinaryType = 0x1184,
        /* 2.0 */
        BuildGlobalVariableTotalSize = 0x1185
    }
}