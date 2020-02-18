using System;
using System.Runtime.InteropServices;
using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Primitives;

namespace OpenCL.Core.Net.Native
{
    public class ProfilingApi
    {
        [DllImport(DllNative.Name)]
        public static extern Error clGetEventProfilingInfo(Event e, ProfilingInfo paramName, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet);
    }
}