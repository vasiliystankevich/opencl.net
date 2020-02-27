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

        public Func<NativeCallState<Error, Context>> CreateContext(IntPtr[] properties, uint numDevices, DeviceId[] devices, Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData) => () =>
        {
            var error = Error.Success;
            var context =
                ContextNative.CreateContext(properties, numDevices, devices, pfnNotify, userData, ref error);
            return StateFactory.CreateState(error, context);
        };

        public Func<NativeCallState<Error, Context>> CreateContextFromType(IntPtr[] properties, DeviceType deviceType, Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData) => () =>
        {
            var error = Error.Success;
            var context =
                ContextNative.CreateContextFromType(properties, deviceType, pfnNotify, userData, ref error);
            return StateFactory.CreateState(error, context);
        };

        public Func<NativeCallError<Error>> RetainContext(Context context) => () =>
        {
            var error = ContextNative.RetainContext(context);
            return StateFactory.CreateError(error);
        };

        public Func<NativeCallError<Error>> ReleaseContext(Context context) => () =>
        {
            var error = ContextNative.ReleaseContext(context);
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