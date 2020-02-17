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
using OpenCL.Core.Net.Native;
using OpenCL.Types.Core.Net;
using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Enums.Command;
using OpenCL.Types.Core.Net.Enums.Kernel;
using OpenCL.Types.Core.Net.Enums.Kernel.Arg;
using OpenCL.Types.Core.Net.Enums.Mem;
using OpenCL.Types.Core.Net.Enums.Program;
using OpenCL.Types.Core.Net.Primitives;

namespace OpenCL.Core.Net
{
    /// <summary>
    /// This class provides the driver interface to OpenCL functions.
    /// </summary>
    public class OpenCLDriver
    {
        #region Command Queue APIs

        #endregion





        #region Memory Object APIs
        [DllImport(Dll.Name)]
        public static extern Mem clCreateBuffer(
            Context context,
            MemFlags flags,
            SizeT size,
            IntPtr host_ptr,
            ref Error errcode_ret);

        /* 1.1 */
        [DllImport(Dll.Name)]
        public static extern Mem clCreateSubBuffer(
            Mem buffer,
            MemFlags flags,
            BufferCreateType buffer_create_type,
            IntPtr buffer_create_info,
            ref Error errcode_ret);
        [DllImport(Dll.Name)]
        public static extern Mem clCreateSubBuffer(
            Mem buffer,
            MemFlags flags,
            BufferCreateType buffer_create_type,
            [MarshalAs(UnmanagedType.LPStruct)]
            BufferRegion buffer_create_info,
            ref Error errcode_ret);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(Dll.Name)]
        public static extern Mem clCreateImage2D(
            Context context,
            MemFlags flags,
            ref ImageFormat image_format,
            SizeT image_width,
            SizeT image_height,
            SizeT image_row_pitch,
            IntPtr host_ptr,
            ref Error errcode_ret);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(Dll.Name)]
        public static extern Mem clCreateImage3D(
            Context context,
            MemFlags flags,
            ref ImageFormat image_format,
            SizeT image_width,
            SizeT image_height,
            SizeT image_depth,
            SizeT image_row_pitch,
            SizeT image_slice_pitch,
            IntPtr host_ptr,
            ref Error errcode_ret);

        /* 1.2 */
        [DllImport(Dll.Name)]
        public static extern Mem clCreateImage(
            Context context,
            MemFlags flags,
            [MarshalAs(UnmanagedType.LPStruct)]
            ImageFormat image_format,
            [MarshalAs(UnmanagedType.LPStruct)]
            ImageDesc image_desc,
            IntPtr host_ptr,
            ref Error errcode_ret);
        [DllImport(Dll.Name)]
        public static extern Mem clCreateImage(
            Context context,
            MemFlags flags,
            [MarshalAs(UnmanagedType.LPStruct)]
            ImageFormat image_format,
            [MarshalAs(UnmanagedType.LPStruct)]
            ImageDesc image_desc,
            IntPtr host_ptr,
            IntPtr errcode_ret);

        /* 2.0 */
        [DllImport(Dll.Name)]
        public static extern Mem clCreatePipe(
            Context context,
            MemFlags flags,
            uint pipe_packet_size,
            uint pipe_max_packets,
            [In] IntPtr[] properties,
            ref Error errcode_ret);
        [DllImport(Dll.Name)]
        public static extern Mem clCreatePipe(
            Context context,
            MemFlags flags,
            uint pipe_packet_size,
            uint pipe_max_packets,
            [In] IntPtr[] properties,
            IntPtr errcode_ret);

        [DllImport(Dll.Name)]
        public static extern Error clRetainMemObject(Mem memobj);

        [DllImport(Dll.Name)]
        public static extern Error clReleaseMemObject(Mem memobj);

        [DllImport(Dll.Name)]
        public static extern Error clGetSupportedImageFormats(
            Context context,
            MemFlags flags,
            MemObjectType image_type,
            uint num_entries,
            IntPtr image_formats,
            ref uint num_image_formats);
        [DllImport(Dll.Name)]
        public static extern Error clGetSupportedImageFormats(
            Context context,
            MemFlags flags,
            MemObjectType image_type,
            uint num_entries,
            [Out] ImageFormat[] image_formats,
            ref uint num_image_formats);

        [DllImport(Dll.Name)]
        public static extern Error clGetMemObjectInfo(
            Mem memobj,
            MemInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        [DllImport(Dll.Name)]
        public static extern Error clGetImageInfo(
            Mem image,
            ImageInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        /* 2.0 */
        [DllImport(Dll.Name)]
        public static extern Error clGetPipeInfo(
            Mem pipe,
            PipeInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        /* 1.1 */
        public delegate void DestructionFunction(
            Mem memobj, 
            IntPtr user_data);
        [DllImport(Dll.Name)]
        public static extern Error clSetMemObjectDestructorCallback(
            Mem memobj,
            DestructionFunction pfn_notify,
            IntPtr user_data);
        #endregion

        /* 2.0 */
        #region SVM Allocation APIs
        [DllImport(Dll.Name)]
        public static extern IntPtr clSVMAlloc(
            Context context,
            SvmMemFlags flags,
            SizeT size,
            uint alignment);

        [DllImport(Dll.Name)]
        public static extern void clSVMFree(
            Context context,
            IntPtr svm_pointer);
        #endregion

        #region Sampler APIs
        [Obsolete("Deprecated since OpenCL 2.0")]
        [DllImport(Dll.Name)]
        public static extern Sampler clCreateSampler(
            Context context,
            Bool normalized_coords,
            AddressingMode addressing_mode,
            FilterMode filter_mode,
            ref Error errcode_ret);

        /* 2.0 */
        [DllImport(Dll.Name)]
        public static extern Sampler clCreateSamplerWithProperties(
            Context context,
            [In] IntPtr[] sampler_properties,
            ref Error errcode_ret);
        [DllImport(Dll.Name)]
        public static extern Sampler clCreateSamplerWithProperties(
            Context context,
            [In] IntPtr[] sampler_properties,
            IntPtr errcode_ret);

        [DllImport(Dll.Name)]
        public static extern Error clRetainSampler(Sampler sampler);

        [DllImport(Dll.Name)]
        public static extern Error clReleaseSampler(Sampler sampler);

        [DllImport(Dll.Name)]
        public static extern Error clGetSamplerInfo(
            Sampler sampler,
            SamplerInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);
        #endregion

        #region Program Object APIs
        [DllImport(Dll.Name)]
        public static extern Program clCreateProgramWithSource(
            Context context,
            uint count,
            IntPtr strings,
            [In] SizeT[] lengths,
            ref Error errcode_ret);
        [DllImport(Dll.Name)]
        public static extern Program clCreateProgramWithSource(
            Context context,
            uint count,
            [In] string[] strings,
            [In] SizeT[] lengths,
            ref Error errcode_ret);
        [DllImport(Dll.Name)]
        public static extern Program clCreateProgramWithSource(
            Context context,
            uint count,
            [In] IntPtr[] strings,
            [In] SizeT[] lengths,
            ref Error errcode_ret);

        [DllImport(Dll.Name)]
        public static extern Program clCreateProgramWithBinary(
            Context context,
            uint num_devices,
            [In] DeviceId[] device_list,
            [In] SizeT[] lengths,
            [In] IntPtr[] binaries,
            [In, Out] int[] binary_status,
            ref Error errcode_ret);

        /* 1.2 */
        [DllImport(Dll.Name)]
        public static extern Program clCreateProgramWithBuiltInKernels(
            Context context,
            uint num_devices,
            [In] DeviceId[] device_list,
            string kernel_names,
            ref Error errcode_ret);

        /* 2.1 */
        [DllImport(Dll.Name)]
        public static extern Program clCreateProgramWithIL(
            Context context,
            IntPtr il,
            SizeT length,
            ref Error errcode_ret);

        [DllImport(Dll.Name)]
        public static extern Error clRetainProgram(Program program);

        [DllImport(Dll.Name)]
        public static extern Error clReleaseProgram(Program program);

        public delegate void NotifyFunction(Program program, IntPtr user_data);

        [DllImport(Dll.Name)]
        public static extern Error clBuildProgram(
            Program program,
            uint num_devices,
            [In] DeviceId[] device_list,
            string options,
            NotifyFunction func,
            IntPtr user_data);

        [DllImport(Dll.Name)]
        public static extern Error clBuildProgram(
            Program program,
            uint num_devices,
            [In] DeviceId[] device_list,
            IntPtr options,
            NotifyFunction func,
            IntPtr user_data);

        /* 1.2 */
        [DllImport(Dll.Name)]
        public static extern Error clCompileProgram(
            Program program,
            uint num_devices,
            [In] DeviceId[] device_list,
            string options,
            uint num_input_headers,
            [In] Program[] input_headers,
            [In] IntPtr[] header_include_names,
            NotifyFunction pfn_notify,
            IntPtr user_data);

        /* 1.2 */
        [DllImport(Dll.Name)]
        public static extern Program clLinkProgram(
            Context context,
            uint num_devices,
            [In] DeviceId[] device_list,
            string options,
            uint num_input_programs,
            [In] Program[] input_programs,
            NotifyFunction pfn_notify,
            IntPtr user_data,
            ref Error errcode_ret);
        [DllImport(Dll.Name)]
        public static extern Program clLinkProgram(
            Context context,
            uint num_devices,
            [In] DeviceId[] device_list,
            string options,
            uint num_input_programs,
            [In] Program[] input_programs,
            NotifyFunction pfn_notify,
            IntPtr user_data,
            IntPtr errcode_ret);

        /* 2.2 */
        [DllImport(Dll.Name)]
        public static extern Error clSetProgramReleaseCallback(
            Program program,
            NotifyFunction pfn_notify,
            IntPtr user_data);

        /* 2.2 */
        [DllImport(Dll.Name)]
        public static extern Error clSetProgramSpecializationConstant(
            Program program,
            uint spec_id,
            SizeT spec_size,
            IntPtr spec_value);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(Dll.Name)]
        public static extern Error clUnloadCompiler();

        /* 1.2 */
        [DllImport(Dll.Name)]
        public static extern Error clUnloadPlatformCompiler(PlatformId platform);

        [DllImport(Dll.Name)]
        public static extern Error clGetProgramInfo(
            Program program,
            ProgramInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        [DllImport(Dll.Name)]
        public static extern Error clGetProgramBuildInfo(
            Program program,
            DeviceId device,
            ProgramBuildInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);
        #endregion

        #region Kernel Object APIs
        [DllImport(Dll.Name)]
        public static extern Types.Core.Net.Primitives.Kernel clCreateKernel(
            Program program,
            string kernel_name,
            ref Error errcode_ret);

        [DllImport(Dll.Name)]
        public static extern Error clCreateKernelsInProgram(
            Program program,
            uint num_kernels,
            [Out] Types.Core.Net.Primitives.Kernel[] kernels,
            ref uint num_kernels_ret);

        /* 2.1 */
        [DllImport(Dll.Name)]
        public static extern Types.Core.Net.Primitives.Kernel clCloneKernel(
            Types.Core.Net.Primitives.Kernel source_kernel,
            ref Error errcode_ret);

        [DllImport(Dll.Name)]
        public static extern Error clRetainKernel(Types.Core.Net.Primitives.Kernel kernel);

        [DllImport(Dll.Name)]
        public static extern Error clReleaseKernel(Types.Core.Net.Primitives.Kernel kernel);

        [DllImport(Dll.Name)]
        public static extern Error clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            IntPtr arg_value);
        [DllImport(Dll.Name)]
        public static extern Error clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            ref Mem arg_value);
        [DllImport(Dll.Name)]
        public static extern Error clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            ref byte arg_value);
        [DllImport(Dll.Name)]
        public static extern Error clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            [In] byte[] arg_value);
        [DllImport(Dll.Name)]
        public static extern Error clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            ref short arg_value);
        [DllImport(Dll.Name)]
        public static extern Error clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            [In] short[] arg_value);
        [DllImport(Dll.Name)]
        public static extern Error clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            ref int arg_value);
        [DllImport(Dll.Name)]
        public static extern Error clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            [In] int[] arg_value);
        [DllImport(Dll.Name)]
        public static extern Error clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            ref long arg_value);
        [DllImport(Dll.Name)]
        public static extern Error clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            [In] long[] arg_value);
        [DllImport(Dll.Name)]
        public static extern Error clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            ref float arg_value);
        [DllImport(Dll.Name)]
        public static extern Error clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            [In] float[] arg_value);
        [DllImport(Dll.Name)]
        public static extern Error clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            ref double arg_value);
        [DllImport(Dll.Name)]
        public static extern Error clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            [In] double[] arg_value);

        /* 2.0 */
        [DllImport(Dll.Name)]
        public static extern Error clSetKernelArgSVMPointer(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            IntPtr arg_value);

        /* 2.0 */
        [DllImport(Dll.Name)]
        public static extern Error clSetKernelExecInfo(
            Types.Core.Net.Primitives.Kernel kernel,
            KernelExecInfo param_name,
            SizeT param_value_size,
            IntPtr param_value);
        [DllImport(Dll.Name)]
        public static extern Error clSetKernelExecInfo(
            Types.Core.Net.Primitives.Kernel kernel,
            KernelExecInfo param_name,
            SizeT param_value_size,
            [In] IntPtr[] param_value);
        [DllImport(Dll.Name)]
        public static extern Error clSetKernelExecInfo(
            Types.Core.Net.Primitives.Kernel kernel,
            KernelExecInfo param_name,
            SizeT param_value_size,
            ref Bool param_value);

        [DllImport(Dll.Name)]
        public static extern Error clGetKernelInfo(
            Types.Core.Net.Primitives.Kernel kernel,
            KernelInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        /* 1.2 */
        [DllImport(Dll.Name)]
        public static extern Error clGetKernelArgInfo(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_indx,
            KernelArgInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        [DllImport(Dll.Name)]
        public static extern Error clGetKernelWorkGroupInfo(
            Types.Core.Net.Primitives.Kernel kernel,
            DeviceId device,
            KernelWorkGroupInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        /* 2.1 */
        [DllImport(Dll.Name)]
        public static extern Error clGetKernelSubGroupInfo(
            Types.Core.Net.Primitives.Kernel kernel,
            DeviceId device,
            KernelSubGroupInfo param_name,
            SizeT input_value_size,
            IntPtr input_value,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);
        #endregion

        #region Event Object APIs
        [DllImport(Dll.Name)]
        public static extern Error clWaitForEvents(
            uint num_events,
            [In] Event[] event_list);

        [DllImport(Dll.Name)]
        public static extern Error clGetEventInfo(
            Event e,
            EventInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        [DllImport(Dll.Name)]
        public static extern Event clCreateUserEvent(
            Context context,
            IntPtr errcode_ret);
        [DllImport(Dll.Name)]
        public static extern Event clCreateUserEvent(
            Context context,
            ref Error errcode_ret);

        [DllImport(Dll.Name)]
        public static extern Error clRetainEvent(Event e);

        [DllImport(Dll.Name)]
        public static extern Error clReleaseEvent(Event e);

        [DllImport(Dll.Name)]
        public static extern Error clSetUserEventStatus(
            Event e,
            int execution_status);
        [DllImport(Dll.Name)]
        public static extern Error clSetUserEventStatus(
            Event e,
            ExecutionStatus execution_status);

        public delegate void EventCallback(
            Event e,
            int event_command_exec_status,
            IntPtr user_data);

        [DllImport(Dll.Name)]
        public static extern Error clSetEventCallback(
            Event e,
            ExecutionStatus command_exec_callback_type,
            EventCallback pfn_notify,
            IntPtr user_data);
        #endregion

        #region Profiling APIs
        [DllImport(Dll.Name)]
        public static extern Error clGetEventProfilingInfo(
            Event e,
            ProfilingInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);
        #endregion

        #region Flush and Finish APIs
        [DllImport(Dll.Name)]
        public static extern Error clFlush(CommandQueue command_queue);

        [DllImport(Dll.Name)]
        public static extern Error clFinish(CommandQueue command_queue);
        #endregion

        #region Enqueued Commands APIs
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueReadBuffer(
            CommandQueue command_queue,
            Mem buffer,
            Bool blocking_read,
            SizeT offset,
            SizeT cb,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueReadBuffer(
            CommandQueue command_queue,
            Mem buffer,
            Bool blocking_read,
            SizeT offset,
            SizeT cb,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        /* 1.1 */
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueReadBufferRect(
            CommandQueue command_queue,
            Mem buffer,
            Bool blocking_read,
            [In] SizeT[] buffer_origin,
            [In] SizeT[] host_origin,
            [In] SizeT[] region,
            SizeT buffer_row_pitch,
            SizeT buffer_slice_pitch,
            SizeT host_row_pitch,
            SizeT host_slice_pitch,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueReadBufferRect(
            CommandQueue command_queue,
            Mem buffer,
            Bool blocking_read,
            [In] SizeT[] buffer_origin,
            [In] SizeT[] host_origin,
            [In] SizeT[] region,
            SizeT buffer_row_pitch,
            SizeT buffer_slice_pitch,
            SizeT host_row_pitch,
            SizeT host_slice_pitch,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(Dll.Name)]
        public static extern Error clEnqueueWriteBuffer(
            CommandQueue command_queue,
            Mem buffer,
            Bool blocking_write,
            SizeT offset,
            SizeT cb,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueWriteBuffer(
            CommandQueue command_queue,
            Mem buffer,
            Bool blocking_write,
            SizeT offset,
            SizeT cb,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        /* 1.1 */
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueWriteBufferRect(
            CommandQueue command_queue,
            Mem buffer,
            Bool blocking_read,
            [In] SizeT[] buffer_origin,
            [In] SizeT[] host_origin,
            [In] SizeT[] region,
            SizeT buffer_row_pitch,
            SizeT buffer_slice_pitch,
            SizeT host_row_pitch,
            SizeT host_slice_pitch,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueWriteBufferRect(
            CommandQueue command_queue,
            Mem buffer,
            Bool blocking_read,
            [In] SizeT[] buffer_origin,
            [In] SizeT[] host_origin,
            [In] SizeT[] region,
            SizeT buffer_row_pitch,
            SizeT buffer_slice_pitch,
            SizeT host_row_pitch,
            SizeT host_slice_pitch,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        /* 1.2 */
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueFillBuffer(
            CommandQueue command_queue,
            Mem buffer,
            IntPtr pattern,
            SizeT pattern_size,
            SizeT offset,
            SizeT size,
            uint  num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueFillBuffer(
            CommandQueue command_queue,
            Mem buffer,
            IntPtr pattern,
            SizeT pattern_size,
            SizeT offset,
            SizeT size,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(Dll.Name)]
        public static extern Error clEnqueueCopyBuffer(
            CommandQueue command_queue,
            Mem src_buffer,
            Mem dst_buffer,
            SizeT src_offset,
            SizeT dst_offset,
            SizeT cb,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueCopyBuffer(
            CommandQueue command_queue,
            Mem src_buffer,
            Mem dst_buffer,
            SizeT src_offset,
            SizeT dst_offset,
            SizeT cb,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(Dll.Name)]
        public static extern Error clEnqueueCopyBufferRect(
            CommandQueue command_queue,
            Mem src_buffer,
            Mem dst_buffer,
            [In] SizeT[] src_origin,
            [In] SizeT[] dst_origin,
            [In] SizeT[] region,
            SizeT src_row_pitch,
            SizeT src_slice_pitch,
            SizeT dst_row_pitch,
            SizeT dst_slice_pitch,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueCopyBufferRect(
            CommandQueue command_queue,
            Mem src_buffer,
            Mem dst_buffer,
            [In] SizeT[] src_origin,
            [In] SizeT[] dst_origin,
            [In] SizeT[] region,
            SizeT src_row_pitch,
            SizeT src_slice_pitch,
            SizeT dst_row_pitch,
            SizeT dst_slice_pitch,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(Dll.Name)]
        public static extern Error clEnqueueReadImage(
            CommandQueue command_queue,
            Mem image,
            Bool blocking_read,
            SizeT[] origin,
            SizeT[] region,
            SizeT row_pitch,
            SizeT slice_pitch,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueReadImage(
            CommandQueue command_queue,
            Mem image,
            Bool blocking_read,
            SizeT[] origin,
            SizeT[] region,
            SizeT row_pitch,
            SizeT slice_pitch,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(Dll.Name)]
        public static extern Error clEnqueueWriteImage(
            CommandQueue command_queue,
            Mem image,
            Bool blocking_write,
            SizeT[] origin,
            SizeT[] region,
            SizeT input_row_pitch,
            SizeT input_slice_pitch,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueWriteImage(
            CommandQueue command_queue,
            Mem image,
            Bool blocking_write,
            SizeT[] origin,
            SizeT[] region,
            SizeT input_row_pitch,
            SizeT input_slice_pitch,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        /* 1.2 */
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueFillImage(
            CommandQueue command_queue,
            Mem image,
            IntPtr fill_color,
            [In] SizeT[] origin,
            [In] SizeT[] region,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueFillImage(
            CommandQueue command_queue,
            Mem image,
            IntPtr fill_color,
            [In] SizeT[] origin,
            [In] SizeT[] region,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(Dll.Name)]
        public static extern Error clEnqueueCopyImage(
            CommandQueue command_queue,
            Mem src_image,
            Mem dst_image,
            SizeT[] src_origin,
            SizeT[] dst_origin,
            SizeT[] region,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueCopyImage(
            CommandQueue command_queue,
            Mem src_image,
            Mem dst_image,
            SizeT[] src_origin,
            SizeT[] dst_origin,
            SizeT[] region,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(Dll.Name)]
        public static extern Error clEnqueueCopyImageToBuffer(
            CommandQueue command_queue,
            Mem src_image,
            Mem dst_buffer,
            SizeT[] src_origin,
            SizeT[] region,
            SizeT dst_offset,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueCopyImageToBuffer(
            CommandQueue command_queue,
            Mem src_image,
            Mem dst_buffer,
            SizeT[] src_origin,
            SizeT[] region,
            SizeT dst_offset,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(Dll.Name)]
        public static extern Error clEnqueueCopyBufferToImage(
            CommandQueue command_queue,
            Mem src_buffer,
            Mem dst_image,
            SizeT src_offset,
            SizeT[] dst_origin,
            SizeT[] region,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueCopyBufferToImage(
            CommandQueue command_queue,
            Mem src_buffer,
            Mem dst_image,
            SizeT src_offset,
            SizeT[] dst_origin,
            SizeT[] region,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(Dll.Name)]
        public static extern IntPtr clEnqueueMapBuffer(
            CommandQueue command_queue,
            Mem buffer,
            Bool blocking_map,
            MapFlags map_flags,
            SizeT offset,
            SizeT cb,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e,
            ref Error errcode_ret);
        [DllImport(Dll.Name)]
        public static extern IntPtr clEnqueueMapBuffer(
            CommandQueue command_queue,
            Mem buffer,
            Bool blocking_map,
            MapFlags map_flags,
            SizeT offset,
            SizeT cb,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e,
            ref Error errcode_ret);

        [DllImport(Dll.Name)]
        public static extern IntPtr clEnqueueMapImage(
            CommandQueue command_queue,
            Mem image,
            Bool blocking_map,
            MapFlags map_flags,
            SizeT[] origin,
            SizeT[] region,
            ref SizeT image_row_pitch,
            ref SizeT image_slice_pitch,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e,
            ref Error errcode_ret);
        [DllImport(Dll.Name)]
        public static extern IntPtr clEnqueueMapImage(
            CommandQueue command_queue,
            Mem image,
            Bool blocking_map,
            MapFlags map_flags,
            SizeT[] origin,
            SizeT[] region,
            ref SizeT image_row_pitch,
            ref SizeT image_slice_pitch,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e,
            ref Error errcode_ret);

        [DllImport(Dll.Name)]
        public static extern Error clEnqueueUnmapMemObject(
            CommandQueue command_queue,
            Mem memobj,
            IntPtr mapped_ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueUnmapMemObject(
            CommandQueue command_queue,
            Mem memobj,
            IntPtr mapped_ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        /* 1.2 */
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueMigrateMemObjects(
            CommandQueue command_queue,
            uint num_mem_objects,
            [In] Mem[] mem_objects,
            MemMigrationFlags flags,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueMigrateMemObjects(
            CommandQueue command_queue,
            uint num_mem_objects,
            [In] Mem[] mem_objects,
            MemMigrationFlags flags,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(Dll.Name)]
        public static extern Error clEnqueueNDRangeKernel(
            CommandQueue command_queue,
            Types.Core.Net.Primitives.Kernel kernel,
            uint work_dim,
            [In] SizeT[] global_work_offset,
            [In] SizeT[] global_work_size,
            [In] SizeT[] local_work_size,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueNDRangeKernel(
            CommandQueue command_queue,
            Types.Core.Net.Primitives.Kernel kernel,
            uint work_dim,
            [In] SizeT[] global_work_offset,
            [In] SizeT[] global_work_size,
            [In] SizeT[] local_work_size,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [Obsolete("Deprecated since OpenCL 2.0")]
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueTask(
            CommandQueue command_queue,
            Types.Core.Net.Primitives.Kernel kernel,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [Obsolete("Deprecated since OpenCL 2.0")]
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueTask(
            CommandQueue command_queue,
            Types.Core.Net.Primitives.Kernel kernel,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        public delegate void UserFunction(IntPtr[] args);

        [DllImport(Dll.Name)]
        public static extern Error clEnqueueNativeKernel(
            CommandQueue command_queue,
            UserFunction user_func,
            [In] IntPtr[] args,
            SizeT cb_args,
            uint num_mem_objects,
            [In] Mem[] mem_list,
            [In] IntPtr[] args_mem_loc,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueNativeKernel(
            CommandQueue command_queue,
            UserFunction user_func,
            [In] IntPtr[] args,
            SizeT cb_args,
            uint num_mem_objects,
            [In] Mem[] mem_list,
            [In] IntPtr[] args_mem_loc,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueMarker(
            CommandQueue command_queue,
            ref Event e);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueWaitForEvents(
            CommandQueue command_queue,
            uint num_events,
            [In] Event[] event_list);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueBarrier(CommandQueue command_queue);

        /* 1.2 */
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueMarkerWithWaitList(
            CommandQueue command_queue,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        /* 1.2 */
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueBarrierWithWaitList(
            CommandQueue command_queue,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        /* 2.0 */
        public delegate void SVMFreeFunction(CommandQueue queue, uint num_svm_pointers, IntPtr[] svm_pointers, IntPtr user_data);
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueSVMFree(
            CommandQueue command_queue,
            uint num_svm_pointers,
            [In] IntPtr[] svm_pointers,
            SVMFreeFunction pfn_free_func,
            IntPtr user_data,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        /* 2.0 */
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueSVMMemcpy(
            CommandQueue command_queue,
            Bool blocking_copy,
            IntPtr dst_ptr,
            IntPtr src_ptr,
            SizeT size,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        /* 2.0 */
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueSVMMemFill(
            CommandQueue command_queue,
            IntPtr svm_ptr,
            IntPtr pattern,
            SizeT pattern_size,
            SizeT size,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        /* 2.0 */
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueSVMMap(
            CommandQueue command_queue,
            Bool blocking_map,
            MapFlags flags,
            IntPtr svm_ptr,
            SizeT size,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        /* 2.0 */
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueSVMUnmap(
            CommandQueue command_queue,
            IntPtr svm_ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        /* 2.1 */
        [DllImport(Dll.Name)]
        public static extern Error clEnqueueSVMMigrateMem(
            CommandQueue command_queue,
            uint num_svm_pointers,
            [In] IntPtr[] svm_pointers,
            [In] SizeT[] sizes,
            MemMigrationFlags flags,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        #endregion
    }
}