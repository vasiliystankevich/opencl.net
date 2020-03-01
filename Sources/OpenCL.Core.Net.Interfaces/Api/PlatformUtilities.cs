using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Api
{
    public interface IPlatformUtilities
    {
        PlatformId[] GetPlatforms();
        string GetPlatformInfo(PlatformId platform, PlatformInfo info);
    }
}