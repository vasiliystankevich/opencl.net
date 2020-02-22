using System;
using System.Runtime.InteropServices;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Context;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Api
{
    public class ContextApi: IContextApi
    {
        private ContextApi(IContextKernel contextKernel, IErrorValidator errorValidator)
        {
            ContextKernel = contextKernel;
            ErrorValidator = errorValidator;
        }

        public ContextApi(IContextKernel contextKernel, IErrorValidator errorValidator, PlatformId platform,
            DeviceId[] devices) : this(contextKernel, errorValidator)
        {
            var error = Error.Success;
            var properties = new[] {new IntPtr((int) ContextProperties.Platform), platform.Value, IntPtr.Zero};

            var context = contextKernel.CreateContext(properties, (uint) devices.Length, devices, null, IntPtr.Zero,
                ref error);
            ErrorValidator.Validate(error);
            Context = context;
        }

        public ContextApi(IContextKernel contextKernel, IErrorValidator errorValidator, Context context) : this(
            contextKernel, errorValidator)
        {
            var error = ContextKernel.RetainContext(context);
            ErrorValidator.Validate(error);
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

            var error = ContextKernel.GetContextInfo(context, info, 0, IntPtr.Zero, ref paramValueSizeRet);
            ErrorValidator.Validate(error);

            if (paramValueSizeRet < 1) return null;

            var ptr = Marshal.AllocHGlobal(paramValueSizeRet);

            try
            {
                error = ContextKernel.GetContextInfo(context, info, paramValueSizeRet, ptr, ref paramValueSizeRet);
                ErrorValidator.Validate(error);

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
            var error = ContextKernel.ReleaseContext(Context);
            ErrorValidator.Validate(error);
        }

        Context Context { get; }
        IContextKernel ContextKernel { get; }
        IErrorValidator ErrorValidator { get; }
    }
}
