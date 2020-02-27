using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Kernel;
using OpenCL.Core.Net.Api;
using OpenCL.Core.Net.Containers;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Types.Enums.Context;
using Project.Kernel;
using Unity;
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
            
            var info = new ContextInfo();
            var sut = container.Resolve<IContextApi>();
            sut.GetContextInfo(info);
        }
    }
}
