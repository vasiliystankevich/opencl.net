using System;
using System.Runtime.InteropServices;
using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Primitives;

namespace OpenCL.Core.Net.Native
{
    /* 2.0 */
    public class SvmAllocationApi
    {
        [DllImport(DllNative.Name)]
        public static extern IntPtr clSVMAlloc(Context context, SvmMemFlags flags, SizeT size, uint alignment);

        [DllImport(DllNative.Name)]
        public static extern void clSVMFree(Context context, IntPtr svmPointer);
    }
}