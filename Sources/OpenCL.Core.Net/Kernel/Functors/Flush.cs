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
        public FlushNativeFunctor(IFlushNativeExecutor flushNative, IWrapperFactory wrapperFactory)
        {
            FlushNative = flushNative;
            WrapperFactory = wrapperFactory;
        }

        public Func<Wrapper<Error>> Flush(Wrapper<CommandQueue> commandQueue) => () =>
        {
            var error = FlushNative.Flush(commandQueue.Arg1);
            return WrapperFactory.Create(error);
        };

        public Func<Wrapper<Error>> Finish(Wrapper<CommandQueue> commandQueue) => () =>
        {
            var error = FlushNative.Finish(commandQueue.Arg1);
            return WrapperFactory.Create(error);
        };

        IFlushNativeExecutor FlushNative { get; }
        IWrapperFactory WrapperFactory { get; }
    }
}