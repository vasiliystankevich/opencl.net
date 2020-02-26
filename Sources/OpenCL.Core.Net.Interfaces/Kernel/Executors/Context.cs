using System;
using System.Runtime.InteropServices;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Context;
using OpenCL.Core.Net.Types.Enums.Device;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Kernel.Executors
{
    public interface IContextNativeExecutor
    {
        Context CreateContext([In] IntPtr[] properties, uint numDevices, [In] DeviceId[] devices,
            Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData, ref Error errcodeRet);

        Context CreateContextFromType([In] IntPtr[] properties, DeviceType deviceType,
            Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData, ref Error errcodeRet);

        Error RetainContext(Context context);

        Error ReleaseContext(Context context);

        Error GetContextInfo(Context context, ContextInfo paramName, SizeT paramValueSize, IntPtr paramValue,
            ref SizeT paramValueSizeRet);
    }
}
