using System;
using System.Runtime.InteropServices;
using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Enums.Command;
using OpenCL.Types.Core.Net.Primitives;

namespace OpenCL.Core.Net.Native
{
    public class CommandQueueApi
    {
        [Obsolete("Deprecated since OpenCL 2.0")]
        [DllImport(DllNative.Name)]
        public static extern CommandQueue clCreateCommandQueue(Context context, DeviceId device,
            CommandQueueProperties properties, ref Error errcodeRet);

        /* 2.0 */
        [DllImport(DllNative.Name)]
        public static extern CommandQueue clCreateCommandQueueWithProperties(Context context, DeviceId device,
            [In] IntPtr[] properties, ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern CommandQueue clCreateCommandQueueWithProperties(Context context, DeviceId device,
            [In] IntPtr[] properties, IntPtr errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Error clRetainCommandQueue(CommandQueue commandQueue);

        [DllImport(DllNative.Name)]
        public static extern Error clReleaseCommandQueue(CommandQueue commandQueue);

        [DllImport(DllNative.Name)]
        public static extern Error clGetCommandQueueInfo(CommandQueue commandQueue, CommandQueueInfo paramName,
            SizeT paramValueSize, IntPtr paramValue, ref SizeT paramValueSizeRet);

        [Obsolete("Deprecated since OpenCL 1.1")]
        [DllImport(DllNative.Name)]
        public static extern Error clSetCommandQueueProperty(CommandQueue commandQueue,
            CommandQueueProperties properties, Bool enable, ref CommandQueueProperties oldProperties);
    }
}