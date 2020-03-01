using System;
using System.Runtime.InteropServices;
using OpenCL.Core.Net.Interfaces.Kernel.Executors;

namespace OpenCL.Core.Net.Kernel.Executors
{
    public class MarshalExecutor : IMarshalExecutor
    {
        public IntPtr AllocHGlobal(int cb) => Marshal.AllocHGlobal(cb);

        public void FreeHGlobal(IntPtr hglobal) => Marshal.FreeHGlobal(hglobal);

        public string PtrToStringAnsi(IntPtr ptr, int len) => Marshal.PtrToStringAnsi(ptr, len);
    }
}
