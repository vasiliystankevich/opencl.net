using System;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Types;

namespace OpenCL.Core.Net.Kernel
{
    public class NativeCallStateFactory: INativeCallStateFactory
    {
        public NativeCallError<TError> CreateError<TError>(TError error) => new NativeCallError<TError>(error);

        public NativeCallValue<TValue> CreateValue<TValue>(TValue value) => new NativeCallValue<TValue>(value);

        public NativeCallState<TError, TValue> CreateState<TError, TValue>(TError error, TValue value) =>
            new NativeCallState<TError, TValue>(error, value);
    }
}
