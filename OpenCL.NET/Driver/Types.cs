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








    //#endregion
}