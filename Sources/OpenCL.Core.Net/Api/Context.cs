using System;
using System.Runtime.InteropServices;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Types.Enums.Context;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Api
{
    public class ContextApi: IContextApi
    {
        private ContextApi(IContextKernel contextKernel)
        {
            ContextKernel = contextKernel;
       }

        public ContextApi(IContextKernel contextKernel, PlatformId platform, DeviceId[] devices) : this(contextKernel)
        {
            var properties = new[] {new IntPtr((int) ContextProperties.Platform), platform.Value, IntPtr.Zero};
            Context = contextKernel.CreateContext(properties, (uint) devices.Length, devices, null, IntPtr.Zero);
        }

        public ContextApi(IContextKernel contextKernel, Context context) : this(contextKernel)
        {
            ContextKernel.RetainContext(context);
            Context = context;
        }

        public Context GetContext() => Context;

        public object GetContextInfo(ContextInfo info)
        {
            return GetContextInfo(Context, info);
        }

        public object GetContextInfo(Context context, ContextInfo info)
        {
            SizeT paramValueSizeRet = 0;

            ContextKernel.GetContextInfo(context, info, 0, IntPtr.Zero, ref paramValueSizeRet);

            if (paramValueSizeRet < 1) return null;

            var ptr = Marshal.AllocHGlobal(paramValueSizeRet);

            try
            {
                ContextKernel.GetContextInfo(context, info, paramValueSizeRet, ptr, ref paramValueSizeRet);

                switch (info)
                {
                    case ContextInfo.ReferenceCount: return (uint) Marshal.ReadInt32(ptr);
                    case ContextInfo.NumDevices: return (uint) Marshal.ReadInt32(ptr);
                }
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return null;
        }

        public void Dispose()
        {
            ContextKernel.ReleaseContext(Context);
        }

        Context Context { get; }
        IContextKernel ContextKernel { get; }
    }
}