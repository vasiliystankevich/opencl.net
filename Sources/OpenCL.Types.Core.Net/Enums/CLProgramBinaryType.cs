namespace CASS.OpenCL.Types.Enums
{
    /* 1.2 */
    // cl_program_binary_type
    public enum CLProgramBinaryType : uint
    {
        None = 0x0,
        CompiledObject = 0x1,
        Library = 0x2,
        Executable = 0x4,
    }
}
