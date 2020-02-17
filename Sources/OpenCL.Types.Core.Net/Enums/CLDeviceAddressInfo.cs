using System;

namespace CASS.OpenCL.Types.Enums
{
    // cl_device_address_info - bitfield
    [Flags]
    public enum CLDeviceAddressInfo : ulong
    {
        Address32Bits = (1 << 0),
        Address64Bits = (1 << 1),
    }
}
