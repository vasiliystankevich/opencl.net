using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Kernel
{
    public interface IFlushKernel
    {
        void Flush(CommandQueue commandQueue);
        void Finish(CommandQueue commandQueue);
    }
}