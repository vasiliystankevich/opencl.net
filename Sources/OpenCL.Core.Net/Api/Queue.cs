using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Native;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Command;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Api
{
    public class QueueApi: IQueueApi
    {
        public QueueApi(IErrorValidator errorValidator)
        {
            ErrorValidator = errorValidator;
        }

        public CommandQueue CreateCommandQueue(Context context, DeviceId device)
        {
            return CreateCommandQueue(context, device, 0);
        }

        public CommandQueue CreateCommandQueue(Context context, DeviceId device,
            CommandQueueProperties properties)
        {
            var error= Error.Success;
            var queue = CommandQueueApi.clCreateCommandQueue(context, device, properties, ref error);
            ErrorValidator.Validate(error);

            return queue;
        }

        public void RetainCommandQueue(CommandQueue command_queue)
        {
            clError = CommandQueueApi.clRetainCommandQueue(command_queue);
            ThrowCLException(clError);
        }

        public void ReleaseCommandQueue(CommandQueue command_queue)
        {
            clError = CommandQueueApi.clReleaseCommandQueue(command_queue);
            ThrowCLException(clError);
        }

        public void Flush(CommandQueue command_queue)
        {
            clError = FlushApi.clFlush(command_queue);
            ThrowCLException(clError);
        }

        public void Finish(CommandQueue command_queue)
        {
            clError = FlushApi.clFinish(command_queue);
            ThrowCLException(clError);
        }

        IErrorValidator ErrorValidator { get; }
    }
}