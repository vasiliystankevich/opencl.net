using System;
using System.Runtime.InteropServices;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Native
{
    public class SamplerApi
    {
        [Obsolete("Deprecated since OpenCL 2.0")]
        [DllImport(DllNative.Name)]
        public static extern Sampler clCreateSampler(Context context, Bool normalizedCoords,
            AddressingMode addressingMode, FilterMode filterMode, ref Error errcodeRet);

        /* 2.0 */
        [DllImport(DllNative.Name)]
        public static extern Sampler clCreateSamplerWithProperties(Context context, [In] IntPtr[] samplerProperties,
            ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Sampler clCreateSamplerWithProperties(Context context, [In] IntPtr[] samplerProperties,
            IntPtr errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Error clRetainSampler(Sampler sampler);

        [DllImport(DllNative.Name)]
        public static extern Error clReleaseSampler(Sampler sampler);

        [DllImport(DllNative.Name)]
        public static extern Error clGetSamplerInfo(Sampler sampler, SamplerInfo paramName, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet);
    }
}