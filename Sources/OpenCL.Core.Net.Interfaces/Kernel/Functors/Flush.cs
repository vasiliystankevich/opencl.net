using System;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Interfaces;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Kernel.Functors
{
    public interface IFlushNativeFunctor
    {
        Func<IWrapper<Error>> Flush(IWrapper<CommandQueue> commandQueue);
        Func<IWrapper<Error>> Finish(IWrapper<CommandQueue> commandQueue);
    }
}