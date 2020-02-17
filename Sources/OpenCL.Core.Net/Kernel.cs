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
    /// This class provides object oriented access to OpenCL(TM) driver API 
    /// and further utilities for simpler programming.
    /// 
    /// There are three ways to instantiate this class:
    /// 1. Specify a single device - a context will be created with given 
    /// information.
    /// 2. Specify multiple devices - a context will be created with given 
    /// information and sharing of listed devices.
    /// 3. Specify a previously created context. A new context will not be 
    /// created, but the reference count of the specified context will be incremented by 1.
    /// 
    /// Throughout the lifetime of an instance, a single context can be created.
    /// </summary>
    public class Kernel : IDisposable
    {
        #region Constructors
        /// <summary>
        /// Creates a new instance, with an OpenCL(TM) context created using the given 
        /// platform and device.
        /// </summary>
        /// <param name="platform">Platform for OpenCL(TM) context creation.</param>
        /// <param name="device">Device to include in OpenCL(TM) context.</param>
        public Kernel(PlatformId platform, DeviceId device) : 
            this(platform, new DeviceId[] { device })
        { }

        /// <summary>
        /// Creates a new instance, with an OpenCL(TM) context created using the given 
        /// platform and multiple devices.
        /// </summary>
        /// <param name="platform">Platform for OpenCL(TM) context creation.</param>
        /// <param name="devices">Devices to include in OpenCL(TM) context.</param>
        public Kernel(PlatformId platform, DeviceId[] devices)
        {
            IntPtr[] ctxProperties = new IntPtr[3];
            ctxProperties[0] = new IntPtr((int)ContextProperties.Platform);
            ctxProperties[1] = platform.Value;
            ctxProperties[2] = IntPtr.Zero;

            // Create OpenCL context from given platform and device.
            Context ctx = OpenCLDriver.clCreateContext(ctxProperties, (uint)devices.Length, devices, null, IntPtr.Zero, ref clError);
            ThrowCLException(clError);

            Context = ctx;
            Devices = devices;
            LastEnqueueEvent = new Event();
        }

        /// <summary>
        /// Creates a new instance from already existing OpenCL(TM) context.
        /// Perform a retain of the context.
        /// </summary>
        /// <param name="ctx">OpenCL(TM) context to use.</param>
        public Kernel(Context ctx)
        {
            clError = OpenCLDriver.clRetainContext(ctx);
            ThrowCLException(clError);

            Context = ctx;
        }
        #endregion

        #region Destructor / IDisposable
        /// <summary>
        /// Disposes OpenCL(TM) context (release).
        /// </summary>
        public void Dispose()
        {
            if (disposed)
            {
                return;
            }

            clError = OpenCLDriver.clReleaseContext(ctx);
            ThrowCLException(clError);

            disposed = true;
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~Kernel()
        {
            Dispose();
        }
        #endregion

        #region Context Functions
        /// <summary>
        /// Returns requested information about the context of the instance.
        /// </summary>
        /// <param name="info">Requested information.</param>
        /// <returns>Value which depends on the type of information requested.</returns>
        public object GetContextInfo(ContextInfo info)
        {
            return GetContextInfo(ctx, info);
        }
        #endregion

        #region Queue Functions
        public CommandQueue CreateCommandQueue(DeviceId device)
        {
            return CreateCommandQueue(device, 0);
        }

        public CommandQueue CreateCommandQueue(DeviceId device, 
            CommandQueueProperties properties)
        {
            CommandQueue queue = OpenCLDriver.clCreateCommandQueue(ctx, device, properties, ref clError);
            ThrowCLException(clError);

            return queue;
        }

        public void RetainCommandQueue(CommandQueue command_queue)
        {
            clError = OpenCLDriver.clRetainCommandQueue(command_queue);
            ThrowCLException(clError);
        }

        public void ReleaseCommandQueue(CommandQueue command_queue)
        {
            clError = OpenCLDriver.clReleaseCommandQueue(command_queue);
            ThrowCLException(clError);
        }

        public void Flush(CommandQueue command_queue)
        {
            clError = OpenCLDriver.clFlush(command_queue);
            ThrowCLException(clError);
        }

        public void Finish(CommandQueue command_queue)
        {
            clError = OpenCLDriver.clFinish(command_queue);
            ThrowCLException(clError);
        }
        #endregion

        #region Memory Functions
        public Mem CreateBuffer(SizeT sizeInBytes)
        {
            return CreateBuffer(CLMemFlags.ReadWrite, sizeInBytes);
        }

        public Mem CreateBuffer(CLMemFlags flags, SizeT sizeInBytes)
        {
            Mem buffer = OpenCLDriver.clCreateBuffer(ctx, flags, sizeInBytes, IntPtr.Zero, ref clError);
            ThrowCLException(clError);

            return buffer;
        }

        public Mem CreateImage2D(CLMemFlags flags, ImageFormat format, 
            SizeT width, SizeT height, SizeT rowPitchInBytes)
        {
            Mem image = OpenCLDriver.clCreateImage2D(ctx, flags, ref format, 
                width, height, rowPitchInBytes, IntPtr.Zero, ref clError);
            ThrowCLException(clError);

            return image;
        }

        public Mem CreateImage3D(CLMemFlags flags, ImageFormat format,
            SizeT width, SizeT height, SizeT depth,
            SizeT rowPitchInBytes, SizeT slicePitchInBytes)
        {
            Mem image = OpenCLDriver.clCreateImage3D(ctx, flags, ref format,
                width, height, depth, rowPitchInBytes, slicePitchInBytes, 
                IntPtr.Zero, ref clError);
            ThrowCLException(clError);

            return image;
        }

        public void RetainMemObject(Mem obj)
        {
            clError = OpenCLDriver.clRetainMemObject(obj);
            ThrowCLException(clError);
        }

        public void ReleaseMemObject(Mem obj)
        {
            clError = OpenCLDriver.clReleaseMemObject(obj);
            ThrowCLException(clError);
        }

        public ImageFormat[] GetSupportedImageFormats(CLMemFlags flags, CLMemObjectType imageType)
        {
            uint numImageFormats = 0;
            clError = OpenCLDriver.clGetSupportedImageFormats(ctx, flags, 
                imageType, 0, IntPtr.Zero, ref numImageFormats);
            ThrowCLException(clError);

            if (numImageFormats < 1)
            {
                return new ImageFormat[0];
            }

            ImageFormat[] formats = new ImageFormat[numImageFormats];
            clError = OpenCLDriver.clGetSupportedImageFormats(ctx, flags,
                imageType, numImageFormats, formats, ref numImageFormats);
            ThrowCLException(clError);

            return formats;
        }
        #endregion

        #region Program Functions
        public Program CreateProgramWithSource(string source)
        {
            return CreateProgramWithSource(new string[] { source });
        }

        public Program CreateProgramWithSource(string[] sources)
        {
            SizeT[] lengths = new SizeT[sources.Length];
            for (int i = 0; i < sources.Length; i++)
			{
                lengths[i] = sources[i].Length;
			}

            Program program = OpenCLDriver.clCreateProgramWithSource(ctx, 
                (uint)sources.Length, sources, lengths, ref clError);
            ThrowCLException(clError);

            return program;
        }

        public Program CreateProgramWithBinary(byte[] binary)
        {
            return CreateProgramWithBinary(new byte[][] { binary });
        }

        public Program CreateProgramWithBinary(byte[][] binaries)
        {
            SizeT[] lengths = new SizeT[binaries.Length];
            for (int i = 0; i < binaries.Length; i++)
            {
                lengths[i] = binaries[i].Length;
            }

            // Allocate native pointers for binaries and copy data.
            IntPtr[] ptrToBinaries = new IntPtr[binaries.Length];
            try
            {
                for (int i = 0; i < binaries.Length; i++)
                {
                    ptrToBinaries[i] = Marshal.AllocHGlobal(lengths[i]);

                    Marshal.Copy(binaries[i], 0, ptrToBinaries[i], lengths[i]);
                }
            
                int[] binaryStatus = new int[binaries.Length];

                Program program = OpenCLDriver.clCreateProgramWithBinary(ctx,
                    (uint)Devices.Length, Devices, lengths, ptrToBinaries, binaryStatus, ref clError);
                ThrowCLException(clError);

                return program;
            }
            finally
            {
                for (int i = 0; i < ptrToBinaries.Length; i++)
                {
                    if (ptrToBinaries[i] != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(ptrToBinaries[i]);
                    }
                }
            }
        }

        public void RetainProgram(Program program)
        {
            clError = OpenCLDriver.clRetainProgram(program);
            ThrowCLException(clError);
        }

        public void ReleaseProgram(Program program)
        {
            clError = OpenCLDriver.clReleaseProgram(program);
            ThrowCLException(clError);
        }

        public void BuildProgram(Program program, DeviceId[] devices, string options)
        {
            clError = OpenCLDriver.clBuildProgram(program, (uint)devices.Length, 
                devices, options, null, IntPtr.Zero);
            ThrowCLException(clError);
        }
        #endregion

        #region Kernel Functions
        public Types.Core.Net.Primitives.Kernel CreateKernel(Program program, string kernelName)
        {
            Types.Core.Net.Primitives.Kernel kernel = OpenCLDriver.clCreateKernel(program, kernelName, ref clError);
            ThrowCLException(clError);

            return kernel;
        }

        public void RetainKernel(Types.Core.Net.Primitives.Kernel kernel)
        {
            clError = OpenCLDriver.clRetainKernel(kernel);
            ThrowCLException(clError);
        }

        public void ReleaseKernel(Types.Core.Net.Primitives.Kernel kernel)
        {
            clError = OpenCLDriver.clReleaseKernel(kernel);
            ThrowCLException(clError);
        }

        #region SetKernelArg
        public void SetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint index, byte value)
        {
            clError = OpenCLDriver.clSetKernelArg(kernel, index, sizeof(byte), ref value);
            ThrowCLException(clError);
        }

        public void SetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint index, short value)
        {
            clError = OpenCLDriver.clSetKernelArg(kernel, index, sizeof(short), ref value);
            ThrowCLException(clError);
        }

        public void SetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint index, int value)
        {
            clError = OpenCLDriver.clSetKernelArg(kernel, index, sizeof(int), ref value);
            ThrowCLException(clError);
        }

        public void SetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint index, long value)
        {
            clError = OpenCLDriver.clSetKernelArg(kernel, index, sizeof(long), ref value);
            ThrowCLException(clError);
        }

        public void SetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint index, float value)
        {
            clError = OpenCLDriver.clSetKernelArg(kernel, index, sizeof(float), ref value);
            ThrowCLException(clError);
        }

        public void SetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint index, double value)
        {
            clError = OpenCLDriver.clSetKernelArg(kernel, index, sizeof(double), ref value);
            ThrowCLException(clError);
        }

        public void SetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint index, Mem value)
        {
            clError = OpenCLDriver.clSetKernelArg(kernel, index, Marshal.SizeOf(value), ref value);
            ThrowCLException(clError);
        }

        public void SetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint index, byte[] value)
        {
            clError = OpenCLDriver.clSetKernelArg(kernel, index, sizeof(byte) * value.Length, value);
            ThrowCLException(clError);
        }

        public void SetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint index, short[] value)
        {
            clError = OpenCLDriver.clSetKernelArg(kernel, index, sizeof(short) * value.Length, value);
            ThrowCLException(clError);
        }

        public void SetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint index, int[] value)
        {
            clError = OpenCLDriver.clSetKernelArg(kernel, index, sizeof(int) * value.Length, value);
            ThrowCLException(clError);
        }

        public void SetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint index, long[] value)
        {
            clError = OpenCLDriver.clSetKernelArg(kernel, index, sizeof(long) * value.Length, value);
            ThrowCLException(clError);
        }

        public void SetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint index, float[] value)
        {
            clError = OpenCLDriver.clSetKernelArg(kernel, index, sizeof(float) * value.Length, value);
            ThrowCLException(clError);
        }

        public void SetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint index, double[] value)
        {
            clError = OpenCLDriver.clSetKernelArg(kernel, index, sizeof(double) * value.Length, value);
            ThrowCLException(clError);
        }
        #endregion
        #endregion

        #region Event Functions
        //TODO: Add event functions.
        #endregion

        #region Enqueue Functions
        public void ReadBuffer<T>(CommandQueue queue, Mem buffer, Bool blocking, SizeT offset, SizeT cb, T[] dst)
        {
            GCHandle h = GCHandle.Alloc(dst, GCHandleType.Pinned);

            try
            {
                clError = OpenCLDriver.clEnqueueReadBuffer(queue, buffer, blocking, offset, cb, h.AddrOfPinnedObject(), 0, null, ref lastOperationEvent);
                ThrowCLException(clError);
            }
            finally
            {
                h.Free();
            }
        }

        public void WriteBuffer<T>(CommandQueue queue, Mem buffer, Bool blocking, SizeT offset, SizeT cb, T[] src)
        {
            GCHandle h = GCHandle.Alloc(src, GCHandleType.Pinned);

            try
            {
                clError = OpenCLDriver.clEnqueueWriteBuffer(queue, buffer, blocking, offset, cb, h.AddrOfPinnedObject(), 0, null, ref lastOperationEvent);
                ThrowCLException(clError);
            }
            finally
            {
                h.Free();
            }
        }

        public void NDRangeKernel(CommandQueue queue, Types.Core.Net.Primitives.Kernel kernel, uint work_dim,
            SizeT[] global_work_offset, SizeT[] global_work_size, SizeT[] local_work_size)
        {
            clError = OpenCLDriver.clEnqueueNDRangeKernel(queue, kernel, work_dim, global_work_offset, global_work_size, local_work_size, 0, null, ref lastOperationEvent);
            ThrowCLException(clError);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets last OpenCL(TM) error that occured when calling an API function.
        /// </summary>
        public Error LastCLError
        {
            get { return clError; }
        }

        /// <summary>
        /// Gets OpenCL(TM) context used by this instance.
        /// </summary>
        public Context Context
        {
            get { return ctx; }
            private set { ctx = value; }
        }

        /// <summary>
        /// Gets devices attached to the current context.
        /// </summary>
        public DeviceId[] Devices { get; private set; }

        /// <summary>
        /// Gets the event associated with the last enqueue operation.
        /// </summary>
        public Event LastEnqueueEvent
        {
            get
            {
                return lastOperationEvent;
            }

            private set
            {
                lastOperationEvent = value;
            }
        }
        #endregion

        #region Internal Variables
        private Error clError;
        private Context ctx;

        private bool disposed = false;
        #endregion

        #region Platform Utilities
        /// <summary>
        /// Returns an array of available platforms in the system.
        /// If no platform is found, an array with zero elements is returned.
        /// </summary>
        /// <returns>An array of available platforms in the system.</returns>
        public static PlatformId[] GetPlatforms()
        {
            // Check how many platforms are available.
            uint num_platforms = 0;
            Error err = OpenCLDriver.clGetPlatformIDs(0, IntPtr.Zero, ref num_platforms);

            if (err != Error.Success)
            {
                throw new Exception(err);
            }

            if (num_platforms < 1)
            {
                return new PlatformId[0];
            }

            // Get the actual platforms once we know their amount.
            PlatformId[] platforms = new PlatformId[num_platforms];
            err = OpenCLDriver.clGetPlatformIDs(num_platforms, platforms, ref num_platforms);

            return platforms;
        }

        /// <summary>
        /// Returns requested information about a platform.
        /// </summary>
        /// <param name="platform">Platform ID to query.</param>
        /// <param name="info">Requested information.</param>
        /// <returns>Value which depends on the type of information requested.</returns>
        public static object GetPlatformInfo(PlatformId platform, CLPlatformInfo info)
        {
            Error err = Error.Success;

            // Define variables to store native information.
            SizeT param_value_size_ret = 0;
            IntPtr ptr = IntPtr.Zero;
            object result = null;

            // Get initial size of buffer to allocate.
            err = OpenCLDriver.clGetPlatformInfo(platform, info, 0, IntPtr.Zero, ref param_value_size_ret);

            if (err != Error.Success)
            {
                throw new Exception(err);
            }

            if (param_value_size_ret < 1)
            {
                return result;
            }

            // Allocate native memory to store value.
            ptr = Marshal.AllocHGlobal(param_value_size_ret);

            // Protect following statements with try-finally in case something 
            // goes wrong.
            try
            {
                // Get actual value.
                err = OpenCLDriver.clGetPlatformInfo(platform, info,
                param_value_size_ret, ptr, ref param_value_size_ret);

                switch (info)
                {
                    case CLPlatformInfo.Profile:
                        result = Marshal.PtrToStringAnsi(ptr, param_value_size_ret);
                        break;
                    case CLPlatformInfo.Version:
                        result = Marshal.PtrToStringAnsi(ptr, param_value_size_ret);
                        break;
                    case CLPlatformInfo.Name:
                        result = Marshal.PtrToStringAnsi(ptr, param_value_size_ret);
                        break;
                    case CLPlatformInfo.Vendor:
                        result = Marshal.PtrToStringAnsi(ptr, param_value_size_ret);
                        break;
                    case CLPlatformInfo.Extensions:
                        result = Marshal.PtrToStringAnsi(ptr, param_value_size_ret);
                        break;
                }
            }
            finally
            {
                // Free native buffer.
                Marshal.FreeHGlobal(ptr);
            }

            return result;
        }
        #endregion

        #region Device Utilities
        /// <summary>
        /// Returns an array of available devices in the platform of all types.
        /// If no device is found, an array with zero elements is returned.
        /// </summary>
        /// <param name="platform">Platform to query devices.</param>
        /// <returns>An array of available devices in the platform of all types.</returns>
        public static DeviceId[] GetDevices(PlatformId platform)
        {
            return GetDevices(platform, DeviceType.All);
        }

        /// <summary>
        /// Returns an array of available devices in the platform with following type.
        /// If no device is found, an array with zero elements is returned.
        /// </summary>
        /// <param name="platform">Platform to query devices.</param>
        /// <param name="devType">Type of device to query.</param>
        /// <returns>An array of available devices in the platform with following type.</returns>
        public static DeviceId[] GetDevices(PlatformId platform, DeviceType devType)
        {
            // Check how many devices are available.
            uint num_devices = 0;
            Error err = OpenCLDriver.clGetDeviceIDs(platform, devType, 0, IntPtr.Zero, ref num_devices);

            if (err != Error.Success)
            {
                throw new Exception(err);
            }

            if (num_devices < 1)
            {
                return new DeviceId[0];
            }

            // Get the actual devices once we know their amount.
            DeviceId[] devices = new DeviceId[num_devices];
            err = OpenCLDriver.clGetDeviceIDs(platform, devType, num_devices, devices, ref num_devices);

            return devices;
        }

        /// <summary>
        /// Returns requested information about a device.
        /// </summary>
        /// <param name="device">Device ID to query.</param>
        /// <param name="info">Requested information.</param>
        /// <returns>Value which depends on the type of information requested.</returns>
        public static object GetDeviceInfo(DeviceId device, DeviceInfo info)
        {
            //OpenCLDriver.clGetDeviceInfo(device, info, 

            Error err = Error.Success;

            // Define variables to store native information.
            SizeT param_value_size_ret = 0;
            IntPtr ptr = IntPtr.Zero;
            object result = null;

            // Get initial size of buffer to allocate.
            err = OpenCLDriver.clGetDeviceInfo(device, info, 0, IntPtr.Zero, ref param_value_size_ret);

            if (err != Error.Success)
            {
                throw new Exception(err);
            }

            if (param_value_size_ret < 1)
            {
                return result;
            }

            // Allocate native memory to store value.
            ptr = Marshal.AllocHGlobal(param_value_size_ret);

            // Protect following statements with try-finally in case something 
            // goes wrong.
            try
            {
                // Get actual value.
                err = OpenCLDriver.clGetDeviceInfo(device, info,
                param_value_size_ret, ptr, ref param_value_size_ret);

                switch (info)
                {
                    case DeviceInfo.Type:
                        result = (DeviceType)Marshal.ReadInt64(ptr);
                        break;
                    case DeviceInfo.VendorId:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.MaxComputeUnits:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.MaxWorkItemDimensions:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.MaxWorkGroupSize:
                        result = Marshal.PtrToStructure(ptr, typeof(SizeT));
                        break;
                    case DeviceInfo.MaxWorkItemSizes:
                        uint dims = (uint)GetDeviceInfo(device, DeviceInfo.MaxWorkItemDimensions);
                        SizeT[] sizes = new SizeT[dims];
                        for (int i = 0; i < dims; i++)
                        {
                            sizes[i] = new SizeT(Marshal.ReadIntPtr(ptr, i * IntPtr.Size).ToInt64());
                        }

                        result = sizes;
                        break;
                    case DeviceInfo.PreferredVectorWidthChar:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.PreferredVectorWidthShort:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.PreferredVectorWidthInt:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.PreferredVectorWidthLong:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.PreferredVectorWidthFloat:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.PreferredVectorWidthDouble:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.MaxClockFrequency:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.AddressBits:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.MaxReadImageArgs:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.MaxWriteImageArgs:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.MaxMemAllocSize:
                        result = (ulong)Marshal.ReadInt64(ptr);
                        break;
                    case DeviceInfo.Image2DMaxWidth:
                        result = Marshal.PtrToStructure(ptr, typeof(SizeT));
                        break;
                    case DeviceInfo.Image2DMaxHeight:
                        result = Marshal.PtrToStructure(ptr, typeof(SizeT));
                        break;
                    case DeviceInfo.Image3DMaxWidth:
                        result = Marshal.PtrToStructure(ptr, typeof(SizeT));
                        break;
                    case DeviceInfo.Image3DMaxHeight:
                        result = Marshal.PtrToStructure(ptr, typeof(SizeT));
                        break;
                    case DeviceInfo.Image3DMaxDepth:
                        result = Marshal.PtrToStructure(ptr, typeof(SizeT));
                        break;
                    case DeviceInfo.ImageSupport:
                        result = (Bool)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.MaxParameterSize:
                        result = Marshal.PtrToStructure(ptr, typeof(SizeT));
                        break;
                    case DeviceInfo.MaxSamplers:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.MemBaseAddrAlign:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.MinDataTypeAlignSize:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.SingleFPConfig:
                        result = (DeviceFpConfig)Marshal.ReadInt64(ptr);
                        break;
                    case DeviceInfo.GlobalMemCacheType:
                        result = (DeviceMemCacheType)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.GlobalMemCacheLineSize:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.GlobalMemCacheSize:
                        result = (ulong)Marshal.ReadInt64(ptr);
                        break;
                    case DeviceInfo.GlobalMemSize:
                        result = (ulong)Marshal.ReadInt64(ptr);
                        break;
                    case DeviceInfo.MaxConstantBufferSize:
                        result = (ulong)Marshal.ReadInt64(ptr);
                        break;
                    case DeviceInfo.MaxConstantArgs:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.LocalMemType:
                        result = (DeviceLocalMemType)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.LocalMemSize:
                        result = (ulong)Marshal.ReadInt64(ptr);
                        break;
                    case DeviceInfo.ErrorCorrectionSupport:
                        result = (Bool)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.ProfilingTimerResolution:
                        result = Marshal.PtrToStructure(ptr, typeof(SizeT));
                        break;
                    case DeviceInfo.EndianLittle:
                        result = (Bool)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.Available:
                        result = (Bool)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.CompilerAvailable:
                        result = (Bool)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.ExecutionCapabilities:
                        result = (DeviceExecCapabilities)Marshal.ReadInt64(ptr);
                        break;
                    case DeviceInfo.QueueProperties:
                        result = (CommandQueueProperties)Marshal.ReadInt64(ptr);
                        break;
                    case DeviceInfo.Name:
                        result = Marshal.PtrToStringAnsi(ptr, param_value_size_ret);
                        break;
                    case DeviceInfo.Vendor:
                        result = Marshal.PtrToStringAnsi(ptr, param_value_size_ret);
                        break;
                    case DeviceInfo.DriverVersion:
                        result = Marshal.PtrToStringAnsi(ptr, param_value_size_ret);
                        break;
                    case DeviceInfo.Profile:
                        result = Marshal.PtrToStringAnsi(ptr, param_value_size_ret);
                        break;
                    case DeviceInfo.Version:
                        result = Marshal.PtrToStringAnsi(ptr, param_value_size_ret);
                        break;
                    case DeviceInfo.Extensions:
                        result = Marshal.PtrToStringAnsi(ptr, param_value_size_ret);
                        break;
                    case DeviceInfo.Platform:
                        result = Marshal.PtrToStructure(ptr, typeof(PlatformId));
                        break;
                    case DeviceInfo.PreferredVectorWidthHalf:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.HostUnifiedMemory:
                        result = (Bool)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.NativeVectorWidthChar:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.NativeVectorWidthShort:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.NativeVectorWidthInt:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.NativeVectorWidthLong:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.NativeVectorWidthFloat:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.NativeVectorWidthDouble:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.NativeVectorWidthHalf:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case DeviceInfo.OpenCLCVersion:
                        result = Marshal.PtrToStringAnsi(ptr, param_value_size_ret);
                        break;
                }
            }
            finally
            {
                // Free native buffer.
                Marshal.FreeHGlobal(ptr);
            }

            return result;
        }
        #endregion

        #region Context Utilities
        /// <summary>
        /// Returns requested information about a context.
        /// </summary>
        /// <param name="ctx">Context to get information for.</param>
        /// <param name="info">Requested information.</param>
        /// <returns>Value which depends on the type of information requested.</returns>
        public static object GetContextInfo(Context ctx, ContextInfo info)
        {
            Error error = Error.Success;

            // Define variables to store native information.
            SizeT param_value_size_ret = 0;
            IntPtr ptr = IntPtr.Zero;
            object result = null;

            // Get initial size of buffer to allocate.
            error = OpenCLDriver.clGetContextInfo(ctx, info, 0, IntPtr.Zero, ref param_value_size_ret);
            ThrowCLException(error);

            if (param_value_size_ret < 1)
            {
                return result;
            }

            // Allocate native memory to store value.
            ptr = Marshal.AllocHGlobal(param_value_size_ret);

            // Protect following statements with try-finally in case something 
            // goes wrong.
            try
            {
                // Get actual value.
                error = OpenCLDriver.clGetContextInfo(ctx, info,
                param_value_size_ret, ptr, ref param_value_size_ret);

                //TODO: Add implementation to missing cases.
                switch (info)
                {
                    case ContextInfo.ReferenceCount:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case ContextInfo.Devices:
                        break;
                    case ContextInfo.Properties:
                        break;
                    case ContextInfo.NumDevices:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                }
            }
            finally
            {
                // Free native buffer.
                Marshal.FreeHGlobal(ptr);
            }

            return result;
        }
        #endregion

        #region Command Queue Utilities
        public static object GetCommandQueueInfo(CommandQueue command_queue, CommandQueueInfo info)
        {
            Error error = Error.Success;

            // Define variables to store native information.
            SizeT param_value_size_ret = 0;
            IntPtr ptr = IntPtr.Zero;
            object result = null;

            // Get initial size of buffer to allocate.
            error = OpenCLDriver.clGetCommandQueueInfo(command_queue, info, 0, IntPtr.Zero, ref param_value_size_ret);
            ThrowCLException(error);

            if (param_value_size_ret < 1)
            {
                return result;
            }

            // Allocate native memory to store value.
            ptr = Marshal.AllocHGlobal(param_value_size_ret);

            // Protect following statements with try-finally in case something 
            // goes wrong.
            try
            {
                // Get actual value.
                error = OpenCLDriver.clGetCommandQueueInfo(command_queue, info,
                param_value_size_ret, ptr, ref param_value_size_ret);

                switch (info)
                {
                    case CommandQueueInfo.Context:
                        result = Marshal.PtrToStructure(ptr, typeof(Context));
                        break;
                    case CommandQueueInfo.Device:
                        result = Marshal.PtrToStructure(ptr, typeof(DeviceId));
                        break;
                    case CommandQueueInfo.ReferenceCount:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case CommandQueueInfo.Properties:
                        result = (CommandQueueProperties)Marshal.ReadInt64(ptr);
                        break;
                }
            }
            finally
            {
                // Free native buffer.
                Marshal.FreeHGlobal(ptr);
            }

            return result;
        }
        #endregion

        #region Memory Utilities
        public static object GetMemObjectInfo(Mem memobj, CLMemInfo info)
        {
            Error error = Error.Success;

            // Define variables to store native information.
            SizeT param_value_size_ret = 0;
            IntPtr ptr = IntPtr.Zero;
            object result = null;

            // Get initial size of buffer to allocate.
            error = OpenCLDriver.clGetMemObjectInfo(memobj, info, 0, IntPtr.Zero, ref param_value_size_ret);
            ThrowCLException(error);

            if (param_value_size_ret < 1)
            {
                return result;
            }

            // Allocate native memory to store value.
            ptr = Marshal.AllocHGlobal(param_value_size_ret);

            // Protect following statements with try-finally in case something 
            // goes wrong.
            try
            {
                // Get actual value.
                error = OpenCLDriver.clGetMemObjectInfo(memobj, info,
                    param_value_size_ret, ptr, ref param_value_size_ret);

                //TODO: Add missing cases.

                switch (info)
                {
                    case CLMemInfo.Type:
                        result = (CLMemObjectType)Marshal.ReadInt32(ptr);
                        break;
                    case CLMemInfo.Flags:
                        result = (CLMemFlags)Marshal.ReadInt64(ptr);
                        break;
                    case CLMemInfo.Size:
                        result = new SizeT(Marshal.ReadIntPtr(ptr).ToInt64());
                        break;
                    case CLMemInfo.HostPtr:
                        result = Marshal.ReadIntPtr(ptr);
                        break;
                    case CLMemInfo.MapCount:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case CLMemInfo.ReferenceCount:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case CLMemInfo.Context:
                        result = Marshal.PtrToStructure(ptr, typeof(Context));
                        break;
                    case CLMemInfo.AssociatedMemObject:
                        result = Marshal.PtrToStructure(ptr, typeof(Mem));
                        break;
                    case CLMemInfo.Offset:
                        result = new SizeT(Marshal.ReadIntPtr(ptr).ToInt64());
                        break;
                }
            }
            finally
            {
                // Free native buffer.
                Marshal.FreeHGlobal(ptr);
            }

            return result;
        }

        public static object GetImageInfo(Mem memobj, CLImageInfo info)
        {
            Error error = Error.Success;

            // Define variables to store native information.
            SizeT param_value_size_ret = 0;
            IntPtr ptr = IntPtr.Zero;
            object result = null;

            // Get initial size of buffer to allocate.
            error = OpenCLDriver.clGetImageInfo(memobj, info, 0, IntPtr.Zero, ref param_value_size_ret);
            ThrowCLException(error);

            if (param_value_size_ret < 1)
            {
                return result;
            }

            // Allocate native memory to store value.
            ptr = Marshal.AllocHGlobal(param_value_size_ret);

            // Protect following statements with try-finally in case something 
            // goes wrong.
            try
            {
                // Get actual value.
                error = OpenCLDriver.clGetImageInfo(memobj, info,
                    param_value_size_ret, ptr, ref param_value_size_ret);

                //TODO: Add missing cases.

                switch (info)
                {
                    case CLImageInfo.Format:
                        result = Marshal.PtrToStructure(ptr, typeof(ImageFormat));
                        break;
                    case CLImageInfo.ElementSize:
                        result = new SizeT(Marshal.ReadIntPtr(ptr).ToInt64());
                        break;
                    case CLImageInfo.RowPitch:
                        result = new SizeT(Marshal.ReadIntPtr(ptr).ToInt64());
                        break;
                    case CLImageInfo.SlicePitch:
                        result = new SizeT(Marshal.ReadIntPtr(ptr).ToInt64());
                        break;
                    case CLImageInfo.Width:
                        result = new SizeT(Marshal.ReadIntPtr(ptr).ToInt64());
                        break;
                    case CLImageInfo.Height:
                        result = new SizeT(Marshal.ReadIntPtr(ptr).ToInt64());
                        break;
                    case CLImageInfo.Depth:
                        result = new SizeT(Marshal.ReadIntPtr(ptr).ToInt64());
                        break;
                }
            }
            finally
            {
                // Free native buffer.
                Marshal.FreeHGlobal(ptr);
            }

            return result;
        }

        public static void SetMemObjectDestructorCallback(Mem memobj, 
            OpenCLDriver.DestructionFunction function, IntPtr userData)
        {
            Error error = OpenCLDriver.clSetMemObjectDestructorCallback(memobj, function, userData);
            ThrowCLException(error);
        }
        #endregion

        #region Program Utilities
        public static void UnloadCompiler()
        {
            ThrowCLException(OpenCLDriver.clUnloadCompiler());
        }

        public static object GetProgramInfo(Program program, CLProgramInfo info)
        {
            Error error = Error.Success;

            // Define variables to store native information.
            SizeT param_value_size_ret = 0;
            IntPtr ptr = IntPtr.Zero;
            object result = null;

            // Get initial size of buffer to allocate.
            error = OpenCLDriver.clGetProgramInfo(program, info, 0, IntPtr.Zero, ref param_value_size_ret);
            ThrowCLException(error);

            if (param_value_size_ret < 1)
            {
                return result;
            }

            // Allocate native memory to store value.
            ptr = Marshal.AllocHGlobal(param_value_size_ret);

            // Protect following statements with try-finally in case something 
            // goes wrong.
            try
            {
                // Get actual value for normal scalars and arrays.
                if (info != CLProgramInfo.Binaries)
                {
                    error = OpenCLDriver.clGetProgramInfo(program, info,
                        param_value_size_ret, ptr, ref param_value_size_ret);
                }

                switch (info)
                {
                    case CLProgramInfo.ReferenceCount:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case CLProgramInfo.Context:
                        result = Marshal.PtrToStructure(ptr, typeof(Context));
                        break;
                    case CLProgramInfo.NumDevices:
                        result = (uint)Marshal.ReadInt32(ptr);
                        break;
                    case CLProgramInfo.Devices:
                        {
                            // Get number of devices.
                            uint numDevices = (uint)GetProgramInfo(program, CLProgramInfo.NumDevices);

                            // Read device IDs.
                            DeviceId[] devices = new DeviceId[numDevices];
                            for (int i = 0; i < numDevices; i++)
                            {
                                devices[i] = new DeviceId { Value = Marshal.ReadIntPtr(ptr, i * IntPtr.Size) };
                            }

                            result = devices;
                        }
                        break;
                    case CLProgramInfo.Source:
                        result = Marshal.PtrToStringAnsi(ptr, param_value_size_ret);
                        break;
                    case CLProgramInfo.BinarySizes:
                        {
                            // Get number of devices.
                            uint numDevices = (uint)GetProgramInfo(program, CLProgramInfo.NumDevices);

                            // Read binary sizes.
                            SizeT[] binarySizes = new SizeT[numDevices];
                            for (int i = 0; i < numDevices; i++)
                            {
                                binarySizes[i] = (long)Marshal.ReadIntPtr(ptr, i * IntPtr.Size);
                            }

                            result = binarySizes;
                        }
                        break;
                    case CLProgramInfo.Binaries:
                        {
                            // Get number of devices.
                            uint numDevices = (uint)GetProgramInfo(program, CLProgramInfo.NumDevices);

                            // Get binary size for each device.
                            SizeT[] binarySizes = (SizeT[])GetProgramInfo(program, CLProgramInfo.BinarySizes);

                            // Allocate native pointers to store binary data for each device.
                            for (int i = 0; i < numDevices; i++)
                            {
                                Marshal.WriteIntPtr(ptr, i * IntPtr.Size, Marshal.AllocHGlobal(binarySizes[i]));
                            }

                            // Get actual value for normal scalars and arrays.
                            error = OpenCLDriver.clGetProgramInfo(program, info,
                                    param_value_size_ret, ptr, ref param_value_size_ret);

                            // Read program binaries.
                            byte[][] binaries = new byte[numDevices][];
                            for (int i = 0; i < numDevices; i++)
                            {
                                binaries[i] = new byte[binarySizes[i]];

                                IntPtr binarySourcePtr = Marshal.ReadIntPtr(ptr, i * IntPtr.Size);
                                if (binarySourcePtr != IntPtr.Zero)
                                {
                                    Marshal.Copy(binarySourcePtr, binaries[i], 0, binarySizes[i]);

                                    // Free native pointer for binary data.
                                    Marshal.FreeHGlobal(binarySourcePtr);
                                }
                            }

                            result = binaries;
                        }
                        break;
                }
            }
            finally
            {
                // Free native buffer.
                Marshal.FreeHGlobal(ptr);
            }

            return result;
        }

        public static object GetProgramBuildInfo(Program program, DeviceId device,
            CLProgramBuildInfo info)
        {
            Error error = Error.Success;

            // Define variables to store native information.
            SizeT param_value_size_ret = 0;
            IntPtr ptr = IntPtr.Zero;
            object result = null;

            // Get initial size of buffer to allocate.
            error = OpenCLDriver.clGetProgramBuildInfo(program, device, info, 0, IntPtr.Zero, ref param_value_size_ret);
            ThrowCLException(error);

            if (param_value_size_ret < 1)
            {
                return result;
            }

            // Allocate native memory to store value.
            ptr = Marshal.AllocHGlobal(param_value_size_ret);

            // Protect following statements with try-finally in case something 
            // goes wrong.
            try
            {
                // Get actual value.
                error = OpenCLDriver.clGetProgramBuildInfo(program, device, info,
                    param_value_size_ret, ptr, ref param_value_size_ret);

                switch (info)
                {
                    case CLProgramBuildInfo.Status:
                        result = (BuildStatus)Marshal.ReadInt32(ptr);
                        break;
                    case CLProgramBuildInfo.Options:
                        result = Marshal.PtrToStringAnsi(ptr, param_value_size_ret);
                        break;
                    case CLProgramBuildInfo.Log:
                        result = Marshal.PtrToStringAnsi(ptr, param_value_size_ret);
                        break;
                }
            }
            finally
            {
                // Free native buffer.
                Marshal.FreeHGlobal(ptr);
            }

            return result;
        }
        #endregion

        #region Event Utilities
        public static object GetEventProfilingInfo(Event e, CLProfilingInfo info)
        {
            Error error = Error.Success;

            // Define variables to store native information.
            SizeT param_value_size_ret = 0;
            IntPtr ptr = IntPtr.Zero;
            object result = null;

            // Get initial size of buffer to allocate.
            error = OpenCLDriver.clGetEventProfilingInfo(e, info, 0, IntPtr.Zero, ref param_value_size_ret);
            ThrowCLException(error);

            if (param_value_size_ret < 1)
            {
                return result;
            }

            // Allocate native memory to store value.
            ptr = Marshal.AllocHGlobal(param_value_size_ret);

            // Protect following statements with try-finally in case something 
            // goes wrong.
            try
            {
                // Get actual value.
                error = OpenCLDriver.clGetEventProfilingInfo(e, info,
                    param_value_size_ret, ptr, ref param_value_size_ret);

                switch (info)
                {
                    case CLProfilingInfo.Queued:
                        result = (ulong)Marshal.ReadInt64(ptr);
                        break;
                    case CLProfilingInfo.Submit:
                        result = (ulong)Marshal.ReadInt64(ptr);
                        break;
                    case CLProfilingInfo.Start:
                        result = (ulong)Marshal.ReadInt64(ptr);
                        break;
                    case CLProfilingInfo.End:
                        result = (ulong)Marshal.ReadInt64(ptr);
                        break;
                }
            }
            finally
            {
                // Free native buffer.
                Marshal.FreeHGlobal(ptr);
            }

            return result;
        }
        #endregion

        #region Helper Functions
        private static void ThrowCLException(Error error)
        {
            if (error == Error.Success)
            {
                return;
            }

            throw new Exception(error);
        }
        #endregion

        #region Internal Variables
        private Event lastOperationEvent;
        #endregion
    }
}
