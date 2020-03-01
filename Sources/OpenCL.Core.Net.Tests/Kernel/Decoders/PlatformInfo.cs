using AutoFixture.Xunit2;
using Moq;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Kernel.Executors;
using OpenCL.Core.Net.Kernel.Decoders;
using OpenCL.Core.Net.Types.Primitives;
using Tests.AAAPattern.xUnit.Attributes;
using Xunit;

namespace OpenCL.Core.Net.Tests.Kernel.Decoders
{
    public class PlatformInfoDecoderTests
    {
        [Theory]
        [MoqAutoData]
        public void DecodeTest(PlatformId z, SizeT data,  [Frozen]Mock<IPlatformKernel> kernel, [Frozen]Mock<IMarshalExecutor> marshal, PlatformInfoDecoder sut)
        {
            //arrange
            //var platformId = (PlatformId) platformIdValue;
            
            //act
            //var expected = sut.Decode(platformId, )

            //assert
        }
    }
}
