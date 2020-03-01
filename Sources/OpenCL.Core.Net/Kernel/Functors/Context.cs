﻿using System;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Kernel.Executors;
using OpenCL.Core.Net.Interfaces.Kernel.Functors;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Context;
using OpenCL.Core.Net.Types.Enums.Device;
using OpenCL.Core.Net.Types.Interfaces;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Kernel.Functors
{
    public class ContextNativeFunctor: IContextNativeFunctor
    {
        public ContextNativeFunctor(IContextNativeExecutor contextNative, IWrapperFactory wrapperFactory)
        {
            ContextNative = contextNative;
            WrapperFactory = wrapperFactory;
        }

        public Func<IWrapper<Error, Context>> CreateContext(IWrapper<IntPtr[], uint, DeviceId[], Action<IntPtr, IntPtr, SizeT, IntPtr>, IntPtr> arguments) => () =>
        {
            var properties = arguments.Arg1;
            var numDevices = arguments.Arg2;
            var devices = arguments.Arg3;
            var pfnNotify = arguments.Arg4;
            var userData = arguments.Arg5;
            var error = Error.Success;

            var context = ContextNative.CreateContext(properties, numDevices, devices, pfnNotify, userData, ref error);
            return WrapperFactory.Create(error, context);
        };

        public Func<IWrapper<Error, Context>> CreateContextFromType(IWrapper<IntPtr[], DeviceType, Action<IntPtr, IntPtr, SizeT, IntPtr>, IntPtr> arguments) => () =>
        {
            var error = Error.Success;
            var context = ContextNative.CreateContextFromType(arguments.Arg1, arguments.Arg2, arguments.Arg3,
                arguments.Arg4, ref error);
            return WrapperFactory.Create(error, context);
        };

        public Func<IWrapper<Error>> RetainContext(IWrapper<Context> context) => () =>
        {
            var error = ContextNative.RetainContext(context.Arg1);
            return WrapperFactory.Create(error);
        };

        public Func<IWrapper<Error>> ReleaseContext(IWrapper<Context> context) => () =>
        {
            var error = ContextNative.ReleaseContext(context.Arg1);
            return WrapperFactory.Create(error);
        };

        public Func<IWrapper<Error, SizeT>> GetContextInfo(IWrapper<Context, ContextInfo, SizeT, IntPtr> arguments) => () =>
        {
            var paramValueSizeRet = new SizeT();
            var error = ContextNative.GetContextInfo(arguments.Arg1, arguments.Arg2, arguments.Arg3, arguments.Arg4,
                ref paramValueSizeRet);
            return WrapperFactory.Create(error, paramValueSizeRet);
        };

        IContextNativeExecutor ContextNative { get; }
        IWrapperFactory WrapperFactory { get; }
    }
}