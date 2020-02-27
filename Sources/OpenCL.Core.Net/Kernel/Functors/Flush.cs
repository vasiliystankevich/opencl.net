using System;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Kernel.Executors;
using OpenCL.Core.Net.Interfaces.Kernel.Functors;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Kernel.Functors
{
    public class FlushNativeFunctor: IFlushNativeFunctor
    {
        public FlushNativeFunctor(IFlushNativeExecutor flushNative, INativeCallStateFactory stateFactory)
        {
            FlushNative = flushNative;
            StateFactory = stateFactory;
        }

        public Func<NativeCallError<Error>> Flush(CommandQueue commandQueue) => () =>
        {
            var error = FlushNative.Flush(local);
            return StateFactory.CreateError(error);
        };

        public Func<NativeCallError<Error>> Finish(CommandQueue commandQueue) => () =>
        {
            var error = FlushNative.Finish(local);
            return StateFactory.CreateError(error);
        };

        IFlushNativeExecutor FlushNative { get; }
        INativeCallStateFactory StateFactory { get; }
    }
}