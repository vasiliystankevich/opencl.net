using System;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Kernel.Functors;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Interfaces;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Kernel
{
    public class PlatformKernel : IPlatformKernel
    {
        public PlatformKernel(IPlatformNativeFunctor platformNative, IWrapperFactory wrapperFactory,
            IErrorValidator errorValidator)
        {
            PlatformNative = platformNative;
            WrapperFactory = wrapperFactory;
            ErrorValidator = errorValidator;
        }

        public uint GetPlatformIDs(uint numEntries, IntPtr platforms)
        {
            var arguments = WrapperFactory.Create(numEntries, platforms);
            var functor = PlatformNative.GetPlatformIDs(arguments);
            var result = ErrorValidator.Validate(functor);
            return result.Arg2;
        }

        public IWrapper<uint, PlatformId[]> GetPlatformIDs(uint numEntries)
        {
            var arguments = WrapperFactory.Create(numEntries);
            var functor = PlatformNative.GetPlatformIDs(arguments);
            var result = ErrorValidator.Validate(functor);
            return WrapperFactory.Create(result.Arg2, result.Arg3);
        }

        public SizeT GetPlatformInfo(PlatformId platform, PlatformInfo paramName, SizeT paramValueSize, IntPtr paramValue)
        {
            var arguments = WrapperFactory.Create(platform, paramName, paramValueSize, paramValue);
            var functor = PlatformNative.GetPlatformInfo(arguments);
            var result = ErrorValidator.Validate(functor);
            return result.Arg2;
        }

        IPlatformNativeFunctor PlatformNative { get; }
        IWrapperFactory WrapperFactory { get; }
        IErrorValidator ErrorValidator { get; }
    }
}