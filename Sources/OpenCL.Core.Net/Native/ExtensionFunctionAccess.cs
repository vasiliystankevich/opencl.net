using System;
using System.Runtime.InteropServices;
using OpenCL.Types.Core.Net.Primitives;

namespace OpenCL.Core.Net.Native
{
    public class ExtensionFunctionAccessApi
    {
        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(DllNative.Name)]
        public static extern IntPtr clGetExtensionFunctionAddress(string funcName);

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern IntPtr clGetExtensionFunctionAddressForPlatform(PlatformId platform, string funcName);
    }
}
