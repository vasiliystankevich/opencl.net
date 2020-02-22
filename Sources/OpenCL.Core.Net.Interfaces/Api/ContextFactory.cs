using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Api
{
    public interface IContextApiFactory
    {
        IContextApi Create(PlatformId platform, DeviceId[] devices);
        IContextApi Create(Context context);
    }
}