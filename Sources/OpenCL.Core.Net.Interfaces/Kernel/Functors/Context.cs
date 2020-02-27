using System;
using System.Runtime.InteropServices;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Context;
using OpenCL.Core.Net.Types.Enums.Device;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Kernel.Functors
{
    public interface IContextNativeFunctor
    {
        Func<NativeCallState<Error, Context>> CreateContext([In] IntPtr[] properties, uint numDevices,
            [In] DeviceId[] devices, Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData);

        Func<NativeCallState<Error, Context>> CreateContextFromType([In] IntPtr[] properties, DeviceType deviceType,
            Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData);

        Func<NativeCallError<Error>> RetainContext(Context context);

        Func<NativeCallError<Error>> ReleaseContext(Context context);

        Func<NativeCallState<Error, SizeT>> GetContextInfo(Context context, ContextInfo paramName, SizeT paramValueSize, IntPtr paramValue);
    }
}