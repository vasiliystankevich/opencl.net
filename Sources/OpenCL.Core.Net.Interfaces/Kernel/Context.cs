using System;
using OpenCL.Core.Net.Types.Enums.Context;
using OpenCL.Core.Net.Types.Enums.Device;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Kernel
{
    public interface IContextKernel
    {
        Context CreateContext(IntPtr[] properties, uint numDevices, DeviceId[] devices,
            Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData);

        Context CreateContextFromType(IntPtr[] properties, DeviceType deviceType,
            Action<IntPtr, IntPtr, SizeT, IntPtr> pfnNotify, IntPtr userData);

        void RetainContext(Context context);

        void ReleaseContext(Context context);

        SizeT GetContextInfo(Context context, ContextInfo paramName, SizeT paramValueSize, IntPtr paramValue);
    }
}