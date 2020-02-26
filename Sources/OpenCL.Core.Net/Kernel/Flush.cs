using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Kernel.Executors;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Kernel
{
    public class FlushKernel:IFlushKernel
    {
        public FlushKernel(IFlushNativeExecutor flushNative, IErrorValidator errorValidator)
        {
            FlushNative = flushNative;
            ErrorValidator = errorValidator;
        }

        public void Flush(CommandQueue commandQueue) => ErrorValidator.Validate(() => FlushNative.Flush(commandQueue));

        public void Finish(CommandQueue commandQueue) =>
            ErrorValidator.Validate(() => FlushNative.Finish(commandQueue));

        IFlushNativeExecutor FlushNative { get; }
        IErrorValidator ErrorValidator { get; }
    }
}