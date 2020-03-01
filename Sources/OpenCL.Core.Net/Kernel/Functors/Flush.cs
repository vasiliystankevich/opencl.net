using System;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Kernel.Executors;
using OpenCL.Core.Net.Interfaces.Kernel.Functors;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Interfaces;
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

        public Func<IWrapper<Error>> Flush(IWrapper<CommandQueue> commandQueue) => () =>
        {
            var error = FlushNative.Flush(commandQueue.Arg1);
            return WrapperFactory.Create(error);
        };

        public Func<IWrapper<Error>> Finish(IWrapper<CommandQueue> commandQueue) => () =>
        {
            var error = FlushNative.Finish(commandQueue.Arg1);
            return WrapperFactory.Create(error);
        };

        IFlushNativeExecutor FlushNative { get; }
        IWrapperFactory WrapperFactory { get; }
    }
}