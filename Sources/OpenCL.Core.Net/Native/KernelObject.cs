using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Enums.Kernel;
using OpenCL.Types.Core.Net.Enums.Kernel.Arg;
using OpenCL.Types.Core.Net.Primitives;
using System;
using System.Runtime.InteropServices;

namespace OpenCL.Core.Net.Native
{
    public class KernelObjectApi
    {
        [DllImport(DllNative.Name)]
        public static extern Types.Core.Net.Primitives.Kernel clCreateKernel(Program program, string kernelName,
            ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Error clCreateKernelsInProgram(Program program, uint numKernels,
            [Out] Types.Core.Net.Primitives.Kernel[] kernels, ref uint numKernelsRet);

        /* 2.1 */
        [DllImport(DllNative.Name)]
        public static extern Types.Core.Net.Primitives.Kernel clCloneKernel(
            Types.Core.Net.Primitives.Kernel sourceKernel, ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Error clRetainKernel(Types.Core.Net.Primitives.Kernel kernel);

        [DllImport(DllNative.Name)]
        public static extern Error clReleaseKernel(Types.Core.Net.Primitives.Kernel kernel);

        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint argIndex, SizeT argSize,
            IntPtr argValue);

        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint argIndex, SizeT argSize,
            ref Mem argValue);

        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint argIndex, SizeT argSize,
            ref byte argValue);

        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint argIndex, SizeT argSize,
            [In] byte[] argValue);

        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint argIndex, SizeT argSize,
            ref short argValue);

        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint argIndex, SizeT argSize,
            [In] short[] argValue);

        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint argIndex, SizeT argSize,
            ref int argValue);

        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint argIndex, SizeT argSize,
            [In] int[] argValue);

        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint argIndex, SizeT argSize,
            ref long argValue);

        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint argIndex, SizeT argSize,
            [In] long[] argValue);

        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint argIndex, SizeT argSize,
            ref float argValue);

        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint argIndex, SizeT argSize,
            [In] float[] argValue);

        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint argIndex, SizeT argSize,
            ref double argValue);

        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelArg(Types.Core.Net.Primitives.Kernel kernel, uint argIndex, SizeT argSize,
            [In] double[] argValue);

        /* 2.0 */
        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelArgSVMPointer(Types.Core.Net.Primitives.Kernel kernel, uint argIndex,
            IntPtr argValue);

        /* 2.0 */
        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelExecInfo(Types.Core.Net.Primitives.Kernel kernel,
            KernelExecInfo paramName, SizeT paramValueSize, IntPtr paramValue);

        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelExecInfo(Types.Core.Net.Primitives.Kernel kernel,
            KernelExecInfo paramName, SizeT paramValueSize, [In] IntPtr[] paramValue);

        [DllImport(DllNative.Name)]
        public static extern Error clSetKernelExecInfo(Types.Core.Net.Primitives.Kernel kernel,
            KernelExecInfo paramName, SizeT paramValueSize, ref Bool paramValue);

        [DllImport(DllNative.Name)]
        public static extern Error clGetKernelInfo(Types.Core.Net.Primitives.Kernel kernel, KernelInfo paramName,
            SizeT paramValueSize, IntPtr paramValue, ref SizeT paramValueSizeRet);

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern Error clGetKernelArgInfo(Types.Core.Net.Primitives.Kernel kernel, uint argIndx,
            KernelArgInfo paramName, SizeT paramValueSize, IntPtr paramValue, ref SizeT paramValueSizeRet);

        [DllImport(DllNative.Name)]
        public static extern Error clGetKernelWorkGroupInfo(Types.Core.Net.Primitives.Kernel kernel, DeviceId device,
            KernelWorkGroupInfo paramName, SizeT paramValueSize, IntPtr paramValue, ref SizeT paramValueSizeRet);

        /* 2.1 */
        [DllImport(DllNative.Name)]
        public static extern Error clGetKernelSubGroupInfo(Types.Core.Net.Primitives.Kernel kernel, DeviceId device,
            KernelSubGroupInfo paramName, SizeT inputValueSize, IntPtr inputValue, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet);
    }
}