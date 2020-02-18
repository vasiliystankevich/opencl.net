using System.Runtime.InteropServices;
using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Primitives;

namespace OpenCL.Core.Net.Native
{
    public class FlushApi
    {
        [DllImport(DllNative.Name)]
        public static extern Error clFlush(CommandQueue commandQueue);

        [DllImport(DllNative.Name)]
        public static extern Error clFinish(CommandQueue commandQueue);
    }
}