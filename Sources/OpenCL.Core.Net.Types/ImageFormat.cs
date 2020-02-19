using OpenCL.Core.Net.Types.Enums.Channel;

namespace OpenCL.Core.Net.Types
{
    public struct ImageFormat
    {
        public ChannelOrder ImageChannelOrder;
        public ChannelType ImageChannelDataType;
    }
}