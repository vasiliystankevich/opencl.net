namespace OpenCL.Core.Net.Types.Enums.Program
{
    // cl_program_info
    public enum ProgramInfo : uint
    {
        ReferenceCount = 0x1160,
        Context = 0x1161,
        NumDevices = 0x1162,
        Devices = 0x1163,
        Source = 0x1164,
        BinarySizes = 0x1165,
        Binaries = 0x1166,
        /* 1.2 */
        NumKernels = 0x1167,
        KernelNames = 0x1168,
        /* 2.1 */
        IL = 0x1169,
        /* 2.2 */
        ScopeGlobalCtorsPresent = 0x116A,
        ScopeGlobalDtorsPresent = 0x116B
    }
}