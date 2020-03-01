using System;

namespace OpenCL.Core.Net.Types.Interfaces
{
    public interface IWrapper<TArg1> : IDisposable
    {
        TArg1 Arg1 { get; }
    }

    public interface IWrapper<TArg1, TArg2> : IWrapper<TArg1>
    {
        TArg2 Arg2 { get; }
    }

    public interface IWrapper<TArg1, TArg2, TArg3> : IWrapper<TArg1, TArg2>
    {
        TArg3 Arg3 { get; }
    }

    public interface IWrapper<TArg1, TArg2, TArg3, TArg4> : IWrapper<TArg1, TArg2, TArg3>
    {
        TArg4 Arg4 { get; }
    }

    public interface IWrapper<TArg1, TArg2, TArg3, TArg4, TArg5> : IWrapper<TArg1, TArg2, TArg3, TArg4>
    {
        TArg5 Arg5 { get; }
    }
}