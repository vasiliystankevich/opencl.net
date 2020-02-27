using System;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Kernel.Functors
{
    public interface IFlushNativeFunctor
    {
        Func<Wrapper<Error>> Flush(Wrapper<CommandQueue> commandQueue);
        Func<Wrapper<Error>> Finish(Wrapper<CommandQueue> commandQueue);
    }
}
