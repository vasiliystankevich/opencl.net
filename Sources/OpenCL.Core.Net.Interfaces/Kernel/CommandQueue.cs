using System;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Command;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Kernel
{
    public interface ICommandQueueKernel
    {
        [Obsolete("Deprecated since OpenCL 2.0")]
        CommandQueue CreateCommandQueue(Context context, DeviceId device, CommandQueueProperties properties);

        CommandQueue CreateCommandQueueWithProperties(Context context, DeviceId device, IntPtr[] properties);

        CommandQueue CreateCommandQueueWithPropertiesIntPtr(Context context, DeviceId device, IntPtr[] properties);

        void RetainCommandQueue(CommandQueue commandQueue);

        void ReleaseCommandQueue(CommandQueue commandQueue);

        void GetCommandQueueInfo(CommandQueue commandQueue, CommandQueueInfo paramName, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet);

        [Obsolete("Deprecated since OpenCL 1.1")]
        void SetCommandQueueProperty(CommandQueue commandQueue, CommandQueueProperties properties, Bool enable,
            ref CommandQueueProperties oldProperties);
    }
}