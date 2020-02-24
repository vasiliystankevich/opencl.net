using System;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Types.Enums.Command;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Api
{
    public class QueueApi: IQueueApi
    {
        public QueueApi(ICommandQueueKernel commandQueueKernel, IFlushKernel flushKernel)
        {
            CommandQueueKernel = commandQueueKernel;
            FlushKernel = flushKernel;
        }

        [Obsolete("Deprecated since OpenCL 2.0")]
        public CommandQueue CreateCommandQueue(Context context, DeviceId device) =>
            CommandQueueKernel.CreateCommandQueue(context, device, 0);

        [Obsolete("Deprecated since OpenCL 2.0")]
        public CommandQueue CreateCommandQueue(Context context, DeviceId device, CommandQueueProperties properties) =>
            CommandQueueKernel.CreateCommandQueue(context, device, properties);

        public void RetainCommandQueue(CommandQueue commandQueue) => CommandQueueKernel.RetainCommandQueue(commandQueue);

        public void ReleaseCommandQueue(CommandQueue commandQueue) => CommandQueueKernel.ReleaseCommandQueue(commandQueue);

        public void Flush(CommandQueue commandQueue) => FlushKernel.Flush(commandQueue);

        public void Finish(CommandQueue commandQueue) => FlushKernel.Finish(commandQueue);

        ICommandQueueKernel CommandQueueKernel { get; }
        IFlushKernel FlushKernel { get; }
    }
}