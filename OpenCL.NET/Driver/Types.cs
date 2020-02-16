/*
 * Copyright (c) 2008-2018 Company for Advanced Supercomputing Solutions LTD
 * Author: Mordechai Botrashvily (support@cass-hpc.com)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to 
 * deal in the Software without restriction, including without limitation the 
 * rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
 * sell copies of the Software, and to permit persons to whom the Software is 
 * furnished to do so, subject to the following conditions:
 * The above copyright notice and this permission notice shall be included in 
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
 * IN THE SOFTWARE.
 */

using System;
using CASS.OpenCL.Types;
using CASS.OpenCL.Types.Primitives;

namespace CASS.OpenCL
{








    // cl_device_exec_capabilities - bitfield
    [Flags]
    public enum CLDeviceExecCapabilities : ulong
    {
        Kernel = (1 << 0),
        NativeKernel = (1 << 1),
    }
    
    // cl_command_queue_properties - bitfield
    [Flags]
    public enum CLCommandQueueProperties : ulong
    {
        OutOfOrderExecModeEnable = 1 << 0,
        ProfilingEnable = 1 << 1,
        /* 2.0 */
        OnDevice = 1 << 2,
        OnDeviceDefault = 1 << 3,
    }
    
    // cl_context_info
    public enum CLContextInfo : uint
    {
        ReferenceCount = 0x1080,
        Devices = 0x1081,
        Properties = 0x1082,
        /* 1.1 */
        NumDevices = 0x1083,
    }

    // cl_context_properties
    public enum CLContextProperties : uint
    {
        Platform = 0x1084,
        /* 1.2 */
        InteropUserSync = 0x1085,
    }

    /* 1.2 */
    // cl_device_partition_property
    public enum CLDevicePartitionProperty : long
    {
        Equally = 0x1086,
        ByCounts = 0x1087,
        ByCountsListEnd = 0x0,
        ByAffinityDomain = 0x1088,
    }

    /* 1.2 */
    // cl_device_affinity_domain
    [Flags]
    public enum CLDeviceAffinityDomain : ulong
    {
        NUMA = 1 << 0,
        L4Cache = 1 << 1,
        L3Cache = 1 << 2,
        L2Cache = 1 << 3,
        L1Cache = 1 << 4,
        NextPartitionable = 1 << 5
    }

    /* 2.0 */
    // cl_device_svm_capabilities - bitfield
    [Flags]
    public enum CLDeviceSVMCapabilities : ulong
    {
        CoarseGrainBuffer = 1 << 0,
        FineGrainBuffer = 1 << 1,
        FineGrainSystem = 1 << 2,
        Atomics = 1 << 3,
    }

    // cl_command_queue_info
    public enum CLCommandQueueInfo : uint
    {
        Context = 0x1090,
        Device = 0x1091,
        ReferenceCount = 0x1092,
        Properties = 0x1093,
        /* 2.0 */
        Size = 0x1094,
        /* 2.1 */
        DeviceDefault = 0x1095,
    }

    // cl_mem_flags - bitfield
    [Flags]
    public enum CLMemFlags : ulong
    {
        ReadWrite = 1 << 0,
        WriteOnly = 1 << 1,
        ReadOnly = 1 << 2,
        UseHostPtr = 1 << 3,
        AllocHostPtr = 1 << 4,
        CopyHostPtr = 1 << 5,

        /* 1.2 */
        HostWriteOnly = 1 << 7,
        HostReadOnly = 1 << 8,
        HostNoAccess = 1 << 9,

        /* 2.0 */
        KernelReadAndWrite = 1 << 12,
    }

    /* 2.0 */
    // cl_svm_mem_flags - bitfield
    [Flags]
    public enum CLSVMMemFlags : ulong
    {
        ReadWrite = 1 << 0,
        WriteOnly = 1 << 1,
        ReadOnly = 1 << 2,

        /* 2.0 */
        SVMFineGrainBuffer = 1 << 10,   /* used by cl_svm_mem_flags only */
        SVMAtomics = 1 << 11,           /* used by cl_svm_mem_flags only */
    }

    /* 1.2 */
    // cl_mem_migration_flags - bitfield
    [Flags]
    public enum CLMemMigrationFlags : ulong
    {
        Host = 1 << 0,
        ContentUndefined = 1 << 1,
    }

