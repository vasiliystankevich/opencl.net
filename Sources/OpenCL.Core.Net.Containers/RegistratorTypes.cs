using System;
using OpenCL.Core.Net.Api;
using OpenCL.Core.Net.Interfaces;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Kernel.Executors;
using OpenCL.Core.Net.Interfaces.Unity;
using OpenCL.Core.Net.Kernel;
using OpenCL.Core.Net.Kernel.Executors;

namespace OpenCL.Core.Net.Containers
{
    public class RegistratorTypes:IRegistratorTypes
    {
        public RegistratorTypes(IUnityContainerExecutor executor)
        {
            Executor = executor;
        }

        public void RegisterAll()
        {
            RegisterExecutors();
            RegisterKernels();
            RegisterApi();
        }

        void RegisterExecutors()
        {
            Executor.RegisterSingletonFactory<IContextNativeExecutor>(executor => new ContextNativeExecutor());
            Executor.RegisterSingletonFactory<IFlushNativeExecutor>(executor => new FlushNativeExecutor());
        }

        void RegisterKernels()
        {
            Executor.RegisterSingletonFactory<IErrorValidator>(executor => new ErrorValidator());

            RegisterKernel<IContextNativeExecutor, IContextKernel>((executor, validator) =>
                new ContextKernel(executor, validator));
            //RegisterKernel<ICommandQueueKernel>(validator => new CommandQueueKernel(validator));
            //RegisterKernel<IFlushNativeExecutor, IFlushKernel>((executor, validator) => new FlushKernel());
        }

        void RegisterApi()
        {
            Executor.RegisterSingletonFactory<IContextApiFactory>(executor =>
            {
                var kernel = Executor.Resolve<IContextKernel>();
                return new ContextApiFactory(kernel);
            });

            Executor.RegisterSingletonFactory<IQueueApi>(executor =>
            {
                var commandQueue = Executor.Resolve<ICommandQueueKernel>();
                var flush = Executor.Resolve<IFlushKernel>();
                return new QueueApi(commandQueue, flush);
            });
        }

        void RegisterKernel<TNativeExecutor, T>(Func<TNativeExecutor, IErrorValidator, T> functor)
        {
            Executor.RegisterSingletonFactory<T>(executor =>
            {
                var nativeExecutor = Executor.Resolve<TNativeExecutor>(); 
                var errorValidator = Executor.Resolve<IErrorValidator>();
                return functor(nativeExecutor, errorValidator);
            });
        }

        IUnityContainerExecutor Executor { get; }
    }
}