using OpenCL.Core.Net.Interfaces;
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
            Executor.RegisterSingletonFactory<IContextKernel>(executor => new ContextKernel());
        }

        void RegisterApi()
        {
            Executor.RegisterSingletonFactory<IErrorValidator>(executor => new ErrorValidator());

            //Executor.
        }

        IUnityContainerExecutor Executor { get; }
    }
}