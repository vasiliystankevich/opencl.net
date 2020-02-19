using OpenCL.Core.Net.Types.Enums.Channel;

namespace OpenCL.Types.Core.Net
{
    public struct ImageFormat
    {
        public ChannelOrder ImageChannelOrder;
        public ChannelType ImageChannelDataType;
    }
}