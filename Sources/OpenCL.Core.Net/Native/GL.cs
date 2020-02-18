using System;
using System.Runtime.InteropServices;
using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Enums.Mem;
using OpenCL.Types.Core.Net.Primitives;

namespace OpenCL.Core.Net.Native
{
    public class GlApi
    {
        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLBuffer(Context context, MemFlags flags, uint bufobj,
            ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLBuffer(Context context, MemFlags flags, uint bufobj, IntPtr errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLTexture(Context context, MemFlags flags, int target, int miplevel,
            uint texture, ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLTexture(Context context, MemFlags flags, int target, int miplevel,
            uint texture, IntPtr errcodeRet);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLTexture2D(Context context, MemFlags flags, int target, int miplevel,
            uint texture, ref Error errcodeRet);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLTexture2D(Context context, MemFlags flags, int target, int miplevel,
            uint texture, IntPtr errcodeRet);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLTexture3D(Context context, MemFlags flags, int target, int miplevel,
            uint texture, ref Error errcodeRet);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLTexture3D(Context context, MemFlags flags, int target, int miplevel,
            uint texture, IntPtr errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLRenderbuffer(Context context, MemFlags flags, uint renderbuffer,
            ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLRenderbuffer(Context context, MemFlags flags, uint renderbuffer,
            IntPtr errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Error clGetGLObjectInfo(Mem memobj, ref uint glObjectType, ref uint glObjectName);

        [DllImport(DllNative.Name)]
        public static extern Error clGetGLTextureInfo(Mem memobj, uint paramName, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueAcquireGLObjects(CommandQueue commandQueue, uint numObjects,
            [In] Mem[] memObjects, uint numEventsInWaitList, [In] Event[] eventWaitList, ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueReleaseGLObjects(CommandQueue commandQueue, uint numObjects,
            [In] Mem[] memObjects, uint numEventsInWaitList, [In] Event[] eventWaitList, ref Event e);
    }
}