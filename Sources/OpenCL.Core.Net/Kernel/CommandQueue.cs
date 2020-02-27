using System;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Native;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Command;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Kernel
{
    public class CommandQueueKernel: ICommandQueueKernel
    {
        public CommandQueueKernel(IErrorValidator errorValidator)
        {
            ErrorValidator = errorValidator;
        }

        [Obsolete("Deprecated since OpenCL 2.0")]
        public CommandQueue CreateCommandQueue(Context context, DeviceId device, CommandQueueProperties properties) =>
            ErrorValidator.Validate((ref Error error) =>
                CommandQueueNative.clCreateCommandQueue(context, device, properties, ref error));

        public CommandQueue CreateCommandQueueWithProperties(Context context, DeviceId device, IntPtr[] properties) =>
            ErrorValidator.Validate((ref Error error) =>
                CommandQueueNative.clCreateCommandQueueWithProperties(context, device, properties, ref error));

        public CommandQueue CreateCommandQueueWithPropertiesIntPtr(Context context, DeviceId device, IntPtr[] properties) => ErrorValidator.Validate(error =>
            CommandQueueNative.clCreateCommandQueueWithProperties(context, device, properties, error));

        public void RetainCommandQueue(CommandQueue commandQueue)
        {
            ErrorValidator.Validate(() =>
            {
                var error = CommandQueueNative.clRetainCommandQueue(commandQueue);
                return NativeCallStateFactory.CreateError(error);
            });
        }

        public void ReleaseCommandQueue(CommandQueue commandQueue) =>
            ErrorValidator.Validate(() =>
            {
                var error = CommandQueueNative.clReleaseCommandQueue(commandQueue);
                return NativeCallStateFactory.CreateError(error);
            });

        public void GetCommandQueueInfo(CommandQueue commandQueue, CommandQueueInfo paramName, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet) => ErrorValidator.Validate(ref paramValueSizeRet,
            (ref SizeT retValue) =>
                CommandQueueNative.clGetCommandQueueInfo(commandQueue, paramName, paramValueSize, paramValue,
                    ref retValue));

        [Obsolete("Deprecated since OpenCL 1.1")]
        public void SetCommandQueueProperty(CommandQueue commandQueue, CommandQueueProperties properties, Bool enable,
            ref CommandQueueProperties oldProperties) => ErrorValidator.Validate(ref oldProperties,
                (ref CommandQueueProperties queueProperties) =>
                    CommandQueueNative.clSetCommandQueueProperty(commandQueue, properties, enable,
                        ref queueProperties));

        INativeCallStateFactory NativeCallStateFactory { get; }
        IErrorValidator ErrorValidator { get; }
    }
}