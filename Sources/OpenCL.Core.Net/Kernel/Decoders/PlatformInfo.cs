using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Kernel.Decoders;
using OpenCL.Core.Net.Interfaces.Kernel.Executors;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Kernel.Decoders
{
    public class PlatformInfoDecoder : IPlatformInfoDecoder
    {
        public PlatformInfoDecoder(IMarshalExecutor marshal, IPlatformKernel kernel)
        {
            Marshal = marshal;
            Kernel = kernel;
        }

        public string Decode(PlatformId platform, PlatformInfo info, SizeT paramValueSize)
        {
            var result = string.Empty;
            // Allocate native memory to store value.
            var ptr = Marshal.AllocHGlobal(paramValueSize);

            // Protect following statements with try-finally in case something 
            // goes wrong.
            try
            {
                // Get actual value.
                var resultSize = Kernel.GetPlatformInfo(platform, info, paramValueSize, ptr);

                switch (info)
                {
                    case PlatformInfo.Profile:
                        result = Marshal.PtrToStringAnsi(ptr, resultSize);
                        break;
                    case PlatformInfo.Version:
                        result = Marshal.PtrToStringAnsi(ptr, resultSize);
                        break;
                    case PlatformInfo.Name:
                        result = Marshal.PtrToStringAnsi(ptr, resultSize);
                        break;
                    case PlatformInfo.Vendor:
                        result = Marshal.PtrToStringAnsi(ptr, resultSize);
                        break;
                    case PlatformInfo.Extensions:
                        result = Marshal.PtrToStringAnsi(ptr, resultSize);
                        break;
                }
            }
            finally
            {
                // Free native buffer.
                Marshal.FreeHGlobal(ptr);
            }
            return result;
        }

        IMarshalExecutor Marshal { get; }
        IPlatformKernel Kernel { get; }
    }
}