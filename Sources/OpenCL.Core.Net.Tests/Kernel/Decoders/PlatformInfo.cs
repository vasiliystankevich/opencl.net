using System;
using AutoFixture.Xunit2;
using Moq;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Kernel.Executors;
using OpenCL.Core.Net.Kernel.Decoders;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;
using Tests.AAAPattern.xUnit.Attributes;
using Xunit;

namespace OpenCL.Core.Net.Tests.Kernel.Decoders
{
    public class PlatformInfoDecoderTests
    {
        [Theory]
        [MoqInlineAutoData(PlatformInfo.Profile)]
        [MoqInlineAutoData(PlatformInfo.Version)]
        [MoqInlineAutoData(PlatformInfo.Name)]
        [MoqInlineAutoData(PlatformInfo.Vendor)]
        [MoqInlineAutoData(PlatformInfo.Extensions)]
        public void DecodeTest(PlatformInfo info, PlatformId platform, SizeT paramValueSize, SizeT resultSize,
            int ptrValue, string actual, [Frozen] Mock<IPlatformKernel> kernel, [Frozen] Mock<IMarshalExecutor> marshal,
            PlatformInfoDecoder sut)
        {
            //arrange
            var ptr = new IntPtr(ptrValue);
            marshal.Setup(service => service.AllocHGlobal(paramValueSize)).Returns(ptr);
            marshal.Setup(service => service.PtrToStringAnsi(ptr, resultSize)).Returns(actual);
            kernel.Setup(service => service.GetPlatformInfo(platform, info, paramValueSize, ptr)).Returns(resultSize);

            //act
            var expected = sut.Decode(platform, info, paramValueSize);

            //assert
            marshal.Verify(service => service.AllocHGlobal(paramValueSize), Times.AtLeastOnce);
            kernel.Verify(service => service.GetPlatformInfo(platform, info, paramValueSize, ptr), Times.AtLeastOnce);
            marshal.Verify(service => service.PtrToStringAnsi(ptr, resultSize), Times.AtLeastOnce);
            marshal.Verify(service => service.FreeHGlobal(ptr), Times.AtLeastOnce);
            Assert.Equal(expected, actual);
        }
    }
}