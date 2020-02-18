using OpenCL.Core.Net.Native;
using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Enums.Mem;
using OpenCL.Types.Core.Net.Primitives;
using System;
using System.Runtime.InteropServices;

namespace OpenCL.Core.Net
{
    public class GLApi
    {
        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLBuffer(Context context, MemFlags flags, uint bufobj, ref Error errcode_ret);

        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLBuffer(Context context, MemFlags flags, uint bufobj, IntPtr errcode_ret);

        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLTexture(Context context, MemFlags flags, int target, int miplevel, uint texture, ref Error errcode_ret);

        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLTexture(Context context, MemFlags flags, int target, int miplevel, uint texture, IntPtr errcode_ret);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLTexture2D(Context context, MemFlags flags, int target, int miplevel, uint texture, ref Error errcode_ret);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLTexture2D(Context context, MemFlags flags, int target, int miplevel, uint texture, IntPtr errcode_ret);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLTexture3D(Context context, MemFlags flags, int target, int miplevel, uint texture, ref Error errcode_ret);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLTexture3D(Context context, MemFlags flags, int target, int miplevel, uint texture, IntPtr errcode_ret);

        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLRenderbuffer(Context context, MemFlags flags, uint renderbuffer, ref Error errcode_ret);

        [DllImport(DllNative.Name)]
        public static extern Mem clCreateFromGLRenderbuffer(Context context, MemFlags flags, uint renderbuffer, IntPtr errcode_ret);

        [DllImport(DllNative.Name)]
        public static extern Error clGetGLObjectInfo(Mem memobj, ref uint gl_object_type, ref uint gl_object_name);

        [DllImport(DllNative.Name)]
        public static extern Error clGetGLTextureInfo(Mem memobj, uint param_name, SizeT param_value_size, IntPtr param_value, ref SizeT param_value_size_ret);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueAcquireGLObjects(CommandQueue command_queue, uint num_objects, [In] Mem[] mem_objects, uint num_events_in_wait_list, [In] Event[] event_wait_list, ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueReleaseGLObjects(CommandQueue command_queue, uint num_objects, [In] Mem[] mem_objects, uint num_events_in_wait_list, [In] Event[] event_wait_list, ref Event e);
    }
}
