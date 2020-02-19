using System;
using OpenCL.Core.Net.Interfaces.Unity;
using Unity;

namespace Flatter.Serializer.Interfaces.Unity
{
    public interface IUnityContainerFunctors
    {
        Func<IUnityContainer, object> GetUnityFactoryFunctor(IUnityContainerExecutor sender,
            Func<IUnityContainerExecutor, object> functor);
    }
}
