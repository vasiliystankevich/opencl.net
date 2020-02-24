using System;
using OpenCL.Core.Net.Api;
using OpenCL.Core.Net.Interfaces;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Unity;
using OpenCL.Core.Net.Kernel;

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
            RegisterKernels();
            RegisterApi();
        }

        void RegisterKernels()
        {
            Executor.RegisterSingletonFactory<IErrorValidator>(executor => new ErrorValidator());

            RegisterKernel<IContextKernel>(validator => new ContextKernel(validator));
            RegisterKernel<ICommandQueueKernel>(validator => new CommandQueueKernel(validator));
            RegisterKernel<IFlushKernel>(validator => new FlushKernel(validator));
        }

        void RegisterApi()
        {
            Executor.RegisterSingletonFactory<IContextApiFactory>(executor =>
            {
                var kernel = Executor.Resolve<IContextKernel>();
                return new ContextApiFactory(kernel);
            });
        }

        void RegisterKernel<T>(Func<IErrorValidator, T> functor)
        {
            Executor.RegisterSingletonFactory<T>(executor =>
            {
                var errorValidator = Executor.Resolve<IErrorValidator>();
                return functor(errorValidator);
            });
        }

        IUnityContainerExecutor Executor { get; }
    }
}