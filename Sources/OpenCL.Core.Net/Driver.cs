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
using OpenCL.Types.Core.Net;
using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Primitives;

namespace OpenCL.Core.Net
{
    /// <summary>
    /// This class provides the driver interface to OpenCL functions.
    /// </summary>
    public class OpenCLDriver
    {
        internal const string OPENCL_DLL_NAME = "OpenCL";

        #region Platform API
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetPlatformIDs(
            uint num_entries,
            IntPtr platforms,
            ref uint num_platforms);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetPlatformIDs(
            uint num_entries,
            [Out] PlatformId[] platforms,
            ref uint num_platforms);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetPlatformInfo(
            PlatformId platform,
            CLPlatformInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);
        #endregion

        #region Device APIs
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetDeviceIDs(
            PlatformId platform_id,
            CLDeviceType device_type,
            uint num_entries,
            [Out] DeviceId[] devices,
            ref uint num_devices);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetDeviceIDs(
            PlatformId platform_id,
            CLDeviceType device_type,
            uint num_entries,
            IntPtr devices,
            ref uint num_devices);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetDeviceInfo(
            DeviceId device,
            CLDeviceInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        /* 1.2 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clCreateSubDevices(
            DeviceId in_device,
            [In] IntPtr[] properties,
            uint num_devices,
            [In, Out] DeviceId[] out_devices,
            ref uint num_devices_ret);

        /* 1.2 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clRetainDevice(DeviceId device);

        /* 1.2 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clReleaseDevice(DeviceId device);

        /* 2.1 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetDefaultDeviceCommandQueue(
            Context context,
            DeviceId device,
            CommandQueue command_queue);

        /* 2.1 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetDeviceAndHostTimer(
            DeviceId device,
            ref ulong device_timestamp,
            ref ulong host_timestamp);

        /* 2.1 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetHostTimer(
            DeviceId device,
            ref ulong host_timestamp);
        #endregion

        #region Context APIs
        public delegate void LoggingFunction(
            IntPtr errinfo,
            IntPtr private_info,
            SizeT cb,
            IntPtr user_data);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern Context clCreateContext(
            [In] IntPtr[] properties,
            uint num_devices,
            [In] DeviceId[] devices,
            LoggingFunction pfn_notify,
            IntPtr user_data,
            ref CLError errcode_ret);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern Context clCreateContextFromType(
            [In] IntPtr[] properties,
            CLDeviceType device_type,
            LoggingFunction pfn_notify,
            IntPtr user_data,
            ref CLError errcode_ret);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clRetainContext(Context context);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clReleaseContext(Context context);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetContextInfo(
            Context context,
            CLContextInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);
        #endregion

        #region Command Queue APIs
        [Obsolete("Deprecated since OpenCL 2.0")]
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CommandQueue clCreateCommandQueue(
            Context context,
            DeviceId device,
            CLCommandQueueProperties properties,
            ref CLError errcode_ret);

        /* 2.0 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CommandQueue clCreateCommandQueueWithProperties(
            Context context,
            DeviceId device,
            [In] IntPtr[] properties,
            ref CLError errcode_ret);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CommandQueue clCreateCommandQueueWithProperties(
            Context context,
            DeviceId device,
            [In] IntPtr[] properties,
            IntPtr errcode_ret);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clRetainCommandQueue(CommandQueue command_queue);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clReleaseCommandQueue(CommandQueue command_queue);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetCommandQueueInfo(
            CommandQueue command_queue,
            CLCommandQueueInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        [Obsolete("Deprecated since OpenCL 1.1")]
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetCommandQueueProperty(
            CommandQueue command_queue,
            CLCommandQueueProperties properties,
            CLBool enable,
            ref CLCommandQueueProperties old_properties);
        #endregion

        #region Memory Object APIs
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Mem clCreateBuffer(
            Context context,
            CLMemFlags flags,
            SizeT size,
            IntPtr host_ptr,
            ref CLError errcode_ret);

        /* 1.1 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Mem clCreateSubBuffer(
            Mem buffer,
            CLMemFlags flags,
            CLBufferCreateType buffer_create_type,
            IntPtr buffer_create_info,
            ref CLError errcode_ret);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Mem clCreateSubBuffer(
            Mem buffer,
            CLMemFlags flags,
            CLBufferCreateType buffer_create_type,
            [MarshalAs(UnmanagedType.LPStruct)]
            BufferRegion buffer_create_info,
            ref CLError errcode_ret);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Mem clCreateImage2D(
            Context context,
            CLMemFlags flags,
            ref ImageFormat image_format,
            SizeT image_width,
            SizeT image_height,
            SizeT image_row_pitch,
            IntPtr host_ptr,
            ref CLError errcode_ret);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Mem clCreateImage3D(
            Context context,
            CLMemFlags flags,
            ref ImageFormat image_format,
            SizeT image_width,
            SizeT image_height,
            SizeT image_depth,
            SizeT image_row_pitch,
            SizeT image_slice_pitch,
            IntPtr host_ptr,
            ref CLError errcode_ret);

        /* 1.2 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Mem clCreateImage(
            Context context,
            CLMemFlags flags,
            [MarshalAs(UnmanagedType.LPStruct)]
            ImageFormat image_format,
            [MarshalAs(UnmanagedType.LPStruct)]
            ImageDesc image_desc,
            IntPtr host_ptr,
            ref CLError errcode_ret);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Mem clCreateImage(
            Context context,
            CLMemFlags flags,
            [MarshalAs(UnmanagedType.LPStruct)]
            ImageFormat image_format,
            [MarshalAs(UnmanagedType.LPStruct)]
            ImageDesc image_desc,
            IntPtr host_ptr,
            IntPtr errcode_ret);

        /* 2.0 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Mem clCreatePipe(
            Context context,
            CLMemFlags flags,
            uint pipe_packet_size,
            uint pipe_max_packets,
            [In] IntPtr[] properties,
            ref CLError errcode_ret);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Mem clCreatePipe(
            Context context,
            CLMemFlags flags,
            uint pipe_packet_size,
            uint pipe_max_packets,
            [In] IntPtr[] properties,
            IntPtr errcode_ret);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clRetainMemObject(Mem memobj);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clReleaseMemObject(Mem memobj);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetSupportedImageFormats(
            Context context,
            CLMemFlags flags,
            CLMemObjectType image_type,
            uint num_entries,
            IntPtr image_formats,
            ref uint num_image_formats);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetSupportedImageFormats(
            Context context,
            CLMemFlags flags,
            CLMemObjectType image_type,
            uint num_entries,
            [Out] ImageFormat[] image_formats,
            ref uint num_image_formats);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetMemObjectInfo(
            Mem memobj,
            CLMemInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetImageInfo(
            Mem image,
            CLImageInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        /* 2.0 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetPipeInfo(
            Mem pipe,
            CLPipeInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        /* 1.1 */
        public delegate void DestructionFunction(
            Mem memobj, 
            IntPtr user_data);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetMemObjectDestructorCallback(
            Mem memobj,
            DestructionFunction pfn_notify,
            IntPtr user_data);
        #endregion

        /* 2.0 */
        #region SVM Allocation APIs
        [DllImport(OPENCL_DLL_NAME)]
        public static extern IntPtr clSVMAlloc(
            Context context,
            CLSVMMemFlags flags,
            SizeT size,
            uint alignment);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern void clSVMFree(
            Context context,
            IntPtr svm_pointer);
        #endregion

        #region Sampler APIs
        [Obsolete("Deprecated since OpenCL 2.0")]
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Sampler clCreateSampler(
            Context context,
            CLBool normalized_coords,
            CLAddressingMode addressing_mode,
            CLFilterMode filter_mode,
            ref CLError errcode_ret);

        /* 2.0 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Sampler clCreateSamplerWithProperties(
            Context context,
            [In] IntPtr[] sampler_properties,
            ref CLError errcode_ret);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Sampler clCreateSamplerWithProperties(
            Context context,
            [In] IntPtr[] sampler_properties,
            IntPtr errcode_ret);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clRetainSampler(Sampler sampler);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clReleaseSampler(Sampler sampler);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetSamplerInfo(
            Sampler sampler,
            CLSamplerInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);
        #endregion

        #region Program Object APIs
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Program clCreateProgramWithSource(
            Context context,
            uint count,
            IntPtr strings,
            [In] SizeT[] lengths,
            ref CLError errcode_ret);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Program clCreateProgramWithSource(
            Context context,
            uint count,
            [In] string[] strings,
            [In] SizeT[] lengths,
            ref CLError errcode_ret);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Program clCreateProgramWithSource(
            Context context,
            uint count,
            [In] IntPtr[] strings,
            [In] SizeT[] lengths,
            ref CLError errcode_ret);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern Program clCreateProgramWithBinary(
            Context context,
            uint num_devices,
            [In] DeviceId[] device_list,
            [In] SizeT[] lengths,
            [In] IntPtr[] binaries,
            [In, Out] int[] binary_status,
            ref CLError errcode_ret);

        /* 1.2 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Program clCreateProgramWithBuiltInKernels(
            Context context,
            uint num_devices,
            [In] DeviceId[] device_list,
            string kernel_names,
            ref CLError errcode_ret);

        /* 2.1 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Program clCreateProgramWithIL(
            Context context,
            IntPtr il,
            SizeT length,
            ref CLError errcode_ret);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clRetainProgram(Program program);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clReleaseProgram(Program program);

        public delegate void NotifyFunction(Program program, IntPtr user_data);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clBuildProgram(
            Program program,
            uint num_devices,
            [In] DeviceId[] device_list,
            string options,
            NotifyFunction func,
            IntPtr user_data);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clBuildProgram(
            Program program,
            uint num_devices,
            [In] DeviceId[] device_list,
            IntPtr options,
            NotifyFunction func,
            IntPtr user_data);

        /* 1.2 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clCompileProgram(
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
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Program clLinkProgram(
            Context context,
            uint num_devices,
            [In] DeviceId[] device_list,
            string options,
            uint num_input_programs,
            [In] Program[] input_programs,
            NotifyFunction pfn_notify,
            IntPtr user_data,
            ref CLError errcode_ret);
        [DllImport(OPENCL_DLL_NAME)]
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
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetProgramReleaseCallback(
            Program program,
            NotifyFunction pfn_notify,
            IntPtr user_data);

        /* 2.2 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetProgramSpecializationConstant(
            Program program,
            uint spec_id,
            SizeT spec_size,
            IntPtr spec_value);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clUnloadCompiler();

        /* 1.2 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clUnloadPlatformCompiler(PlatformId platform);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetProgramInfo(
            Program program,
            CLProgramInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetProgramBuildInfo(
            Program program,
            DeviceId device,
            CLProgramBuildInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);
        #endregion

        #region Kernel Object APIs
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Types.Core.Net.Primitives.Kernel clCreateKernel(
            Program program,
            string kernel_name,
            ref CLError errcode_ret);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clCreateKernelsInProgram(
            Program program,
            uint num_kernels,
            [Out] Types.Core.Net.Primitives.Kernel[] kernels,
            ref uint num_kernels_ret);

        /* 2.1 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Types.Core.Net.Primitives.Kernel clCloneKernel(
            Types.Core.Net.Primitives.Kernel source_kernel,
            ref CLError errcode_ret);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clRetainKernel(Types.Core.Net.Primitives.Kernel kernel);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clReleaseKernel(Types.Core.Net.Primitives.Kernel kernel);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            IntPtr arg_value);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            ref Mem arg_value);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            ref byte arg_value);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            [In] byte[] arg_value);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            ref short arg_value);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            [In] short[] arg_value);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            ref int arg_value);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            [In] int[] arg_value);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            ref long arg_value);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            [In] long[] arg_value);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            ref float arg_value);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            [In] float[] arg_value);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            ref double arg_value);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelArg(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            SizeT arg_size,
            [In] double[] arg_value);

        /* 2.0 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelArgSVMPointer(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_index,
            IntPtr arg_value);

        /* 2.0 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelExecInfo(
            Types.Core.Net.Primitives.Kernel kernel,
            CLKernelExecInfo param_name,
            SizeT param_value_size,
            IntPtr param_value);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelExecInfo(
            Types.Core.Net.Primitives.Kernel kernel,
            CLKernelExecInfo param_name,
            SizeT param_value_size,
            [In] IntPtr[] param_value);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetKernelExecInfo(
            Types.Core.Net.Primitives.Kernel kernel,
            CLKernelExecInfo param_name,
            SizeT param_value_size,
            ref CLBool param_value);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetKernelInfo(
            Types.Core.Net.Primitives.Kernel kernel,
            CLKernelInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        /* 1.2 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetKernelArgInfo(
            Types.Core.Net.Primitives.Kernel kernel,
            uint arg_indx,
            CLKernelArgInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetKernelWorkGroupInfo(
            Types.Core.Net.Primitives.Kernel kernel,
            DeviceId device,
            CLKernelWorkGroupInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        /* 2.1 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetKernelSubGroupInfo(
            Types.Core.Net.Primitives.Kernel kernel,
            DeviceId device,
            CLKernelSubGroupInfo param_name,
            SizeT input_value_size,
            IntPtr input_value,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);
        #endregion

        #region Event Object APIs
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clWaitForEvents(
            uint num_events,
            [In] Event[] event_list);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetEventInfo(
            Event e,
            CLEventInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern Event clCreateUserEvent(
            Context context,
            IntPtr errcode_ret);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern Event clCreateUserEvent(
            Context context,
            ref CLError errcode_ret);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clRetainEvent(Event e);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clReleaseEvent(Event e);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetUserEventStatus(
            Event e,
            int execution_status);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetUserEventStatus(
            Event e,
            CLExecutionStatus execution_status);

        public delegate void EventCallback(
            Event e,
            int event_command_exec_status,
            IntPtr user_data);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clSetEventCallback(
            Event e,
            CLExecutionStatus command_exec_callback_type,
            EventCallback pfn_notify,
            IntPtr user_data);
        #endregion

        #region Profiling APIs
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clGetEventProfilingInfo(
            Event e,
            CLProfilingInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);
        #endregion

        #region Flush and Finish APIs
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clFlush(CommandQueue command_queue);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clFinish(CommandQueue command_queue);
        #endregion

        #region Enqueued Commands APIs
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueReadBuffer(
            CommandQueue command_queue,
            Mem buffer,
            CLBool blocking_read,
            SizeT offset,
            SizeT cb,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueReadBuffer(
            CommandQueue command_queue,
            Mem buffer,
            CLBool blocking_read,
            SizeT offset,
            SizeT cb,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        /* 1.1 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueReadBufferRect(
            CommandQueue command_queue,
            Mem buffer,
            CLBool blocking_read,
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
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueReadBufferRect(
            CommandQueue command_queue,
            Mem buffer,
            CLBool blocking_read,
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

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueWriteBuffer(
            CommandQueue command_queue,
            Mem buffer,
            CLBool blocking_write,
            SizeT offset,
            SizeT cb,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueWriteBuffer(
            CommandQueue command_queue,
            Mem buffer,
            CLBool blocking_write,
            SizeT offset,
            SizeT cb,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        /* 1.1 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueWriteBufferRect(
            CommandQueue command_queue,
            Mem buffer,
            CLBool blocking_read,
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
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueWriteBufferRect(
            CommandQueue command_queue,
            Mem buffer,
            CLBool blocking_read,
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
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueFillBuffer(
            CommandQueue command_queue,
            Mem buffer,
            IntPtr pattern,
            SizeT pattern_size,
            SizeT offset,
            SizeT size,
            uint  num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueFillBuffer(
            CommandQueue command_queue,
            Mem buffer,
            IntPtr pattern,
            SizeT pattern_size,
            SizeT offset,
            SizeT size,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueCopyBuffer(
            CommandQueue command_queue,
            Mem src_buffer,
            Mem dst_buffer,
            SizeT src_offset,
            SizeT dst_offset,
            SizeT cb,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueCopyBuffer(
            CommandQueue command_queue,
            Mem src_buffer,
            Mem dst_buffer,
            SizeT src_offset,
            SizeT dst_offset,
            SizeT cb,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueCopyBufferRect(
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
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueCopyBufferRect(
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

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueReadImage(
            CommandQueue command_queue,
            Mem image,
            CLBool blocking_read,
            SizeT[] origin,
            SizeT[] region,
            SizeT row_pitch,
            SizeT slice_pitch,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueReadImage(
            CommandQueue command_queue,
            Mem image,
            CLBool blocking_read,
            SizeT[] origin,
            SizeT[] region,
            SizeT row_pitch,
            SizeT slice_pitch,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueWriteImage(
            CommandQueue command_queue,
            Mem image,
            CLBool blocking_write,
            SizeT[] origin,
            SizeT[] region,
            SizeT input_row_pitch,
            SizeT input_slice_pitch,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueWriteImage(
            CommandQueue command_queue,
            Mem image,
            CLBool blocking_write,
            SizeT[] origin,
            SizeT[] region,
            SizeT input_row_pitch,
            SizeT input_slice_pitch,
            IntPtr ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        /* 1.2 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueFillImage(
            CommandQueue command_queue,
            Mem image,
            IntPtr fill_color,
            [In] SizeT[] origin,
            [In] SizeT[] region,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueFillImage(
            CommandQueue command_queue,
            Mem image,
            IntPtr fill_color,
            [In] SizeT[] origin,
            [In] SizeT[] region,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueCopyImage(
            CommandQueue command_queue,
            Mem src_image,
            Mem dst_image,
            SizeT[] src_origin,
            SizeT[] dst_origin,
            SizeT[] region,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueCopyImage(
            CommandQueue command_queue,
            Mem src_image,
            Mem dst_image,
            SizeT[] src_origin,
            SizeT[] dst_origin,
            SizeT[] region,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueCopyImageToBuffer(
            CommandQueue command_queue,
            Mem src_image,
            Mem dst_buffer,
            SizeT[] src_origin,
            SizeT[] region,
            SizeT dst_offset,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueCopyImageToBuffer(
            CommandQueue command_queue,
            Mem src_image,
            Mem dst_buffer,
            SizeT[] src_origin,
            SizeT[] region,
            SizeT dst_offset,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueCopyBufferToImage(
            CommandQueue command_queue,
            Mem src_buffer,
            Mem dst_image,
            SizeT src_offset,
            SizeT[] dst_origin,
            SizeT[] region,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueCopyBufferToImage(
            CommandQueue command_queue,
            Mem src_buffer,
            Mem dst_image,
            SizeT src_offset,
            SizeT[] dst_origin,
            SizeT[] region,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern IntPtr clEnqueueMapBuffer(
            CommandQueue command_queue,
            Mem buffer,
            CLBool blocking_map,
            CLMapFlags map_flags,
            SizeT offset,
            SizeT cb,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e,
            ref CLError errcode_ret);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern IntPtr clEnqueueMapBuffer(
            CommandQueue command_queue,
            Mem buffer,
            CLBool blocking_map,
            CLMapFlags map_flags,
            SizeT offset,
            SizeT cb,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e,
            ref CLError errcode_ret);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern IntPtr clEnqueueMapImage(
            CommandQueue command_queue,
            Mem image,
            CLBool blocking_map,
            CLMapFlags map_flags,
            SizeT[] origin,
            SizeT[] region,
            ref SizeT image_row_pitch,
            ref SizeT image_slice_pitch,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e,
            ref CLError errcode_ret);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern IntPtr clEnqueueMapImage(
            CommandQueue command_queue,
            Mem image,
            CLBool blocking_map,
            CLMapFlags map_flags,
            SizeT[] origin,
            SizeT[] region,
            ref SizeT image_row_pitch,
            ref SizeT image_slice_pitch,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e,
            ref CLError errcode_ret);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueUnmapMemObject(
            CommandQueue command_queue,
            Mem memobj,
            IntPtr mapped_ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueUnmapMemObject(
            CommandQueue command_queue,
            Mem memobj,
            IntPtr mapped_ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        /* 1.2 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueMigrateMemObjects(
            CommandQueue command_queue,
            uint num_mem_objects,
            [In] Mem[] mem_objects,
            CLMemMigrationFlags flags,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueMigrateMemObjects(
            CommandQueue command_queue,
            uint num_mem_objects,
            [In] Mem[] mem_objects,
            CLMemMigrationFlags flags,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueNDRangeKernel(
            CommandQueue command_queue,
            Types.Core.Net.Primitives.Kernel kernel,
            uint work_dim,
            [In] SizeT[] global_work_offset,
            [In] SizeT[] global_work_size,
            [In] SizeT[] local_work_size,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueNDRangeKernel(
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
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueTask(
            CommandQueue command_queue,
            Types.Core.Net.Primitives.Kernel kernel,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [Obsolete("Deprecated since OpenCL 2.0")]
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueTask(
            CommandQueue command_queue,
            Types.Core.Net.Primitives.Kernel kernel,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        public delegate void UserFunction(IntPtr[] args);

        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueNativeKernel(
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
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueNativeKernel(
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
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueMarker(
            CommandQueue command_queue,
            ref Event e);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueWaitForEvents(
            CommandQueue command_queue,
            uint num_events,
            [In] Event[] event_list);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueBarrier(CommandQueue command_queue);

        /* 1.2 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueMarkerWithWaitList(
            CommandQueue command_queue,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        /* 1.2 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueBarrierWithWaitList(
            CommandQueue command_queue,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        /* 2.0 */
        public delegate void SVMFreeFunction(CommandQueue queue, uint num_svm_pointers, IntPtr[] svm_pointers, IntPtr user_data);
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueSVMFree(
            CommandQueue command_queue,
            uint num_svm_pointers,
            [In] IntPtr[] svm_pointers,
            SVMFreeFunction pfn_free_func,
            IntPtr user_data,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        /* 2.0 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueSVMMemcpy(
            CommandQueue command_queue,
            CLBool blocking_copy,
            IntPtr dst_ptr,
            IntPtr src_ptr,
            SizeT size,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        /* 2.0 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueSVMMemFill(
            CommandQueue command_queue,
            IntPtr svm_ptr,
            IntPtr pattern,
            SizeT pattern_size,
            SizeT size,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        /* 2.0 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueSVMMap(
            CommandQueue command_queue,
            CLBool blocking_map,
            CLMapFlags flags,
            IntPtr svm_ptr,
            SizeT size,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        /* 2.0 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueSVMUnmap(
            CommandQueue command_queue,
            IntPtr svm_ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        /* 2.1 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern CLError clEnqueueSVMMigrateMem(
            CommandQueue command_queue,
            uint num_svm_pointers,
            [In] IntPtr[] svm_pointers,
            [In] SizeT[] sizes,
            CLMemMigrationFlags flags,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        #endregion

        #region Extension function access
        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(OPENCL_DLL_NAME)]
        public static extern IntPtr clGetExtensionFunctionAddress(string func_name);

        /* 1.2 */
        [DllImport(OPENCL_DLL_NAME)]
        public static extern IntPtr clGetExtensionFunctionAddressForPlatform(
            PlatformId platform,
            string func_name);
        #endregion
    }
}
