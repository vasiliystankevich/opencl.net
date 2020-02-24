using System;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Mem;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Kernel
{
    public interface IMemoryObjectKernel
    {
        Mem CreateBuffer(Context context, MemFlags flags, SizeT size, IntPtr hostPtr);

        /* 1.1 */
        Mem CreateSubBuffer(Mem buffer, MemFlags flags, BufferCreateType bufferCreateType, IntPtr bufferCreateInfo);

        Mem CreateSubBuffer(Mem buffer, MemFlags flags, BufferCreateType bufferCreateType,
            BufferRegion bufferCreateInfo);

        [Obsolete("Deprecated since OpenCL 1.2")]
        Mem CreateImage2D(Context context, MemFlags flags, ref ImageFormat imageFormat, SizeT imageWidth,
            SizeT imageHeight, SizeT imageRowPitch, IntPtr hostPtr);

        [Obsolete("Deprecated since OpenCL 1.2")]
        Mem CreateImage3D(Context context, MemFlags flags, ref ImageFormat imageFormat, SizeT imageWidth,
            SizeT imageHeight, SizeT imageDepth, SizeT imageRowPitch, SizeT imageSlicePitch, IntPtr hostPtr);

        /* 1.2 */
        Mem CreateImage(Context context, MemFlags flags, ImageFormat imageFormat, ImageDesc imageDesc, IntPtr hostPtr,
            ref Error errcodeRet);

        Mem CreateImage(Context context, MemFlags flags, ImageFormat imageFormat, ImageDesc imageDesc, IntPtr hostPtr,
            IntPtr errcodeRet);

        /* 2.0 */
        Mem CreatePipe(Context context, MemFlags flags, uint pipePacketSize, uint pipeMaxPackets, IntPtr[] properties,
            ref Error errcodeRet);

        Mem CreatePipe(Context context, MemFlags flags, uint pipePacketSize, uint pipeMaxPackets, IntPtr[] properties,
            IntPtr errcodeRet);

        Error RetainMemObject(Mem memobj);

        Error ReleaseMemObject(Mem memobj);

        Error GetSupportedImageFormats(Context context, MemFlags flags, MemObjectType imageType, uint numEntries,
            IntPtr imageFormats, ref uint numImageFormats);

        Error GetSupportedImageFormats(Context context, MemFlags flags, MemObjectType imageType, uint numEntries,
            ImageFormat[] imageFormats, ref uint numImageFormats);

        Error GetMemObjectInfo(Mem memobj, MemInfo paramName, SizeT paramValueSize, IntPtr paramValue,
            ref SizeT paramValueSizeRet);

        Error GetImageInfo(Mem image, ImageInfo paramName, SizeT paramValueSize, IntPtr paramValue,
            ref SizeT paramValueSizeRet);

        /* 2.0 */
        Error GetPipeInfo(Mem pipe, PipeInfo paramName, SizeT paramValueSize, IntPtr paramValue,
            ref SizeT paramValueSizeRet);

        /* 1.1 */
        Error SetMemObjectDestructorCallback(Mem memobj, Action<Mem, IntPtr> pfnNotify, IntPtr userData);
    }
}
