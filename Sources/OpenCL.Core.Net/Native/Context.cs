using System;
using System.Runtime.InteropServices;
using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Enums.Context;
using OpenCL.Types.Core.Net.Enums.Device;
using OpenCL.Types.Core.Net.Primitives;

namespace OpenCL.Core.Net.Native
{
    public class ContextApi
    {
        [DllImport(DllNative.Name)]
        public static extern Context clCreateContext([In] IntPtr[] properties, uint numDevices,
            [In] DeviceId[] devices, Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData,
            ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Context clCreateContextFromType([In] IntPtr[] properties, DeviceType deviceType,
            Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData, ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Error clRetainContext(Context context);

        [DllImport(DllNative.Name)]
        public static extern Error clReleaseContext(Context context);

        [DllImport(DllNative.Name)]
        public static extern Error clGetContextInfo(Context context, ContextInfo paramName, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet);
    }
}