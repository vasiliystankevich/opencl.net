using OpenCL.Types.Core.Net.Enums;
using OpenCL.Types.Core.Net.Enums.Mem;
using OpenCL.Types.Core.Net.Primitives;
using System;
using System.Runtime.InteropServices;

namespace OpenCL.Core.Net.Native
{
    public class EnqueuedCommandsApi
    {
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueReadBuffer(CommandQueue commandQueue, Mem buffer, Bool blockingRead,
            SizeT offset, SizeT cb, IntPtr ptr, uint numEventsInWaitList, [In] Event[] eventWaitList, ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueReadBuffer(CommandQueue commandQueue, Mem buffer, Bool blockingRead,
            SizeT offset, SizeT cb, IntPtr ptr, uint numEventsInWaitList, [In] Event[] eventWaitList, IntPtr e);

        /* 1.1 */
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueReadBufferRect(CommandQueue commandQueue, Mem buffer, Bool blockingRead,
            [In] SizeT[] bufferOrigin, [In] SizeT[] hostOrigin, [In] SizeT[] region, SizeT bufferRowPitch,
            SizeT bufferSlicePitch, SizeT hostRowPitch, SizeT hostSlicePitch, IntPtr ptr, uint numEventsInWaitList,
            [In] Event[] eventWaitList, ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueReadBufferRect(CommandQueue commandQueue, Mem buffer, Bool blockingRead,
            [In] SizeT[] bufferOrigin, [In] SizeT[] hostOrigin, [In] SizeT[] region, SizeT bufferRowPitch,
            SizeT bufferSlicePitch, SizeT hostRowPitch, SizeT hostSlicePitch, IntPtr ptr, uint numEventsInWaitList,
            [In] Event[] eventWaitList, IntPtr e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueWriteBuffer(CommandQueue commandQueue, Mem buffer, Bool blockingWrite,
            SizeT offset, SizeT cb, IntPtr ptr, uint numEventsInWaitList, [In] Event[] eventWaitList, ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueWriteBuffer(CommandQueue commandQueue, Mem buffer, Bool blockingWrite,
            SizeT offset, SizeT cb, IntPtr ptr, uint numEventsInWaitList, [In] Event[] eventWaitList, IntPtr e);

        /* 1.1 */
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueWriteBufferRect(CommandQueue commandQueue, Mem buffer, Bool blockingRead,
            [In] SizeT[] bufferOrigin, [In] SizeT[] hostOrigin, [In] SizeT[] region, SizeT bufferRowPitch,
            SizeT bufferSlicePitch, SizeT hostRowPitch, SizeT hostSlicePitch, IntPtr ptr, uint numEventsInWaitList,
            [In] Event[] eventWaitList, ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueWriteBufferRect(CommandQueue commandQueue, Mem buffer, Bool blockingRead,
            [In] SizeT[] bufferOrigin, [In] SizeT[] hostOrigin, [In] SizeT[] region, SizeT bufferRowPitch,
            SizeT bufferSlicePitch, SizeT hostRowPitch, SizeT hostSlicePitch, IntPtr ptr, uint numEventsInWaitList,
            [In] Event[] eventWaitList, IntPtr e);

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueFillBuffer(CommandQueue commandQueue, Mem buffer, IntPtr pattern,
            SizeT patternSize, SizeT offset, SizeT size, uint numEventsInWaitList, [In] Event[] eventWaitList,
            ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueFillBuffer(CommandQueue commandQueue, Mem buffer, IntPtr pattern,
            SizeT patternSize, SizeT offset, SizeT size, uint numEventsInWaitList, [In] Event[] eventWaitList,
            IntPtr e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueCopyBuffer(CommandQueue commandQueue, Mem srcBuffer, Mem dstBuffer,
            SizeT srcOffset, SizeT dstOffset, SizeT cb, uint numEventsInWaitList, [In] Event[] eventWaitList,
            ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueCopyBuffer(CommandQueue commandQueue, Mem srcBuffer, Mem dstBuffer,
            SizeT srcOffset, SizeT dstOffset, SizeT cb, uint numEventsInWaitList, [In] Event[] eventWaitList, IntPtr e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueCopyBufferRect(CommandQueue commandQueue, Mem srcBuffer, Mem dstBuffer,
            [In] SizeT[] srcOrigin, [In] SizeT[] dstOrigin, [In] SizeT[] region, SizeT srcRowPitch, SizeT srcSlicePitch,
            SizeT dstRowPitch, SizeT dstSlicePitch, uint numEventsInWaitList, [In] Event[] eventWaitList, ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueCopyBufferRect(CommandQueue commandQueue, Mem srcBuffer, Mem dstBuffer,
            [In] SizeT[] srcOrigin, [In] SizeT[] dstOrigin, [In] SizeT[] region, SizeT srcRowPitch, SizeT srcSlicePitch,
            SizeT dstRowPitch, SizeT dstSlicePitch, uint numEventsInWaitList, [In] Event[] eventWaitList, IntPtr e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueReadImage(CommandQueue commandQueue, Mem image, Bool blockingRead,
            SizeT[] origin, SizeT[] region, SizeT rowPitch, SizeT slicePitch, IntPtr ptr, uint numEventsInWaitList,
            [In] Event[] eventWaitList, ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueReadImage(CommandQueue commandQueue, Mem image, Bool blockingRead,
            SizeT[] origin, SizeT[] region, SizeT rowPitch, SizeT slicePitch, IntPtr ptr, uint numEventsInWaitList,
            [In] Event[] eventWaitList, IntPtr e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueWriteImage(CommandQueue commandQueue, Mem image, Bool blockingWrite,
            SizeT[] origin, SizeT[] region, SizeT inputRowPitch, SizeT inputSlicePitch, IntPtr ptr,
            uint numEventsInWaitList, [In] Event[] eventWaitList, ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueWriteImage(CommandQueue commandQueue, Mem image, Bool blockingWrite,
            SizeT[] origin, SizeT[] region, SizeT inputRowPitch, SizeT inputSlicePitch, IntPtr ptr,
            uint numEventsInWaitList, [In] Event[] eventWaitList, IntPtr e);

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueFillImage(CommandQueue commandQueue, Mem image, IntPtr fillColor,
            [In] SizeT[] origin, [In] SizeT[] region, uint numEventsInWaitList, [In] Event[] eventWaitList,
            ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueFillImage(CommandQueue commandQueue, Mem image, IntPtr fillColor,
            [In] SizeT[] origin, [In] SizeT[] region, uint numEventsInWaitList, [In] Event[] eventWaitList, IntPtr e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueCopyImage(CommandQueue commandQueue, Mem srcImage, Mem dstImage,
            SizeT[] srcOrigin, SizeT[] dstOrigin, SizeT[] region, uint numEventsInWaitList, [In] Event[] eventWaitList,
            ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueCopyImage(CommandQueue commandQueue, Mem srcImage, Mem dstImage,
            SizeT[] srcOrigin, SizeT[] dstOrigin, SizeT[] region, uint numEventsInWaitList, [In] Event[] eventWaitList,
            IntPtr e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueCopyImageToBuffer(CommandQueue commandQueue, Mem srcImage, Mem dstBuffer,
            SizeT[] srcOrigin, SizeT[] region, SizeT dstOffset, uint numEventsInWaitList, [In] Event[] eventWaitList,
            ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueCopyImageToBuffer(CommandQueue commandQueue, Mem srcImage, Mem dstBuffer,
            SizeT[] srcOrigin, SizeT[] region, SizeT dstOffset, uint numEventsInWaitList, [In] Event[] eventWaitList,
            IntPtr e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueCopyBufferToImage(CommandQueue commandQueue, Mem srcBuffer, Mem dstImage,
            SizeT srcOffset, SizeT[] dstOrigin, SizeT[] region, uint numEventsInWaitList, [In] Event[] eventWaitList,
            ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueCopyBufferToImage(CommandQueue commandQueue, Mem srcBuffer, Mem dstImage,
            SizeT srcOffset, SizeT[] dstOrigin, SizeT[] region, uint numEventsInWaitList, [In] Event[] eventWaitList,
            IntPtr e);

        [DllImport(DllNative.Name)]
        public static extern IntPtr clEnqueueMapBuffer(CommandQueue commandQueue, Mem buffer, Bool blockingMap,
            MapFlags mapFlags, SizeT offset, SizeT cb, uint numEventsInWaitList, [In] Event[] eventWaitList,
            ref Event e, ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern IntPtr clEnqueueMapBuffer(CommandQueue commandQueue, Mem buffer, Bool blockingMap,
            MapFlags mapFlags, SizeT offset, SizeT cb, uint numEventsInWaitList, [In] Event[] eventWaitList, IntPtr e,
            ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern IntPtr clEnqueueMapImage(CommandQueue commandQueue, Mem image, Bool blockingMap,
            MapFlags mapFlags, SizeT[] origin, SizeT[] region, ref SizeT imageRowPitch, ref SizeT imageSlicePitch,
            uint numEventsInWaitList, [In] Event[] eventWaitList, ref Event e, ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern IntPtr clEnqueueMapImage(CommandQueue commandQueue, Mem image, Bool blockingMap,
            MapFlags mapFlags, SizeT[] origin, SizeT[] region, ref SizeT imageRowPitch, ref SizeT imageSlicePitch,
            uint numEventsInWaitList, [In] Event[] eventWaitList, IntPtr e, ref Error errcodeRet);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueUnmapMemObject(CommandQueue commandQueue, Mem memobj, IntPtr mappedPtr,
            uint numEventsInWaitList, [In] Event[] eventWaitList, ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueUnmapMemObject(CommandQueue commandQueue, Mem memobj, IntPtr mappedPtr,
            uint numEventsInWaitList, [In] Event[] eventWaitList, IntPtr e);

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueMigrateMemObjects(CommandQueue commandQueue, uint numMemObjects,
            [In] Mem[] memObjects, MemMigrationFlags flags, uint numEventsInWaitList, [In] Event[] eventWaitList,
            ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueMigrateMemObjects(CommandQueue commandQueue, uint numMemObjects,
            [In] Mem[] memObjects, MemMigrationFlags flags, uint numEventsInWaitList, [In] Event[] eventWaitList,
            IntPtr e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueNDRangeKernel(CommandQueue commandQueue,
            Types.Core.Net.Primitives.Kernel kernel, uint workDim, [In] SizeT[] globalWorkOffset,
            [In] SizeT[] globalWorkSize, [In] SizeT[] localWorkSize, uint numEventsInWaitList,
            [In] Event[] eventWaitList, ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueNDRangeKernel(CommandQueue commandQueue,
            Types.Core.Net.Primitives.Kernel kernel, uint workDim, [In] SizeT[] globalWorkOffset,
            [In] SizeT[] globalWorkSize, [In] SizeT[] localWorkSize, uint numEventsInWaitList,
            [In] Event[] eventWaitList, IntPtr e);

        [Obsolete("Deprecated since OpenCL 2.0")]
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueTask(CommandQueue commandQueue, Types.Core.Net.Primitives.Kernel kernel,
            uint numEventsInWaitList, [In] Event[] eventWaitList, ref Event e);

        [Obsolete("Deprecated since OpenCL 2.0")]
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueTask(CommandQueue commandQueue, Types.Core.Net.Primitives.Kernel kernel,
            uint numEventsInWaitList, [In] Event[] eventWaitList, IntPtr e);

        public delegate void UserFunction(IntPtr[] args);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueNativeKernel(CommandQueue commandQueue, UserFunction userFunc,
            [In] IntPtr[] args, SizeT cbArgs, uint numMemObjects, [In] Mem[] memList, [In] IntPtr[] argsMemLoc,
            uint numEventsInWaitList, [In] Event[] eventWaitList, ref Event e);

        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueNativeKernel(CommandQueue commandQueue, UserFunction userFunc,
            [In] IntPtr[] args, SizeT cbArgs, uint numMemObjects, [In] Mem[] memList, [In] IntPtr[] argsMemLoc,
            uint numEventsInWaitList, [In] Event[] eventWaitList, IntPtr e);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueMarker(CommandQueue commandQueue, ref Event e);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueWaitForEvents(CommandQueue commandQueue, uint numEvents,
            [In] Event[] eventList);

        [Obsolete("Deprecated since OpenCL 1.2")]
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueBarrier(CommandQueue commandQueue);

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueMarkerWithWaitList(CommandQueue commandQueue, uint numEventsInWaitList,
            [In] Event[] eventWaitList, ref Event e);

        /* 1.2 */
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueBarrierWithWaitList(CommandQueue commandQueue, uint numEventsInWaitList,
            [In] Event[] eventWaitList, ref Event e);

        /* 2.0 */
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueSVMFree(CommandQueue commandQueue, uint numSvmPointers,
            [In] IntPtr[] svmPointers, Action<CommandQueue, uint, IntPtr[], IntPtr> pfnFreeFunc, IntPtr userData,
            uint numEventsInWaitList, [In] Event[] eventWaitList, ref Event e);

        /* 2.0 */
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueSVMMemcpy(CommandQueue commandQueue, Bool blockingCopy, IntPtr dstPtr,
            IntPtr srcPtr, SizeT size, uint numEventsInWaitList, [In] Event[] eventWaitList, ref Event e);

        /* 2.0 */
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueSVMMemFill(CommandQueue commandQueue, IntPtr svmPtr, IntPtr pattern,
            SizeT patternSize, SizeT size, uint numEventsInWaitList, [In] Event[] eventWaitList, ref Event e);

        /* 2.0 */
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueSVMMap(CommandQueue commandQueue, Bool blockingMap, MapFlags flags,
            IntPtr svmPtr, SizeT size, uint numEventsInWaitList, [In] Event[] eventWaitList, ref Event e);

        /* 2.0 */
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueSVMUnmap(CommandQueue commandQueue, IntPtr svmPtr, uint numEventsInWaitList,
            [In] Event[] eventWaitList, ref Event e);

        /* 2.1 */
        [DllImport(DllNative.Name)]
        public static extern Error clEnqueueSVMMigrateMem(CommandQueue commandQueue, uint numSvmPointers,
            [In] IntPtr[] svmPointers, [In] SizeT[] sizes, MemMigrationFlags flags, uint numEventsInWaitList,
            [In] Event[] eventWaitList, ref Event e);
    }
}