using OpenCL.Core.Net.Types.Enums;

namespace OpenCL.Core.Net.Types
{
    public delegate Error NativeFunc();
    public delegate TResult NativeFunc1Ref<TArg, out TResult>(ref TArg arg);
    public delegate TResult NativeFunc2Ref<TArg1, TArg2, out TResult>(ref TArg1 arg1, ref TArg2 arg2);
    public delegate TResult NativeFunc1Arg<in TArg, out TResult>(TArg arg);
}