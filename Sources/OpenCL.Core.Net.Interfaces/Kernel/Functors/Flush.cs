using System;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Kernel.Functors
{
    public interface IFlushNativeFunctor
    {
        Func<NativeCallError<Error>> Flush(CommandQueue commandQueue);
        Func<NativeCallError<Error>> Finish(CommandQueue commandQueue);
    }
}
