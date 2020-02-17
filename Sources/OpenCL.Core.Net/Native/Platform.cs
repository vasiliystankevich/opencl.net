using System;
using System.Runtime.InteropServices;
using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Primitives;

namespace OpenCL.Core.Net.Native
{
    public class PlatformApi
    {
        [DllImport(Dll.Name)]
        public static extern Error clGetPlatformIDs(uint numEntries, IntPtr platforms, ref uint numPlatforms);

        [DllImport(Dll.Name)]
        public static extern Error clGetPlatformIDs(uint numEntries, [Out] PlatformId[] platforms,
            ref uint numPlatforms);

        [DllImport(Dll.Name)]
        public static extern Error clGetPlatformInfo(PlatformId platform, PlatformInfo paramName, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet);
    }
}