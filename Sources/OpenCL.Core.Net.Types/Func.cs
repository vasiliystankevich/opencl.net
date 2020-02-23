using OpenCL.Core.Net.Types.Enums;

namespace OpenCL.Core.Net.Types
{
    public delegate Error NativeFunc();
    public delegate TResult NativeFunc<TArg, out TResult>(ref TArg arg);
}