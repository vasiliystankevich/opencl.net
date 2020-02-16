﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASS.OpenCL.Types.Enums
{
    // Error Codes
    public enum CLError
    {
        Success = 0,
        DeviceNotFound = -1,
        DeviceNotAvailable = -2,
        DeviceCompilerNotAvailable = -3,
        MemObjectAllocationFailure = -4,
        OutOfResources = -5,
        OutOfHostMemory = -6,
        ProfilingInfoNotAvailable = -7,
        MemCopyOverlap = -8,
        ImageFormatMismatch = -9,
        ImageFormatNotSupported = -10,
        BuildProgramFailure = -11,
        MapFailure = -12,
        /* 1.1 */
        MisalignedSubBufferOffset = -13,
        ExecStatusErrorForEventsInWaitList = -14,
        /* 1.2 */
        CompileProgramFailure = -15,
        LinkerNotAvailable = -16,
        LinkProgramFailure = -17,
        DevicePartitionFailed = -18,
        KernelArgInfoNotAvailable = -19,

        InvalidValue = -30,
        InvalidDeviceType = -31,
        InvalidPlatform = -32,
        InvalidDevice = -33,
        InvalidContext = -34,
        InvalidQueueProperties = -35,
        InvalidCommandQueue = -36,
        InvalidHostPtr = -37,
        InvalidMemObject = -38,
        InvalidImageFormatDescriptor = -39,
        InvalidImageSize = -40,
        InvalidSampler = -41,
        InvalidBinary = -42,
        InvalidBuildOptions = -43,
        InvalidProgram = -44,
        InvalidProgramExecutable = -45,
        InvalidKernelName = -46,
        InvalidKernelDefinition = -47,
        InvalidKernel = -48,
        InvalidArgIndex = -49,
        InvalidArgValue = -50,
        InvalidArgSize = -51,
        InvalidKernelArgs = -52,
        InvalidWorkDimension = -53,
        InvalidWorkGroupSize = -54,
        InvalidWorkItemSize = -55,
        InvalidGlobalOffset = -56,
        InvalidEventWaitList = -57,
        InvalidEvent = -58,
        InvalidOperation = -59,
        InvalidGLObject = -60,
        InvalidBufferSize = -61,
        InvalidMipLevel = -62,
        InvalidGlobalWorkSize = -63,
        /* 1.1 */
        InvalidProperty = -64,
        /* 1.2 */
        InvalidImageDescriptor = -65,
        InvalidCompilerOptions = -66,
        InvalidLinkerOptions = -67,
        InvalidDevicePartitionCount = -68,
        /* 2.0 */
        InvalidPipeSize = -69,
        InvalidDeviceQueue = -70,
        /* 2.2 */
        InvalidSpecID = -71,
        MaxSizeRestrictionExceeded = -72,
    }
}
