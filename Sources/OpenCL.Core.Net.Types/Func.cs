using OpenCL.Core.Net.Types.Enums;

namespace OpenCL.Core.Net.Types
{
    public delegate Error NativeFunc();
    public delegate TResult NativeFuncRef<TArg, out TResult>(ref TArg arg);
    public delegate TResult NativeFunc<in TArg, out TResult>(TArg arg);
}