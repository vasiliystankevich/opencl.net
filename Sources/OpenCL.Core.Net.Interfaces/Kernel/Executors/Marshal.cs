using System;

namespace OpenCL.Core.Net.Interfaces.Kernel.Executors
{
    public interface IMarshalExecutor
    {
        IntPtr AllocHGlobal(int cb);
        void FreeHGlobal(IntPtr hglobal);
        string PtrToStringAnsi(IntPtr ptr, int len);
    }
}
