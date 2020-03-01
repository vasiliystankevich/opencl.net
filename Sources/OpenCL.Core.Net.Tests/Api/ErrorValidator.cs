using System;
using FluentAssertions;
using Moq;
using OpenCL.Core.Net.Api;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Interfaces;
using Tests.AAAPattern.xUnit.Attributes;
using Xunit;

namespace OpenCL.Core.Net.Tests.Api
{
    public class ErrorValidatorTests
    {
        [Theory]
        [MoqAutoData]
        public void IsCorrectValidate(Mock<IWrapper<Error>> actual, Mock<Func<IWrapper<Error>>> functor, ErrorValidator sut)
        {
            //arrange
            actual.SetupGet(service => service.Arg1).Returns(Error.Success);
            functor.Setup(service => service()).Returns(actual.Object);

            //act
            sut.Validate(functor.Object);

            //assert
            functor.Verify(service => service(), Times.AtLeastOnce);
            actual.VerifyGet(service => service.Arg1, Times.AtLeastOnce);
        }

        [Theory]
        [MoqAutoData]
        public void IsCorrectValidate_Value1(Mock<IWrapper<Error, int>> actual, Mock<Func<IWrapper<Error, int>>> functor, ErrorValidator sut)
        {
            //arrange
            actual.SetupGet(service => service.Arg1).Returns(Error.Success);
            functor.Setup(service => service()).Returns(actual.Object);

            //act
            var expected = sut.Validate(functor.Object);

            //assert
            functor.Verify(service => service(), Times.AtLeastOnce);
            actual.VerifyGet(service => service.Arg1, Times.AtLeastOnce);
            expected.Should().BeEquivalentTo(actual.Object);
        }

        [Theory]
        [MoqAutoData]
        public void IsCorrectValidate_Value12(Mock<IWrapper<Error, int, int>> actual, Mock<Func<IWrapper<Error, int, int>>> functor, ErrorValidator sut)
        {
            //arrange
            actual.SetupGet(service => service.Arg1).Returns(Error.Success);
            functor.Setup(service => service()).Returns(actual.Object);

            //act
            var expected = sut.Validate(functor.Object);

            //assert
            functor.Verify(service => service(), Times.AtLeastOnce);
            actual.VerifyGet(service => service.Arg1, Times.AtLeastOnce);
            expected.Should().BeEquivalentTo(actual.Object);
        }

        [Theory]
        [MoqInlineAutoData(Error.InvalidOperation)]
        public void IsExceptionValidate(Error actualExceptionValue, Mock<IWrapper<Error>> actual, Mock<Func<IWrapper<Error>>> functor, ErrorValidator sut)
        {
            //arrange
            actual.SetupGet(service => service.Arg1).Returns(actualExceptionValue);
            functor.Setup(service => service()).Returns(actual.Object);

            //act
            var exception = Assert.Throws<Exception>(() => sut.Validate(functor.Object));

            //assert
            functor.Verify(service => service(), Times.AtLeastOnce);
            actual.VerifyGet(service => service.Arg1, Times.AtLeastOnce);
            Assert.Equal(exception.ErrorCode, actualExceptionValue);
        }


        [Theory]
        [MoqInlineAutoData(Error.InvalidOperation)]
        public void IsExceptionValidate_Value1(Error actualExceptionValue, Mock<IWrapper<Error, int>> actual, Mock<Func<IWrapper<Error, int>>> functor, ErrorValidator sut)
        {
            //arrange
            actual.SetupGet(service => service.Arg1).Returns(actualExceptionValue);
            functor.Setup(service => service()).Returns(actual.Object);

            //act
            var exception = Assert.Throws<Exception>(() => sut.Validate(functor.Object));

            //assert
            functor.Verify(service => service(), Times.AtLeastOnce);
            actual.VerifyGet(service => service.Arg1, Times.AtLeastOnce);
            Assert.Equal(exception.ErrorCode, actualExceptionValue);
        }

        [Theory]
        [MoqInlineAutoData(Error.InvalidOperation)]
        public void IsExceptionValidate_Value12(Error actualExceptionValue, Mock<IWrapper<Error, int, int>> actual, Mock<Func<IWrapper<Error, int, int>>> functor, ErrorValidator sut)
        {
            //arrange
            actual.SetupGet(service => service.Arg1).Returns(actualExceptionValue);
            functor.Setup(service => service()).Returns(actual.Object);

            //act
            var exception = Assert.Throws<Exception>(() => sut.Validate(functor.Object));

            //assert
            functor.Verify(service => service(), Times.AtLeastOnce);
            actual.VerifyGet(service => service.Arg1, Times.AtLeastOnce);
            Assert.Equal(exception.ErrorCode, actualExceptionValue);
        }
    }
}