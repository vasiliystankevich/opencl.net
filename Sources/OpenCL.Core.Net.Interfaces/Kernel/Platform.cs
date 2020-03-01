using System;
using System.Runtime.InteropServices;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Kernel
{
    public interface IPlatformKernel
    {
        uint GetPlatformIDs(uint numEntries, IntPtr platforms);

        PlatformId[] GetPlatformIDs(uint numEntries);

        SizeT GetPlatformInfo(PlatformId platform, PlatformInfo paramName, SizeT paramValueSize, IntPtr paramValue);
    }
}
