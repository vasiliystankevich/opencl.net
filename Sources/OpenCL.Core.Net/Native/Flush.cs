using System.Runtime.InteropServices;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Native
{
    public class FlushNative
    {
        [DllImport(DllNative.Name)]
        public static extern Error clFlush(CommandQueue commandQueue);

        [DllImport(DllNative.Name)]
        public static extern Error clFinish(CommandQueue commandQueue);
    }
}