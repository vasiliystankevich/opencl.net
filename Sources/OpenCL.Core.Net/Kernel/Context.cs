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
        public ContextKernel(IErrorValidator errorValidator)
        {
            ErrorValidator = errorValidator;
        }

        public Context CreateContext(IntPtr[] properties, uint numDevices, DeviceId[] devices,
            Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData) => ErrorValidator.Validate((ref Error error) =>
            ContextNative.clCreateContext(properties, numDevices, devices, pfnNotify, userData, ref error));

        public Context CreateContextFromType(IntPtr[] properties, DeviceType deviceType,
            Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData) => ErrorValidator.Validate((ref Error error) =>
            ContextNative.clCreateContextFromType(properties, deviceType, pfnNotify, userData, ref error));

        public void RetainContext(Context context) => ErrorValidator.Validate(() => ContextNative.clRetainContext(context));

        public void ReleaseContext(Context context) => ErrorValidator.Validate(() => ContextNative.clReleaseContext(context));

        public void GetContextInfo(Context context, ContextInfo paramName, SizeT paramValueSize, IntPtr paramValue,
            ref SizeT paramValueSizeRet) => ErrorValidator.Validate(ref paramValueSizeRet,
            (ref SizeT size) =>
                ContextNative.clGetContextInfo(context, paramName, paramValueSize, paramValue, ref size));

        IErrorValidator ErrorValidator { get; }
    }
}