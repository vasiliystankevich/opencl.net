using System;
using System.Runtime.InteropServices;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Native
{
    public class ProfilingApi
    {
        [DllImport(DllNative.Name)]
        public static extern Error clGetEventProfilingInfo(Event e, ProfilingInfo paramName, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet);
    }
}