using System;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Native;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Mem;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Kernel
{
    public class MemoryObjectKernel: IMemoryObjectKernel
    {
        public MemoryObjectKernel(IErrorValidator errorValidator)
        {
            ErrorValidator = errorValidator;
        }

        public Mem CreateBuffer(Context context, MemFlags flags, SizeT size, IntPtr hostPtr) => ErrorValidator.Validate(
            (ref Error error) => MemoryObjectNative.clCreateBuffer(context, flags, size, hostPtr, ref error));

        public Mem CreateSubBuffer(Mem buffer, MemFlags flags, BufferCreateType bufferCreateType,
            IntPtr bufferCreateInfo) => ErrorValidator.Validate((ref Error error) =>
            MemoryObjectNative.clCreateSubBuffer(buffer, flags, bufferCreateType, bufferCreateInfo, ref error));

        public Mem CreateSubBuffer(Mem buffer, MemFlags flags, BufferCreateType bufferCreateType,
            BufferRegion bufferCreateInfo) => ErrorValidator.Validate((ref Error error) =>
            MemoryObjectNative.clCreateSubBuffer(buffer, flags, bufferCreateType, bufferCreateInfo, ref error));

        [Obsolete("Deprecated since OpenCL 1.2")]
        public Mem CreateImage2D(Context context, MemFlags flags, ref ImageFormat imageFormat, SizeT imageWidth,
            SizeT imageHeight, SizeT imageRowPitch, IntPtr hostPtr) => ErrorValidator.Validate(ref imageFormat,
            (ref ImageFormat format, ref Error error) => MemoryObjectNative.clCreateImage2D(context, flags, ref format,
                imageWidth, imageHeight, imageRowPitch, hostPtr, ref error));

        [Obsolete("Deprecated since OpenCL 1.2")]
        public Mem CreateImage3D(Context context, MemFlags flags, ref ImageFormat imageFormat, SizeT imageWidth,
            SizeT imageHeight, SizeT imageDepth, SizeT imageRowPitch, SizeT imageSlicePitch, IntPtr hostPtr) =>
            ErrorValidator.Validate(ref imageFormat,
                (ref ImageFormat format, ref Error error) => MemoryObjectNative.clCreateImage3D(context, flags,
                    ref format, imageWidth, imageHeight, imageDepth, imageRowPitch, imageSlicePitch, hostPtr,
                    ref error));

        public Mem CreateImage(Context context, MemFlags flags, ImageFormat imageFormat, ImageDesc imageDesc, IntPtr hostPtr)
        {
        }

        public Mem CreateImage(Context context, MemFlags flags, ImageFormat imageFormat, ImageDesc imageDesc, IntPtr hostPtr,
            IntPtr errcodeRet)
        {
            throw new NotImplementedException();
        }

        public Mem CreatePipe(Context context, MemFlags flags, uint pipePacketSize, uint pipeMaxPackets, IntPtr[] properties,
            ref Error errcodeRet)
        {
            throw new NotImplementedException();
        }

        public Mem CreatePipe(Context context, MemFlags flags, uint pipePacketSize, uint pipeMaxPackets, IntPtr[] properties,
            IntPtr errcodeRet)
        {
            throw new NotImplementedException();
        }

        public Error RetainMemObject(Mem memobj)
        {
            throw new NotImplementedException();
        }

        public Error ReleaseMemObject(Mem memobj)
        {
            throw new NotImplementedException();
        }

        public Error GetSupportedImageFormats(Context context, MemFlags flags, MemObjectType imageType, uint numEntries,
            IntPtr imageFormats, ref uint numImageFormats)
        {
            throw new NotImplementedException();
        }

        public Error GetSupportedImageFormats(Context context, MemFlags flags, MemObjectType imageType, uint numEntries,
            ImageFormat[] imageFormats, ref uint numImageFormats)
        {
            throw new NotImplementedException();
        }

        public Error GetMemObjectInfo(Mem memobj, MemInfo paramName, SizeT paramValueSize, IntPtr paramValue,
            ref SizeT paramValueSizeRet)
        {
            throw new NotImplementedException();
        }

        public Error GetImageInfo(Mem image, ImageInfo paramName, SizeT paramValueSize, IntPtr paramValue,
            ref SizeT paramValueSizeRet)
        {
            throw new NotImplementedException();
        }

        public Error GetPipeInfo(Mem pipe, PipeInfo paramName, SizeT paramValueSize, IntPtr paramValue, ref SizeT paramValueSizeRet)
        {
            throw new NotImplementedException();
        }

        public Error SetMemObjectDestructorCallback(Mem memobj, Action<Mem, IntPtr> pfnNotify, IntPtr userData)
        {
            throw new NotImplementedException();
        }

        IErrorValidator ErrorValidator { get; } 
    }
}