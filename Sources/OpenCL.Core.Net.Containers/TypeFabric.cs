using Flatter.Serializer.Interfaces.Unity;
using Flatter.Serializer.Unity;
using OpenCL.Core.Net.Containers.Unity;
using OpenCL.Core.Net.Interfaces;
using OpenCL.Core.Net.Interfaces.Unity;
using Project.Kernel;
using Unity;

namespace OpenCL.Core.Net.Containers
{
    public class TypeFabric : BaseTypeFabric
    {
        public override void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUnityContainerExecutor, UnityContainerExecutor>();
            container.RegisterType<IUnityContainerFunctors, UnityContainerFunctors>();
            container.RegisterType<IRegistratorTypes, RegistratorTypes>();

            var registrator = container.Resolve<IRegistratorTypes>();
            registrator.RegisterAll();
        }
    }
}