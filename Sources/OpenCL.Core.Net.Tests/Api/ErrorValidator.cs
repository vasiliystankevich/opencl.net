using AutoFixture.Xunit2;
using Moq;
using OpenCL.Core.Net.Api;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;
using Tests.AAAPattern.xUnit.Attributes;
using Xunit;

namespace OpenCL.Core.Net.Tests.Api
{
    public class ErrorValidatorTests
    {
        [Theory]
        [MoqAutoData]
        public void NativeFuncValidateExecuteTest(Mock<NativeFunc> functor, ErrorValidator sut)
        {
            //arrange
            functor.Setup(service => service()).Returns(Error.Success);

            //act
            //sut.Validate(functor.Object);

            //assert
            functor.Verify(service=>service(), Times.AtLeastOnce);
        }

        [Theory]
        [MoqInlineAutoData(Error.InvalidOperation)]
        public void NativeFuncValidateExceptionTest(Error actual, Mock<NativeFunc> functor, ErrorValidator sut)
        {
            //arrange
            functor.Setup(service => service()).Returns(actual);

            //act
            //var expected = Assert.Throws<Exception>(() => sut.Validate(functor.Object));

            //assert
            functor.Verify(service => service(), Times.AtLeastOnce);
            //Assert.Equal(expected.ErrorCode, actual);
        }

        [Theory]
        [MoqAutoData]
        public void NativeFunc1RefValidateExecuteTest(SizeT data, Mock<NativeFunc1Ref<SizeT, Error>> functor, ErrorValidator sut)
        {
            //arrange
            functor.Setup(service => service(ref It.Ref<SizeT>.IsAny)).Returns(Error.Success);

            //act
            sut.Validate(ref data, functor.Object);

            //assert
            functor.Verify(service => service.Invoke(ref It.Ref<SizeT>.IsAny), Times.AtLeastOnce);
        }

        [Theory]
        [MoqInlineAutoData(Error.InvalidOperation)]
        public void NativeFunc1RefValidateExceptionTest(Error actual, SizeT data, [Frozen]Mock<NativeFunc1Ref<SizeT, Error>> functor, ErrorValidator sut)
        {
            //arrange
            functor.Setup(service => service(ref It.Ref<SizeT>.IsAny)).Returns(actual);

            //act
            var expected = Assert.Throws<Exception>(() => sut.Validate(ref data, functor.Object));

            //assert
            functor.Verify(service => service.Invoke(ref It.Ref<SizeT>.IsAny), Times.AtLeastOnce);
            Assert.Equal(expected.ErrorCode, actual);
        }

        //[Theory]
        //[MoqInlineAutoData(Error.InvalidOperation)]
        //public void ValidateExceptionTest(Error actual, Mock<NativeFunc> functor, ErrorValidator sut)
        //{
        //    //arrange
        //    functor.Setup(service => service()).Returns(actual);

        //    //act
        //    var expected = Assert.Throws<Exception>(() => sut.Validate(functor.Object));

        //    //assert
        //    functor.Verify(service => service(), Times.AtLeastOnce);
        //    Assert.Equal(expected.ErrorCode, actual);
        //}

        //public void Validate(ref SizeT size, NativeFunc1Ref<SizeT, Error> functor)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Validate(ref CommandQueueProperties properties, NativeFunc1Ref<CommandQueueProperties, Error> functor)
        //{
        //    throw new NotImplementedException();
        //}

        //public TValue Validate<TValue>(NativeFunc1Ref<Error, TValue> functor)
        //{
        //    throw new NotImplementedException();
        //}

        //public TValue Validate<TArg1, TValue>(ref TArg1 arg1, NativeFunc2Ref<TArg1, Error, TValue> functor)
        //{
        //    throw new NotImplementedException();
        //}

        //public CommandQueue Validate(NativeFunc1Arg<IntPtr, CommandQueue> functor)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
