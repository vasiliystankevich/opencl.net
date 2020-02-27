using System;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Types;

namespace OpenCL.Core.Net.Kernel
{
    public class WrapperFactory : IWrapperFactory
    {
        public Wrapper<TArg1> Create<TArg1>(TArg1 arg1) => new Wrapper<TArg1>(arg1);

        public Wrapper<TArg1, TArg2> Create<TArg1, TArg2>(TArg1 arg1, TArg2 arg2) =>
            new Wrapper<TArg1, TArg2>(arg1, arg2);

        public Wrapper<TArg1, TArg2, TArg3> Create<TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3) =>
            new Wrapper<TArg1, TArg2, TArg3>(arg1, arg2, arg3);

        public Wrapper<TArg1, TArg2, TArg3, TArg4> Create<TArg1, TArg2, TArg3, TArg4>(TArg1 arg1, TArg2 arg2,
            TArg3 arg3, TArg4 arg4) => new Wrapper<TArg1, TArg2, TArg3, TArg4>(arg1, arg2, arg3, arg4);

        public Wrapper<TArg1, TArg2, TArg3, TArg4, TArg5> Create<TArg1, TArg2, TArg3, TArg4, TArg5>(TArg1 arg1,
            TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5) =>
            new Wrapper<TArg1, TArg2, TArg3, TArg4, TArg5>(arg1, arg2, arg3, arg4, arg5);
    }
}