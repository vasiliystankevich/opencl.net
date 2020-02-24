using OpenCL.Core.Net.Types.Enums.Command;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Api
{
    public interface IQueueApi
    {
        CommandQueue CreateCommandQueue(Context context, DeviceId device);
        CommandQueue CreateCommandQueue(Context context, DeviceId device, CommandQueueProperties properties);
        void RetainCommandQueue(CommandQueue commandQueue);
        void ReleaseCommandQueue(CommandQueue commandQueue);
        void Flush(CommandQueue commandQueue);
        void Finish(CommandQueue commandQueue);
    }
}