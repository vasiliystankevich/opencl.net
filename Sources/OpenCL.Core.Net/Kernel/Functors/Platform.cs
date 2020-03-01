using System;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Kernel.Executors;
using OpenCL.Core.Net.Interfaces.Kernel.Functors;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Interfaces;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Kernel.Functors
{
    public class PlatformNativeFunctor: IPlatformNativeFunctor
    {
        public PlatformNativeFunctor(IPlatformNativeExecutor platformNative, IWrapperFactory wrapperFactory)
        {
            PlatformNative = platformNative;
            WrapperFactory = wrapperFactory;
        }

        public Func<IWrapper<Error, uint>> GetPlatformIDs(IWrapper<uint, IntPtr> arguments) => () =>
        {
            uint numPlatforms = 0;
            var error = PlatformNative.GetPlatformIDs(arguments.Arg1, arguments.Arg2, ref numPlatforms);
            return WrapperFactory.Create(error, numPlatforms);
        };

        public Func<IWrapper<Error, uint, PlatformId[]>> GetPlatformIDs(IWrapper<uint> numEntries) => () =>
        {
            uint numPlatforms = 0;
            var platforms = new PlatformId[numEntries.Arg1];
            var error = PlatformNative.GetPlatformIDs(numEntries.Arg1, platforms, ref numPlatforms);
            return WrapperFactory.Create(error, numPlatforms, platforms);
        };

        public Func<IWrapper<Error, SizeT>> GetPlatformInfo(IWrapper<PlatformId, PlatformInfo, SizeT, IntPtr> arguments) => () =>
        {
            var paramValueSizeRet = new SizeT();
            var error = PlatformNative.GetPlatformInfo(arguments.Arg1, arguments.Arg2, arguments.Arg3,
                arguments.Arg4, ref paramValueSizeRet);
            return WrapperFactory.Create(error, paramValueSizeRet);
        };

        IPlatformNativeExecutor PlatformNative { get; }
        IWrapperFactory WrapperFactory { get; }
    }
}