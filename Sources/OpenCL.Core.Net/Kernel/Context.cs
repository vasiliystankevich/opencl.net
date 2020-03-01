using System;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Kernel.Functors;
using OpenCL.Core.Net.Types.Enums.Context;
using OpenCL.Core.Net.Types.Enums.Device;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Kernel
{
    public class ContextKernel: IContextKernel
    {
        public ContextKernel(IContextNativeFunctor contextNative, IWrapperFactory wrapperFactory, IErrorValidator errorValidator)
        {
            ContextNative = contextNative;
            WrapperFactory = wrapperFactory;
            ErrorValidator = errorValidator;
        }

        public Context CreateContext(IntPtr[] properties, uint numDevices, DeviceId[] devices,
            Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData)
        {
            var arguments = WrapperFactory.Create(properties, numDevices, devices, pfnNotify, userData);
            var functor = ContextNative.CreateContext(arguments);
            var result = ErrorValidator.Validate(functor);
            return result.Arg2;
        }

        public Context CreateContextFromType(IntPtr[] properties, DeviceType deviceType,
            Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData)
        {
            var arguments = WrapperFactory.Create(properties, deviceType, pfnNotify, userData);
            var functor = ContextNative.CreateContextFromType(arguments);
            var result = ErrorValidator.Validate(functor);
            return result.Arg2;
        }

        public void RetainContext(Context context)
        {
            var arguments = WrapperFactory.Create(context);
            var functor = ContextNative.RetainContext(arguments);
            ErrorValidator.Validate(functor);
        }

        public void ReleaseContext(Context context)
        {
            var arguments = WrapperFactory.Create(context);
            var functor = ContextNative.ReleaseContext(arguments);
            ErrorValidator.Validate(functor);
        }

        public SizeT GetContextInfo(Context context, ContextInfo paramName, SizeT paramValueSize, IntPtr paramValue)
        {
            var arguments = WrapperFactory.Create(context, paramName, paramValueSize, paramValue);
            var functor = ContextNative.GetContextInfo(arguments);
            var result = ErrorValidator.Validate(functor);
            return result.Arg2;
        }

        IContextNativeFunctor ContextNative { get; }
        IWrapperFactory WrapperFactory { get; }
        IErrorValidator ErrorValidator { get; }
    }
}