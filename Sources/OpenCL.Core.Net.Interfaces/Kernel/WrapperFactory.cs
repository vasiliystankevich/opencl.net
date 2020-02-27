using OpenCL.Core.Net.Types;

namespace OpenCL.Core.Net.Interfaces.Kernel
{
    public interface IWrapperFactory
    {
        Wrapper<TArg1> Create<TArg1>(TArg1 arg1);
        Wrapper<TArg1, TArg2> Create<TArg1, TArg2>(TArg1 arg1, TArg2 arg2);
        Wrapper<TArg1, TArg2, TArg3> Create<TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3);
        Wrapper<TArg1, TArg2, TArg3, TArg4> Create<TArg1, TArg2, TArg3, TArg4>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);
        Wrapper<TArg1, TArg2, TArg3, TArg4, TArg5> Create<TArg1, TArg2, TArg3, TArg4, TArg5>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5);
    }
}