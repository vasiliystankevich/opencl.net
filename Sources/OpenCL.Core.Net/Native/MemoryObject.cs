using System;
using System.Runtime.InteropServices;
using OpenCL.Types.Core.Net;
using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Enums.Mem;
using OpenCL.Types.Core.Net.Primitives;

namespace OpenCL.Core.Net.Native
{
    public class MemoryObjectApi
    {
        [DllImport(DllNative.Name)]
        public static extern Mem clCreateBuffer(Context context, MemFlags flags, SizeT size, IntPtr hostPtr,
            ref Error errcodeRet);

        /* 1.1 */
        [DllImport(DllNative.Name)]
        public static extern Mem clCreateSubBuffer(Mem buffer, MemFlags flags, BufferCreateType bufferCreateType,
            IntPtr bufferCreateInfo, ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Mem clCreateSubBuffer(Mem buffer, MemFlags flags, BufferCreateType bufferCreateType,
            [MarshalAs(UnmanagedType.LPStruct)] BufferRegion bufferCreateInfo, ref Error errcodeRet);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(DllNative.Name)]
        public static extern Mem clCreateImage2D(Context context, MemFlags flags, ref ImageFormat imageFormat,
            SizeT imageWidth, SizeT imageHeight, SizeT imageRowPitch, IntPtr hostPtr, ref Error errcodeRet);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(DllNative.Name)]
        public static extern Mem clCreateImage3D(Context context, MemFlags flags, ref ImageFormat imageFormat,
            SizeT imageWidth, SizeT imageHeight, SizeT imageDepth, SizeT imageRowPitch, SizeT imageSlicePitch,
            IntPtr hostPtr, ref Error errcodeRet);

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern Mem clCreateImage(Context context, MemFlags flags,
            [MarshalAs(UnmanagedType.LPStruct)] ImageFormat imageFormat,
            [MarshalAs(UnmanagedType.LPStruct)] ImageDesc imageDesc, IntPtr hostPtr, ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Mem clCreateImage(Context context, MemFlags flags,
            [MarshalAs(UnmanagedType.LPStruct)] ImageFormat imageFormat,
            [MarshalAs(UnmanagedType.LPStruct)] ImageDesc imageDesc, IntPtr hostPtr, IntPtr errcodeRet);

        /* 2.0 */
        [DllImport(DllNative.Name)]
        public static extern Mem clCreatePipe(Context context, MemFlags flags, uint pipePacketSize, uint pipeMaxPackets,
            [In] IntPtr[] properties, ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Mem clCreatePipe(Context context, MemFlags flags, uint pipePacketSize, uint pipeMaxPackets,
            [In] IntPtr[] properties, IntPtr errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Error clRetainMemObject(Mem memobj);

        [DllImport(DllNative.Name)]
        public static extern Error clReleaseMemObject(Mem memobj);

        [DllImport(DllNative.Name)]
        public static extern Error clGetSupportedImageFormats(Context context, MemFlags flags, MemObjectType imageType,
            uint numEntries, IntPtr imageFormats, ref uint numImageFormats);

        [DllImport(DllNative.Name)]
        public static extern Error clGetSupportedImageFormats(Context context, MemFlags flags, MemObjectType imageType,
            uint numEntries, [Out] ImageFormat[] imageFormats, ref uint numImageFormats);

        [DllImport(DllNative.Name)]
        public static extern Error clGetMemObjectInfo(Mem memobj, MemInfo paramName, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet);

        [DllImport(DllNative.Name)]
        public static extern Error clGetImageInfo(Mem image, ImageInfo paramName, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet);

        /* 2.0 */
        [DllImport(DllNative.Name)]
        public static extern Error clGetPipeInfo(Mem pipe, PipeInfo paramName, SizeT paramValueSize, IntPtr paramValue,
            ref SizeT paramValueSizeRet);

        /* 1.1 */
        [DllImport(DllNative.Name)]
        public static extern Error clSetMemObjectDestructorCallback(Mem memobj, Action<Mem, IntPtr> pfnNotify,
            IntPtr userData);
    }
}