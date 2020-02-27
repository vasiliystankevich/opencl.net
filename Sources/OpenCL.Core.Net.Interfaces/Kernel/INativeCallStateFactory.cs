using OpenCL.Core.Net.Types;

namespace OpenCL.Core.Net.Interfaces.Kernel
{
    public interface INativeCallStateFactory
    {
        NativeCallError<TError> CreateError<TError>(TError error);
        NativeCallValue<TValue> CreateValue<TValue>(TValue value);
        NativeCallState<TError, TValue> CreateState<TError, TValue>(TError error, TValue value);
    }
}