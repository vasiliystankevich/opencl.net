using System;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Kernel.Decoders;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Api
{
    public class PlatformUtilities: IPlatformUtilities
    {
        public PlatformUtilities(IPlatformKernel kernel, IPlatformInfoDecoder decoder)
        {
            Kernel = kernel;
            Decoder = decoder;
        }

        public PlatformId[] GetPlatforms()
        {
            // Check how many platforms are available.
            var numPlatforms = Kernel.GetPlatformIDs(0, IntPtr.Zero);

            if (numPlatforms < 1) return new PlatformId[0];

            // Get the actual platforms once we know their amount.
            var platforms = Kernel.GetPlatformIDs(numPlatforms);
            return platforms.Arg2;
        }

        public string GetPlatformInfo(PlatformId platform, PlatformInfo info)
        {
            var paramValueSize = Kernel.GetPlatformInfo(platform, info, 0, IntPtr.Zero);
            return paramValueSize < 1 ? string.Empty : Decoder.Decode(platform, info, paramValueSize);
        }

        IPlatformKernel Kernel { get; }
        IPlatformInfoDecoder Decoder { get; }
    }
}