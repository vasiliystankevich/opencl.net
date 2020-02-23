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

        public CommandQueue CreateCommandQueue(Context context, DeviceId device, CommandQueueProperties properties) =>
            ErrorValidator.Validate((ref Error error) =>
                CommandQueueNative.clCreateCommandQueue(context, device, properties, ref error));

        public CommandQueue CreateCommandQueueWithProperties(Context context, DeviceId device, IntPtr[] properties)
        {
            throw new NotImplementedException();
        }

        public CommandQueue CreateCommandQueueWithProperties(Context context, DeviceId device, IntPtr[] properties, IntPtr errcodeRet)
        {
            throw new NotImplementedException();
        }

        public Error RetainCommandQueue(CommandQueue commandQueue)
        {
            throw new NotImplementedException();
        }

        public Error ReleaseCommandQueue(CommandQueue commandQueue)
        {
            throw new NotImplementedException();
        }

        public Error GetCommandQueueInfo(CommandQueue commandQueue, CommandQueueInfo paramName, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet)
        {
            throw new NotImplementedException();
        }

        public Error SetCommandQueueProperty(CommandQueue commandQueue, CommandQueueProperties properties, Bool enable,
            ref CommandQueueProperties oldProperties)
        {
            throw new NotImplementedException();
        }
        IErrorValidator ErrorValidator { get; }

    }
}
