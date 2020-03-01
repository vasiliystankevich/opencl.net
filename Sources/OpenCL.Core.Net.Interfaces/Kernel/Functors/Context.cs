using System;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Context;
using OpenCL.Core.Net.Types.Enums.Device;
using OpenCL.Core.Net.Types.Interfaces;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Kernel.Functors
{
    public interface IContextNativeFunctor
    {
        Func<IWrapper<Error, Context>> CreateContext(IWrapper<IntPtr[], uint, DeviceId[], Action<IntPtr, IntPtr, SizeT, IntPtr>, IntPtr> arguments);

        Func<IWrapper<Error, Context>> CreateContextFromType(IWrapper<IntPtr[], DeviceType, Action<IntPtr, IntPtr, SizeT, IntPtr>, IntPtr> arguments);

        Func<IWrapper<Error>> RetainContext(IWrapper<Context> context);

        Func<IWrapper<Error>> ReleaseContext(IWrapper<Context> context);

        Func<IWrapper<Error, SizeT>> GetContextInfo(IWrapper<Context, ContextInfo, SizeT, IntPtr> arguments);
    }
}