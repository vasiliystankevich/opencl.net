using OpenCL.Core.Net.Types.Interfaces;

namespace OpenCL.Core.Net.Interfaces.Kernel
{
    public interface IWrapperFactory
    {
        IWrapper<TArg1> Create<TArg1>(TArg1 arg1);
        IWrapper<TArg1, TArg2> Create<TArg1, TArg2>(TArg1 arg1, TArg2 arg2);
        IWrapper<TArg1, TArg2, TArg3> Create<TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3);
        IWrapper<TArg1, TArg2, TArg3, TArg4> Create<TArg1, TArg2, TArg3, TArg4>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);
        IWrapper<TArg1, TArg2, TArg3, TArg4, TArg5> Create<TArg1, TArg2, TArg3, TArg4, TArg5>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5);
    }
}