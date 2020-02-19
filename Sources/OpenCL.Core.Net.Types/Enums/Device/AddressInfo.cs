using System;

namespace OpenCL.Core.Net.Types.Enums.Device
{
    // cl_device_address_info - bitfield
    [Flags]
    public enum DeviceAddressInfo : ulong
    {
        Address32Bits = 1 << 0,
        Address64Bits = 1 << 1
    }
}