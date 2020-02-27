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
        Func<Wrapper<Error, Context>> CreateContext(Wrapper<IntPtr[], uint, DeviceId[], Action<IntPtr, IntPtr, SizeT, IntPtr>, IntPtr> arguments);

        Func<Wrapper<Error, Context>> CreateContextFromType(Wrapper<IntPtr[], DeviceType, Action<IntPtr, IntPtr, SizeT, IntPtr>, IntPtr> arguments);

        Func<Wrapper<Error>> RetainContext(Wrapper<Context> context);

        Func<Wrapper<Error>> ReleaseContext(Wrapper<Context> context);

        Func<Wrapper<Error, SizeT>> GetContextInfo(Wrapper<Context, ContextInfo, SizeT, IntPtr> arguments);
    }
}