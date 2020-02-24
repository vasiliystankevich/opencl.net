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
            RegisterKernel();
            RegisterApi();
        }

        void RegisterKernel()
        {
            Executor.RegisterSingletonFactory<IErrorValidator>(executor => new ErrorValidator());

            Executor.RegisterSingletonFactory<IContextKernel>(executor =>
            {
                var errorValidator = Executor.Resolve<IErrorValidator>();
                return new ContextKernel(errorValidator);
            });

            Executor.RegisterSingletonFactory<ICommandQueueKernel>(executor =>
            {
                var errorValidator = Executor.Resolve<IErrorValidator>();
                return new CommandQueueKernel(errorValidator);
            });

            Executor.RegisterSingletonFactory<IFlushKernel>(executor =>
            {
                var errorValidator = Executor.Resolve<IErrorValidator>();
                return new FlushKernel(errorValidator);
            });
        }

        void RegisterApi()
        {
            Executor.RegisterSingletonFactory<IContextApiFactory>(executor =>
            {
                var kernel = Executor.Resolve<IContextKernel>();
                return new ContextApiFactory(kernel);
            });
        }

        IUnityContainerExecutor Executor { get; }
    }
}