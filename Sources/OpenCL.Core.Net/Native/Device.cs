using System;
using System.Runtime.InteropServices;
using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Enums.Device;
using OpenCL.Types.Core.Net.Primitives;

namespace OpenCL.Core.Net.Native
{
    public class DeviceApi
    {
        [DllImport(DllNative.Name)]
        public static extern Error clGetDeviceIDs(PlatformId platformId, DeviceType deviceType, uint numEntries,
            [Out] DeviceId[] devices, ref uint numDevices);

        [DllImport(DllNative.Name)]
        public static extern Error clGetDeviceIDs(PlatformId platformId, DeviceType deviceType, uint numEntries,
            IntPtr devices, ref uint numDevices);

        [DllImport(DllNative.Name)]
        public static extern Error clGetDeviceInfo(DeviceId device, DeviceInfo paramName, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet);

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern Error clCreateSubDevices(DeviceId inDevice, [In] IntPtr[] properties, uint numDevices,
            [In, Out] DeviceId[] outDevices, ref uint numDevicesRet);

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern Error clRetainDevice(DeviceId device);

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern Error clReleaseDevice(DeviceId device);

        /* 2.1 */
        [DllImport(DllNative.Name)]
        public static extern Error clSetDefaultDeviceCommandQueue(Context context, DeviceId device,
            CommandQueue commandQueue);

        /* 2.1 */
        [DllImport(DllNative.Name)]
        public static extern Error clGetDeviceAndHostTimer(DeviceId device, ref ulong deviceTimestamp,
            ref ulong hostTimestamp);

        /* 2.1 */
        [DllImport(DllNative.Name)]
        public static extern Error clGetHostTimer(DeviceId device, ref ulong hostTimestamp);
    }
}