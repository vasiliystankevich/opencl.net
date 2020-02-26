using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Kernel.Executors
{
    public interface IFlushNativeExecutor
    {
        Error Flush(CommandQueue commandQueue);
        Error Finish(CommandQueue commandQueue);
    }
}
