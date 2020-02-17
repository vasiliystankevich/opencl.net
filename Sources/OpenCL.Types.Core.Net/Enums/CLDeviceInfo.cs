﻿using System;

namespace OpenCL.Types.Core.Net.Enums
{
    // cl_device_info
    public enum DeviceInfo : uint
    {
        Type = 0x1000,
        VendorId = 0x1001,
        MaxComputeUnits = 0x1002,
        MaxWorkItemDimensions = 0x1003,
        MaxWorkGroupSize = 0x1004,
        MaxWorkItemSizes = 0x1005,
        PreferredVectorWidthChar = 0x1006,
        PreferredVectorWidthShort = 0x1007,
        PreferredVectorWidthInt = 0x1008,
        PreferredVectorWidthLong = 0x1009,
        PreferredVectorWidthFloat = 0x100A,
        PreferredVectorWidthDouble = 0x100B,
        MaxClockFrequency = 0x100C,
        AddressBits = 0x100D,
        MaxReadImageArgs = 0x100E,
        MaxWriteImageArgs = 0x100F,
        MaxMemAllocSize = 0x1010,
        Image2DMaxWidth = 0x1011,
        Image2DMaxHeight = 0x1012,
        Image3DMaxWidth = 0x1013,
        Image3DMaxHeight = 0x1014,
        Image3DMaxDepth = 0x1015,
        ImageSupport = 0x1016,
        MaxParameterSize = 0x1017,
        MaxSamplers = 0x1018,
        MemBaseAddrAlign = 0x1019,
        MinDataTypeAlignSize = 0x101A,
        SingleFPConfig = 0x101B,
        GlobalMemCacheType = 0x101C,
        GlobalMemCacheLineSize = 0x101D,
        GlobalMemCacheSize = 0x101E,
        GlobalMemSize = 0x101F,
        MaxConstantBufferSize = 0x1020,
        MaxConstantArgs = 0x1021,
        LocalMemType = 0x1022,
        LocalMemSize = 0x1023,
        ErrorCorrectionSupport = 0x1024,
        ProfilingTimerResolution = 0x1025,
        EndianLittle = 0x1026,
        Available = 0x1027,
        CompilerAvailable = 0x1028,
        ExecutionCapabilities = 0x1029,
        [Obsolete("Deprecated since OpenCL 2.0")]
        QueueProperties = 0x102A,
        /* 2.0 */
        QueueOnHostProperties = 0x102A,

        Name = 0x102B,
        Vendor = 0x102C,
        DriverVersion = 0x102D,
        Profile = 0x102E,
        Version = 0x102F,
        Extensions = 0x1030,
        Platform = 0x1031,
        /* 1.2 */
        DoubleFpConfig = 0x1032,

        /* 1.1 */
        /* 0x1032 reserved for CL_DEVICE_DOUBLE_FP_CONFIG */
        /* 0x1033 reserved for CL_DEVICE_HALF_FP_CONFIG */
        PreferredVectorWidthHalf = 0x1034,
        HostUnifiedMemory = 0x1035,
        NativeVectorWidthChar = 0x1036,
        NativeVectorWidthShort = 0x1037,
        NativeVectorWidthInt = 0x1038,
        NativeVectorWidthLong = 0x1039,
        NativeVectorWidthFloat = 0x103A,
        NativeVectorWidthDouble = 0x103B,
        NativeVectorWidthHalf = 0x103C,
        OpenCLCVersion = 0x103D,
        /* 1.2 */
        LinkerAvailable = 0x103E,
        BuiltInKernels = 0x103F,
        ImageMaxBufferSize = 0x1040,
        ImageMaxArraySize = 0x1041,
        ParentDevice = 0x1042,
        PartitionMaxSubDevices = 0x1043,
        PartitionProperties = 0x1044,
        PartitionAffinityDomain = 0x1045,
        PartitionType = 0x1046,
        ReferenceCount = 0x1047,
        PreferredInteropUserSync = 0x1048,
        PrintfBufferSize = 0x1049,
        ImagePitchAlignment = 0x104A,
        ImageBaseAddressAlignment = 0x104B,
        /* 2.0 */
        MaxReadWriteImageArgs = 0x104C,
        MaxGlobalVaribleSize = 0x104D,
        QueueOnDeviceProperties = 0x104E,
        QueueOnDevicePreferredSize = 0x104F,
        QueueOnDeviceMaxSize = 0x1050,
        MaxOnDeviceQueues = 0x1051,
        MaxOnDeviceEvents = 0x1052,
        SvmCapabilities = 0x1053,
        GlobalVariablePreferredTotalSize = 0x1054,
        MaxPipeArgs = 0x1055,
        PipeMaxActiveReservations = 0x1056,
        PipeMaxPacketSize = 0x1057,
        PreferredPlatformAtomicAlignment = 0x1058,
        PreferredGlobalAtomicAlignment = 0x1059,
        PreferredLocalAtomicAlignment = 0x105A,
        /* 2.1 */
        ILVersion = 0x105B,
        MaxNumSubGroups = 0x105C,
        SubGroupIndependentForwardProgress = 0x105D
    }
}