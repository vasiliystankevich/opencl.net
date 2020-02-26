using OpenCL.Core.Net.Interfaces.Kernel.Executors;
using OpenCL.Core.Net.Native;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Kernel.Executors
{
    public class FlushNativeExecutor: IFlushNativeExecutor
    {
        public Error Flush(CommandQueue commandQueue) => FlushNative.clFlush(commandQueue);

        public Error Finish(CommandQueue commandQueue) => FlushNative.clFinish(commandQueue);
    }
}
