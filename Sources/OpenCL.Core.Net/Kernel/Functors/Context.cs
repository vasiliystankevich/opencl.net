using System;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Kernel.Executors;
using OpenCL.Core.Net.Interfaces.Kernel.Functors;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Context;
using OpenCL.Core.Net.Types.Enums.Device;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Kernel.Functors
{
    public class ContextNativeFunctor: IContextNativeFunctor
    {
        public ContextNativeFunctor(IContextNativeExecutor contextNative, INativeCallStateFactory stateFactory)
        {
            ContextNative = contextNative;
            StateFactory = stateFactory;
        }

        public Func<NativeCallState<Error, Context>> CreateContext(Wrapper<IntPtr[], uint, DeviceId[], Action<IntPtr, IntPtr, SizeT, IntPtr>, IntPtr> arguments) => () =>
        {
            var error = Error.Success;
            var context = ContextNative.CreateContext(arguments.Arg1, arguments.Arg2, arguments.Arg3, arguments.Arg4,
                arguments.Arg5, ref error);
            return StateFactory.CreateState(error, context);
        };

        //IntPtr[] properties, DeviceType deviceType, Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData
        public Func<NativeCallState<Error, Context>> CreateContextFromType(Wrapper<IntPtr[], DeviceType, Action<IntPtr, IntPtr, SizeT, IntPtr>, IntPtr> arguments) => () =>
        {
            var error = Error.Success;
            var context = ContextNative.CreateContextFromType(arguments.Arg1, arguments.Arg2, arguments.Arg3,
                arguments.Arg4, ref error);
            return StateFactory.CreateState(error, context);
        };

        public Func<NativeCallError<Error>> RetainContext(Wrapper<Context> context) => () =>
        {
            var error = ContextNative.RetainContext(context.Arg1);
            return StateFactory.CreateError(error);
        };

        public Func<Wrapper<Error>> ReleaseContext(Wrapper<Context> context) => () =>
        {
            var error = ContextNative.ReleaseContext(context.Arg1);
            return StateFactory.CreateError(error);
        };

        public Func<NativeCallState<Error, SizeT>> GetContextInfo(Context context, ContextInfo paramName, SizeT paramValueSize, IntPtr paramValue) => () =>
        {
            var paramValueSizeRet = new SizeT();
            var error = ContextNative.GetContextInfo(context, paramName, paramValueSize, paramValue,
                ref paramValueSizeRet);
            return StateFactory.CreateState(error, paramValueSizeRet);
        };

        IContextNativeExecutor ContextNative { get; }
        INativeCallStateFactory StateFactory { get; }
    }
}