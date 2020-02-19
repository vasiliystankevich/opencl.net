using System;
using System.Runtime.InteropServices;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Native
{
    public class PlatformApi
    {
        [DllImport(DllNative.Name)]
        public static extern Error clGetPlatformIDs(uint numEntries, IntPtr platforms, ref uint numPlatforms);

        [DllImport(DllNative.Name)]
        public static extern Error clGetPlatformIDs(uint numEntries, [Out] PlatformId[] platforms,
            ref uint numPlatforms);

        [DllImport(DllNative.Name)]
        public static extern Error clGetPlatformInfo(PlatformId platform, PlatformInfo paramName, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet);
    }
}