    // cl_channel_order
    public enum CLChannelOrder : uint
    {
        R = 0x10B0,
        A = 0x10B1,
        RG = 0x10B2,
        RA = 0x10B3,
        RGB = 0x10B4,
        RGBA = 0x10B5,
        BGRA = 0x10B6,
        ARGB = 0x10B7,
        Intensity = 0x10B8,
        Luminance = 0x10B9,
        /* 1.1 */
        Rx = 0x10BA,
        RGx = 0x10BB,
        RGBx = 0x10BC,
        /* 1.2 */
        Depth = 0x10BD,
        DepthStencil = 0x10BE,
        /* 2.0 */
        sRGB = 0x10BF,
        sRGBx = 0x10C0,
        sRGBA = 0x10C1,
        sBGRA = 0x10C2,
        ABGR = 0x10C3,
    }

    // cl_channel_type
    public enum CLChannelType : uint
    {
        SNormInt8 = 0x10D0,
        SNormInt16 = 0x10D1,
        UNormInt8 = 0x10D2,
        UNormInt16 = 0x10D3,
        UNormShort565 = 0x10D4,
        UNormShort555 = 0x10D5,
        UNormInt101010 = 0x10D6,
        SignedInt8 = 0x10D7,
        SignedInt16 = 0x10D8,
        SignedInt32 = 0x10D9,
        UnSignedInt8 = 0x10DA,
        UnSignedInt16 = 0x10DB,
        UnSignedInt32 = 0x10DC,
        HalfFloat = 0x10DD,
        Float = 0x10DE,
        /* 1.2 */
        UnormInt24 = 0x10DF,
        /* 2.1 */
        UnormInt101010_2 = 0x10E0,
    }

    // cl_mem_object_type
    public enum CLMemObjectType : uint
    {
        Buffer = 0x10F0,
        Image2D = 0x10F1,
        Image3D = 0x10F2,
        /* 1.2 */
        Image2DArray = 0x10F3,
        Image1D = 0x10F4,
        Image1DArray = 0x10F5,
        Image1DBuffer = 0x10F6,
        /* 2.0 */
        Pipe = 0x10F7,
    }

    // cl_mem_info
    public enum CLMemInfo : uint
    {
        Type = 0x1100,
        Flags = 0x1101,
        Size = 0x1102,
        HostPtr = 0x1103,
        MapCount = 0x1104,
        ReferenceCount = 0x1105,
        Context = 0x1106,
        /* 1.1 */
        AssociatedMemObject = 0x1107,
        Offset = 0x1108,
        /* 2.0 */
        UsesSVMPointer = 0x1109,
    }

    // cl_image_info
    public enum CLImageInfo : uint
    {
        Format = 0x1110,
        ElementSize = 0x1111,
        RowPitch = 0x1112,
        SlicePitch = 0x1113,
        Width = 0x1114,
        Height = 0x1115,
        Depth = 0x1116,
        /* 1.2 */
        ArraySize = 0x1117,
        Buffer = 0x1118,
        NumMIPLevels = 0x1119,
        NumSamples = 0x111A,
    }

    /* 2.0 */
    // cl_pipe_info
    public enum CLPipeInfo : uint
    {
        PacketSize = 0x1120,
        MaxPackets = 0x1121,
    }

    // cl_addressing_mode
    public enum CLAddressingMode : uint
    {
        None = 0x1130,
        ClampToEdge = 0x1131,
        Clamp = 0x1132,
        Repeat = 0x1133,
        /* 1.1 */
        MirroredRepeat = 0x1134,
    }

    // cl_filter_mode
    public enum CLFilterMode : uint
    {
        Nearest = 0x1140,
        Linear = 0x1141,
    }

    // cl_sampler_info
    public enum CLSamplerInfo : uint
    {
        ReferenceCount = 0x1150,
        Context = 0x1151,
        NormalizedCoords = 0x1152,
        AddressingMode = 0x1153,
        FilterMode = 0x1154,
        /* 2.0 */
        MIPFilterMode = 0x1155,
        LODMin = 0x1156,
        LODMax = 0x1157,
    }

    // cl_map_flags - bitfield
    [Flags]
    public enum CLMapFlags : ulong
    {
        Read = 1 << 0,
        Write = 1 << 1,
        /* 1.2 */
        WriteInvalidateRegion = 1 << 2,
    }

    // cl_program_info
    public enum CLProgramInfo : uint
    {
        ReferenceCount = 0x1160,
        Context = 0x1161,
        NumDevices = 0x1162,
        Devices = 0x1163,
        Source = 0x1164,
        BinarySizes = 0x1165,
        Binaries = 0x1166,
        /* 1.2 */
        NumKernels = 0x1167,
        KernelNames = 0x1168,
        /* 2.1 */
        IL = 0x1169,
        /* 2.2 */
        ScopeGlobalCtorsPresent = 0x116A,
        ScopeGlobalDtorsPresent = 0x116B,
    }
    //#endregion
}