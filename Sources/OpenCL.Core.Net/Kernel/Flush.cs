using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Kernel.Functors;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Kernel
{
    public class FlushKernel:IFlushKernel
    {
        public FlushKernel(IFlushNativeFunctor flushNative, IWrapperFactory wrapperFactory,
            IErrorValidator errorValidator)
        {
            FlushNative = flushNative;
            WrapperFactory = wrapperFactory;
            ErrorValidator = errorValidator;
        }

        public void Flush(CommandQueue commandQueue)
        {
            var arguments = WrapperFactory.Create(commandQueue);
            var functor = FlushNative.Flush(arguments);
            ErrorValidator.Validate(functor);
        }

        public void Finish(CommandQueue commandQueue)
        {
            var arguments = WrapperFactory.Create(commandQueue);
            var functor = FlushNative.Finish(arguments);
            ErrorValidator.Validate(functor);
        }

        IFlushNativeFunctor FlushNative { get; }
        IWrapperFactory WrapperFactory { get; }
        IErrorValidator ErrorValidator { get; }
    }
}