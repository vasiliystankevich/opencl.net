namespace OpenCL.Core.Net.Types.Enums.Program
{
    /* 1.2 */
    // cl_program_binary_type
    public enum ProgramBinaryType : uint
    {
        None = 0x0,
        CompiledObject = 0x1,
        Library = 0x2,
        Executable = 0x4
    }
}