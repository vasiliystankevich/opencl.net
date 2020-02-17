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
using System.Runtime.InteropServices;
using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Primitives;

namespace OpenCL.Core.Net
{
    /// <summary>
    /// This class provides the driver interface for OpenGL interoperability
    /// with OpenCL standard.
    /// </summary>
    public class OpenCLGLDriver
    {
        [DllImport(OpenCLDriver.OPENCL_DLL_NAME)]
        public static extern Mem clCreateFromGLBuffer(
            Context context,
            CLMemFlags flags,
            uint bufobj,
            ref Error errcode_ret);
        [DllImport(OpenCLDriver.OPENCL_DLL_NAME)]
        public static extern Mem clCreateFromGLBuffer(
            Context context,
            CLMemFlags flags,
            uint bufobj,
            IntPtr errcode_ret);

        [DllImport(OpenCLDriver.OPENCL_DLL_NAME)]
        public static extern Mem clCreateFromGLTexture(
            Context context,
            CLMemFlags flags,
            int target,
            int miplevel,
            uint texture,
            ref Error errcode_ret);
        [DllImport(OpenCLDriver.OPENCL_DLL_NAME)]
        public static extern Mem clCreateFromGLTexture(
            Context context,
            CLMemFlags flags,
            int target,
            int miplevel,
            uint texture,
            IntPtr errcode_ret);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(OpenCLDriver.OPENCL_DLL_NAME)]
        public static extern Mem clCreateFromGLTexture2D(
            Context context,
            CLMemFlags flags,
            int target,
            int miplevel,
            uint texture,
            ref Error errcode_ret);
        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(OpenCLDriver.OPENCL_DLL_NAME)]
        public static extern Mem clCreateFromGLTexture2D(
            Context context,
            CLMemFlags flags,
            int target,
            int miplevel,
            uint texture,
            IntPtr errcode_ret);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(OpenCLDriver.OPENCL_DLL_NAME)]
        public static extern Mem clCreateFromGLTexture3D(
            Context context,
            CLMemFlags flags,
            int target,
            int miplevel,
            uint texture,
            ref Error errcode_ret);
        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(OpenCLDriver.OPENCL_DLL_NAME)]
        public static extern Mem clCreateFromGLTexture3D(
            Context context,
            CLMemFlags flags,
            int target,
            int miplevel,
            uint texture,
            IntPtr errcode_ret);

        [DllImport(OpenCLDriver.OPENCL_DLL_NAME)]
        public static extern Mem clCreateFromGLRenderbuffer(
            Context context,
            CLMemFlags flags,
            uint renderbuffer,
            ref Error errcode_ret);
        [DllImport(OpenCLDriver.OPENCL_DLL_NAME)]
        public static extern Mem clCreateFromGLRenderbuffer(
            Context context,
            CLMemFlags flags,
            uint renderbuffer,
            IntPtr errcode_ret);

        [DllImport(OpenCLDriver.OPENCL_DLL_NAME)]
        public static extern Error clGetGLObjectInfo(
            Mem memobj,
            ref uint gl_object_type,
            ref uint gl_object_name);

        [DllImport(OpenCLDriver.OPENCL_DLL_NAME)]
        public static extern Error clGetGLTextureInfo(
            Mem memobj,
            uint param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        [DllImport(OpenCLDriver.OPENCL_DLL_NAME)]
        public static extern Error clEnqueueAcquireGLObjects(
            CommandQueue command_queue,
            uint num_objects,
            [In] Mem[] mem_objects,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        [DllImport(OpenCLDriver.OPENCL_DLL_NAME)]
        public static extern Error clEnqueueReleaseGLObjects(
            CommandQueue command_queue,
            uint num_objects,
            [In] Mem[] mem_objects,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
    }
}
