using System;
using System.Runtime.InteropServices;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Kernel.Executors
{
    public interface IPlatformNativeExecutor
    {
        Error GetPlatformIDs(uint numEntries, IntPtr platforms, ref uint numPlatforms);

        Error GetPlatformIDs(uint numEntries, [Out] PlatformId[] platforms,
            ref uint numPlatforms);

        Error GetPlatformInfo(PlatformId platform, PlatformInfo paramName, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet);
    }
}
