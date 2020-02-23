using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Api
{
    public class ContextApiFactory: IContextApiFactory
    {
        public ContextApiFactory(IContextKernel kernel)
        {
            Kernel = kernel;
        }

        public IContextApi Create(PlatformId platform, DeviceId[] devices) => new ContextApi(Kernel, platform, devices);

        public IContextApi Create(Context context) => new ContextApi(Kernel, context);

        IContextKernel Kernel { get; }
    }
}
