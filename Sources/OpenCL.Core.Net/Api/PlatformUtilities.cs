using System;
using System.Runtime.InteropServices;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Api
{
    public class PlatformUtilities: IPlatformUtilities
    {
        public PlatformUtilities(IPlatformKernel kernel)
        {
            Kernel = kernel;
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
            string result = string.Empty;

            // Get initial size of buffer to allocate.
            var paramValueSize = Kernel.GetPlatformInfo(platform, info, 0, IntPtr.Zero);

            if (paramValueSize < 1) return string.Empty;

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

        IPlatformKernel Kernel { get; }
    }
}