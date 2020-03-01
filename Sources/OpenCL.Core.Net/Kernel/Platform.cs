﻿using System;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Kernel.Functors;
using OpenCL.Core.Net.Types.Enums;
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
            return ErrorValidator.Validate(functor);
        }

        public PlatformId[] GetPlatformIDs(uint numEntries)
        {
            var arguments = WrapperFactory.Create(numEntries);
            var functor = PlatformNative.GetPlatformIDs(arguments);
            return ErrorValidator.Validate(functor);
        }

        public SizeT GetPlatformInfo(PlatformId platform, PlatformInfo paramName, SizeT paramValueSize, IntPtr paramValue)
        {
            var arguments = WrapperFactory.Create(platform, paramName, paramValueSize, paramValue);
            var functor = PlatformNative.GetPlatformInfo(arguments);
            return ErrorValidator.Validate(functor);
        }

        IPlatformNativeFunctor PlatformNative { get; }
        IWrapperFactory WrapperFactory { get; }
        IErrorValidator ErrorValidator { get; }
    }
}
