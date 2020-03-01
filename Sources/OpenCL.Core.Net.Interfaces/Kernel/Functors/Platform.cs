using System;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Interfaces;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Kernel.Functors
{
    public interface IPlatformNativeFunctor
    {
        Func<IWrapper<Error, uint>> GetPlatformIDs(IWrapper<uint, IntPtr> numEntries);

        Func<IWrapper<Error, PlatformId[], uint>> GetPlatformIDs(IWrapper<uint> numEntries);

        Func<IWrapper<Error, SizeT>> GetPlatformInfo(IWrapper<PlatformId, PlatformInfo, SizeT, IntPtr> arguments);
    }
}