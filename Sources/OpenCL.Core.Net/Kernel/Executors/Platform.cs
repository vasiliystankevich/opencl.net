using System;
using OpenCL.Core.Net.Interfaces.Kernel.Executors;
using OpenCL.Core.Net.Native;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Kernel.Executors
{
    public class PlatformNativeExecutor : IPlatformNativeExecutor
    {
        public Error GetPlatformIDs(uint numEntries, IntPtr platforms, ref uint numPlatforms) => PlatformApi.clGetPlatformIDs(numEntries, platforms, ref numPlatforms);

        public Error GetPlatformIDs(uint numEntries, PlatformId[] platforms, ref uint numPlatforms) => PlatformApi.clGetPlatformIDs(numEntries, platforms, ref numPlatforms);

        public Error GetPlatformInfo(PlatformId platform, PlatformInfo paramName, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet) => PlatformApi.clGetPlatformInfo(platform, paramName,
            paramValueSize, paramValue, ref paramValueSizeRet);
    }
}