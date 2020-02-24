using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Native;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Kernel
{
    public class FlushKernel:IFlushKernel
    {
        public FlushKernel(IErrorValidator errorValidator)
        {
            ErrorValidator = errorValidator;
        }

        public void Flush(CommandQueue commandQueue) =>
            ErrorValidator.Validate(() => FlushNative.clFlush(commandQueue));

        public void Finish(CommandQueue commandQueue) =>
            ErrorValidator.Validate(() => FlushNative.clFinish(commandQueue));

        IErrorValidator ErrorValidator { get; }
    }
}