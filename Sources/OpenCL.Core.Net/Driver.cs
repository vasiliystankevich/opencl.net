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
using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Enums.Mem;
using OpenCL.Types.Core.Net.Primitives;

namespace OpenCL.Core.Net
{
    /// <summary>
    /// This class provides the driver interface to OpenCL functions.
    /// </summary>
    public class OpenCLDriver
    {
        #region Event Object APIs
        [DllImport(DllNative.Name)]
        public static extern Error clWaitForEvents(
            uint num_events,
            [In] Event[] event_list);

        [DllImport(DllNative.Name)]
        public static extern Error clGetEventInfo(
            Event e,
            EventInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);

        [DllImport(DllNative.Name)]
        public static extern Event clCreateUserEvent(
            Context context,
            IntPtr errcode_ret);
        [DllImport(DllNative.Name)]
        public static extern Event clCreateUserEvent(
            Context context,
            ref Error errcode_ret);

        [DllImport(DllNative.Name)]
        public static extern Error clRetainEvent(Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clReleaseEvent(Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clSetUserEventStatus(
            Event e,
            int execution_status);
        [DllImport(DllNative.Name)]
        public static extern Error clSetUserEventStatus(
            Event e,
            ExecutionStatus execution_status);

        public delegate void EventCallback(
            Event e,
            int event_command_exec_status,
            IntPtr user_data);

        [DllImport(DllNative.Name)]
        public static extern Error clSetEventCallback(
            Event e,
            ExecutionStatus command_exec_callback_type,
            EventCallback pfn_notify,
            IntPtr user_data);
        #endregion

        #region Profiling APIs
        [DllImport(DllNative.Name)]
        public static extern Error clGetEventProfilingInfo(
            Event e,
            ProfilingInfo param_name,
            SizeT param_value_size,
            IntPtr param_value,
            ref SizeT param_value_size_ret);
        #endregion

        #region Flush and Finish APIs
        [DllImport(DllNative.Name)]
        public static extern Error clFlush(CommandQueue command_queue);

        [DllImport(DllNative.Name)]
        public static extern Error clFinish(CommandQueue command_queue);
        #endregion

        #region Enqueued Commands APIs
        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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

        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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

        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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

        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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

        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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

        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueFillImage(
            CommandQueue command_queue,
            Mem image,
            IntPtr fill_color,
            [In] SizeT[] origin,
            [In] SizeT[] region,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueFillImage(
            CommandQueue command_queue,
            Mem image,
            IntPtr fill_color,
            [In] SizeT[] origin,
            [In] SizeT[] region,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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

        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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

        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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

        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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

        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueUnmapMemObject(
            CommandQueue command_queue,
            Mem memobj,
            IntPtr mapped_ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueUnmapMemObject(
            CommandQueue command_queue,
            Mem memobj,
            IntPtr mapped_ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueMigrateMemObjects(
            CommandQueue command_queue,
            uint num_mem_objects,
            [In] Mem[] mem_objects,
            MemMigrationFlags flags,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueMigrateMemObjects(
            CommandQueue command_queue,
            uint num_mem_objects,
            [In] Mem[] mem_objects,
            MemMigrationFlags flags,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueTask(
            CommandQueue command_queue,
            Types.Core.Net.Primitives.Kernel kernel,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);
        [Obsolete("Deprecated since OpenCL 2.0")]
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueTask(
            CommandQueue command_queue,
            Types.Core.Net.Primitives.Kernel kernel,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            IntPtr e);

        public delegate void UserFunction(IntPtr[] args);

        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueMarker(
            CommandQueue command_queue,
            ref Event e);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueWaitForEvents(
            CommandQueue command_queue,
            uint num_events,
            [In] Event[] event_list);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueBarrier(CommandQueue command_queue);

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueMarkerWithWaitList(
            CommandQueue command_queue,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueBarrierWithWaitList(
            CommandQueue command_queue,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        /* 2.0 */
        public delegate void SVMFreeFunction(CommandQueue queue, uint num_svm_pointers, IntPtr[] svm_pointers, IntPtr user_data);
        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
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
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueSVMUnmap(
            CommandQueue command_queue,
            IntPtr svm_ptr,
            uint num_events_in_wait_list,
            [In] Event[] event_wait_list,
            ref Event e);

        /* 2.1 */
        [DllImport(DllNative.Name)]
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