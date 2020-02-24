using System;
using OpenCL.Core.Net.Native;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums.Mem;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Api
{
    public class MemoryApi
    {
        //public Mem CreateBuffer(Context context, SizeT sizeInBytes)
        //{
        //    return CreateBuffer(context, MemFlags.ReadWrite, sizeInBytes);
        //}

        //public Mem CreateBuffer(Context context, MemFlags flags, SizeT sizeInBytes)
        //{
        //    Mem buffer = MemoryObjectApi.clCreateBuffer(context, flags, sizeInBytes, IntPtr.Zero, ref clError);
        //    ThrowCLException(clError);

        //    return buffer;
        //}

        //public Mem CreateImage2D(MemFlags flags, ImageFormat format,
        //    SizeT width, SizeT height, SizeT rowPitchInBytes)
        //{
        //    Mem image = MemoryObjectApi.clCreateImage2D(ctx, flags, ref format,
        //        width, height, rowPitchInBytes, IntPtr.Zero, ref clError);
        //    ThrowCLException(clError);

        //    return image;
        //}

        //public Mem CreateImage3D(MemFlags flags, ImageFormat format,
        //    SizeT width, SizeT height, SizeT depth,
        //    SizeT rowPitchInBytes, SizeT slicePitchInBytes)
        //{
        //    Mem image = MemoryObjectApi.clCreateImage3D(ctx, flags, ref format,
        //        width, height, depth, rowPitchInBytes, slicePitchInBytes,
        //        IntPtr.Zero, ref clError);
        //    ThrowCLException(clError);

        //    return image;
        //}

        //public void RetainMemObject(Mem obj)
        //{
        //    clError = MemoryObjectApi.clRetainMemObject(obj);
        //    ThrowCLException(clError);
        //}

        //public void ReleaseMemObject(Mem obj)
        //{
        //    clError = MemoryObjectApi.clReleaseMemObject(obj);
        //    ThrowCLException(clError);
        //}

        //public ImageFormat[] GetSupportedImageFormats(MemFlags flags, MemObjectType imageType)
        //{
        //    uint numImageFormats = 0;
        //    clError = MemoryObjectApi.clGetSupportedImageFormats(ctx, flags,
        //        imageType, 0, IntPtr.Zero, ref numImageFormats);
        //    ThrowCLException(clError);

        //    if (numImageFormats < 1)
        //    {
        //        return new ImageFormat[0];
        //    }

        //    ImageFormat[] formats = new ImageFormat[numImageFormats];
        //    clError = MemoryObjectApi.clGetSupportedImageFormats(ctx, flags,
        //        imageType, numImageFormats, formats, ref numImageFormats);
        //    ThrowCLException(clError);

        //    return formats;
        //}
    }
}