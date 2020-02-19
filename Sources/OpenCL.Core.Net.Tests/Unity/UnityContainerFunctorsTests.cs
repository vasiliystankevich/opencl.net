﻿using System;
using Flatter.Serializer.Unity;
using Moq;
using OpenCL.Core.Net.Interfaces.Unity;
using Tests.AAAPattern.xUnit.Attributes;
using Unity;
using Xunit;

namespace OpenCL.Core.Net.Tests.Unity
{
    public class UnityContainerFunctorsTests
    {
        [Theory]
        [MoqAutoData]
        public void GetUnityFactoryFunctorTest(IUnityContainerExecutor executor, Mock<Func<IUnityContainerExecutor, object>> functor, UnityContainerFunctors sut)
        {
            //arrange
            functor.Setup(service => service(executor)).Returns(It.IsAny<object>());

            //act
            var expected = sut.GetUnityFactoryFunctor(executor, functor.Object);

            //assert
            Assert.NotNull(expected);
            Assert.IsType<Func<IUnityContainer, object>>(expected);
            expected(It.IsAny<IUnityContainer>());
            functor.Verify(service => service(executor), Times.AtLeastOnce);
        }
    }
}