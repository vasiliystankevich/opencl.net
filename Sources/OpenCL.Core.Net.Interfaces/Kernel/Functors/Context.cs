using System;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Context;
using OpenCL.Core.Net.Types.Enums.Device;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Kernel.Functors
{
    public interface IContextNativeFunctor
    {
        Func<NativeCallState<Error, Context>> CreateContext(Wrapper<IntPtr[], uint, DeviceId[], Action<IntPtr, IntPtr, SizeT, IntPtr>, IntPtr> arguments);

        Func<NativeCallState<Error, Context>> CreateContextFromType(Wrapper<IntPtr[], DeviceType, Action<IntPtr, IntPtr, SizeT, IntPtr>, IntPtr> arguments);

        Func<NativeCallError<Error>> RetainContext(Wrapper<Context> context);

        Func<NativeCallError<Error>> ReleaseContext(Wrapper<Context> context);

        Func<NativeCallState<Error, SizeT>> GetContextInfo(Context context, ContextInfo paramName, SizeT paramValueSize, IntPtr paramValue);
    }
}