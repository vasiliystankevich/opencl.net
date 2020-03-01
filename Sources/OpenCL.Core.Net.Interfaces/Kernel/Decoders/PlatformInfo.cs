using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Kernel.Decoders
{
    public interface IPlatformInfoDecoder
    {
        string Decode(PlatformId platform, PlatformInfo info, SizeT paramValueSize);
    }
}
