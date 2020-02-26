using System;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Kernel.Executors;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Context;
using OpenCL.Core.Net.Types.Enums.Device;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Kernel
{
    public class ContextKernel: IContextKernel
    {
        public ContextKernel(IContextNativeExecutor contextNative, IErrorValidator errorValidator)
        {
            ContextNative = contextNative;
            ErrorValidator = errorValidator;
        }

        public Context CreateContext(IntPtr[] properties, uint numDevices, DeviceId[] devices,
            Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData) => ErrorValidator.Validate((ref Error error) =>
            ContextNative.CreateContext(properties, numDevices, devices, pfnNotify, userData, ref error));

        public Context CreateContextFromType(IntPtr[] properties, DeviceType deviceType,
            Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData) => ErrorValidator.Validate((ref Error error) =>
            ContextNative.CreateContextFromType(properties, deviceType, pfnNotify, userData, ref error));

        public void RetainContext(Context context) => ErrorValidator.Validate(() => ContextNative.RetainContext(context));

        public void ReleaseContext(Context context) => ErrorValidator.Validate(() => ContextNative.ReleaseContext(context));

        public void GetContextInfo(Context context, ContextInfo paramName, SizeT paramValueSize, IntPtr paramValue,
            ref SizeT paramValueSizeRet) => ErrorValidator.Validate(ref paramValueSizeRet,
            (ref SizeT size) =>
                ContextNative.GetContextInfo(context, paramName, paramValueSize, paramValue, ref size));

        IContextNativeExecutor ContextNative { get; }
        IErrorValidator ErrorValidator { get; }
    }
}