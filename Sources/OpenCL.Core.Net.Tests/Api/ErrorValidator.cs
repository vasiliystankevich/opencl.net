using Moq;
using OpenCL.Core.Net.Api;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;
using Tests.AAAPattern.xUnit.Attributes;
using Xunit;

namespace OpenCL.Core.Net.Tests.Api
{
    public class ErrorValidatorTests
    {
        [Theory]
        [MoqAutoData]
        public void ValidateExecuteTest(Mock<NativeFunc> functor, ErrorValidator sut)
        {
            //arrange
            functor.Setup(service => service()).Returns(Error.Success);

            //act
            sut.Validate(functor.Object);

            //assert
            functor.Verify(service=>service(), Times.AtLeastOnce);
        }

        [Theory]
        [MoqInlineAutoData(Error.InvalidOperation)]
        public void ValidateExceptionTest(Error actual, Mock<NativeFunc> functor, ErrorValidator sut)
        {
            //arrange
            functor.Setup(service => service()).Returns(actual);

            //act
            var expected = Assert.Throws<Exception>(() => sut.Validate(functor.Object));

            //assert
            functor.Verify(service => service(), Times.AtLeastOnce);
            Assert.Equal(expected.ErrorCode, actual);
        }

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
