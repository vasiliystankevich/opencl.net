using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Command;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Kernel
{
    public interface ICommandQueueKernel
    {
        CommandQueue CreateCommandQueue(Context context, DeviceId device, CommandQueueProperties properties);
        CommandQueue CreateCommandQueueWithProperties(Context context, DeviceId device, IntPtr[] properties);

        CommandQueue CreateCommandQueueWithProperties(Context context, DeviceId device, IntPtr[] properties, IntPtr errcodeRet);

        Error RetainCommandQueue(CommandQueue commandQueue);

        Error ReleaseCommandQueue(CommandQueue commandQueue);

        Error GetCommandQueueInfo(CommandQueue commandQueue, CommandQueueInfo paramName, SizeT paramValueSize,
            IntPtr paramValue, ref SizeT paramValueSizeRet);

        [Obsolete("Deprecated since OpenCL 1.1")]
        Error SetCommandQueueProperty(CommandQueue commandQueue, CommandQueueProperties properties, Bool enable,
            ref CommandQueueProperties oldProperties);
    }
}