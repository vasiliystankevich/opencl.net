using System;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Native;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Context;
using OpenCL.Core.Net.Types.Enums.Device;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Kernel
{
    public class ContextKernel: IContextKernel
    {
        public ContextKernel(IResultNativeCallFactory resultNativeCallFactory, IErrorValidator errorValidator)
        {
            ResultNativeCallFactory = resultNativeCallFactory;
            ErrorValidator = errorValidator;
        }

        public Context CreateContext(IntPtr[] properties, uint numDevices, DeviceId[] devices,
            Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData) => ErrorValidator.Validate(() =>
        {
            var error = Error.Success;
            var context =
                ContextNative.clCreateContext(properties, numDevices, devices, pfnNotify, userData, ref error);
            return ResultNativeCallFactory.Create(context, error);
        });

        public Context CreateContextFromType(IntPtr[] properties, DeviceType deviceType,
            Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData, ref Error errcodeRet) =>
            ContextNative.clCreateContextFromType(properties, deviceType, pfnNotify, userData, ref errcodeRet);

        public Error RetainContext(Context context) => ContextNative.clRetainContext(context);

        public Error ReleaseContext(Context context) => ContextNative.clReleaseContext(context);

        public Error GetContextInfo(Context context, ContextInfo paramName, SizeT paramValueSize, IntPtr paramValue,
            ref SizeT paramValueSizeRet) => ContextNative.clGetContextInfo(context, paramName, paramValueSize,
            paramValue, ref paramValueSizeRet);

        IResultNativeCallFactory ResultNativeCallFactory { get; }
        IErrorValidator ErrorValidator { get; }
    }
}