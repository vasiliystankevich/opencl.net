using System;
using System.Runtime.InteropServices;
using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Enums.Program;
using OpenCL.Types.Core.Net.Primitives;

namespace OpenCL.Core.Net.Native
{
    public class ProgramObjectApi
    {
        [DllImport(DllNative.Name)]
        public static extern Program clCreateProgramWithSource(Context context, uint count, IntPtr strings,
            [In] SizeT[] lengths, ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Program clCreateProgramWithSource(Context context, uint count, [In] string[] strings,
            [In] SizeT[] lengths, ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Program clCreateProgramWithSource(Context context, uint count, [In] IntPtr[] strings,
            [In] SizeT[] lengths, ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Program clCreateProgramWithBinary(Context context, uint numDevices,
            [In] DeviceId[] deviceList, [In] SizeT[] lengths, [In] IntPtr[] binaries, [In, Out] int[] binaryStatus,
            ref Error errcodeRet);

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern Program clCreateProgramWithBuiltInKernels(Context context, uint numDevices,
            [In] DeviceId[] deviceList, string kernelNames, ref Error errcodeRet);

        /* 2.1 */
        [DllImport(DllNative.Name)]
        public static extern Program clCreateProgramWithIL(Context context, IntPtr il, SizeT length,
            ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Error clRetainProgram(Program program);

        [DllImport(DllNative.Name)]
        public static extern Error clReleaseProgram(Program program);

        [DllImport(DllNative.Name)]
        public static extern Error clBuildProgram(Program program, uint numDevices, [In] DeviceId[] deviceList,
            string options, Action<Program, IntPtr> func, IntPtr userData);

        [DllImport(DllNative.Name)]
        public static extern Error clBuildProgram(Program program, uint numDevices, [In] DeviceId[] deviceList,
            IntPtr options, Action<Program, IntPtr> func, IntPtr userData);

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern Error clCompileProgram(Program program, uint numDevices, [In] DeviceId[] deviceList,
            string options, uint numInputHeaders, [In] Program[] inputHeaders, [In] IntPtr[] headerIncludeNames,
            Action<Program, IntPtr> pfnNotify, IntPtr userData);

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern Program clLinkProgram(Context context, uint numDevices, [In] DeviceId[] deviceList,
            string options, uint numInputPrograms, [In] Program[] inputPrograms, Action<Program, IntPtr> pfnNotify,
            IntPtr userData, ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Program clLinkProgram(Context context, uint numDevices, [In] DeviceId[] deviceList,
            string options, uint numInputPrograms, [In] Program[] inputPrograms, Action<Program, IntPtr> pfnNotify,
            IntPtr userData, IntPtr errcodeRet);

        /* 2.2 */
        [DllImport(DllNative.Name)]
        public static extern Error clSetProgramReleaseCallback(Program program, Action<Program, IntPtr> pfnNotify,
            IntPtr userData);

        /* 2.2 */
        [DllImport(DllNative.Name)]
        public static extern Error clSetProgramSpecializationConstant(Program program, uint specId, SizeT specSize,
            IntPtr specValue);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(DllNative.Name)]
        public static extern Error clUnloadCompiler();

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern Error clUnloadPlatformCompiler(PlatformId platform);

        [DllImport(DllNative.Name)]
        public static extern Error clGetProgramInfo(Program program, ProgramInfo paramName, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet);

        [DllImport(DllNative.Name)]
        public static extern Error clGetProgramBuildInfo(Program program, DeviceId device, ProgramBuildInfo paramName,
            SizeT paramValueSize, IntPtr paramValue, ref SizeT paramValueSizeRet);
    }
}