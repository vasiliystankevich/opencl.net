using System.Linq;
using OpenCL.Core.Net.Containers;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Types.Enums.Context;
using Project.Kernel;
using Unity;
using Unity.Interception.Utilities;
using Xunit;

namespace OpenCL.Core.Net.Tests.Api
{
    public class ContextApiTests
    {
        [Fact]
        public void Z1()
        {
            //arrange
            var container = UnityConfig.GetConfiguredContainer();
            BaseTypeFabric.RegisterTypes<TypeFabric>(container);

            //act
            var factory = container.Resolve<IContextApiFactory>();

            var contexts = OldKernel.GetPlatforms().Select(platform =>
            {
                var devices = OldKernel.GetDevices(platform);
                return factory.Create(platform, devices);
            });

            //var info = new ContextInfo();
            //sut.GetContextInfo(info);
        }
    }
}
