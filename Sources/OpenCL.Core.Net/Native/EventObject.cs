using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Primitives;
using System;
using System.Runtime.InteropServices;

namespace OpenCL.Core.Net.Native
{
    public class EventObjectApi
    {
        [DllImport(DllNative.Name)]
        public static extern Error clWaitForEvents(uint numEvents, [In] Event[] eventList);

        [DllImport(DllNative.Name)]
        public static extern Error clGetEventInfo(Event e, EventInfo paramName, SizeT paramValueSize, IntPtr paramValue,
            ref SizeT paramValueSizeRet);

        [DllImport(DllNative.Name)]
        public static extern Event clCreateUserEvent(Context context, IntPtr errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Event clCreateUserEvent(Context context, ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Error clRetainEvent(Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clReleaseEvent(Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clSetUserEventStatus(Event e, int executionStatus);

        [DllImport(DllNative.Name)]
        public static extern Error clSetUserEventStatus(Event e, ExecutionStatus executionStatus);


        [DllImport(DllNative.Name)]
        public static extern Error clSetEventCallback(Event e, ExecutionStatus commandExecCallbackType,
            Action<Event, int, IntPtr> pfnNotify, IntPtr userData);
    }
}