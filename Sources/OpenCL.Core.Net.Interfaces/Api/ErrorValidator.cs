using System;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Command;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Api
{
    public interface IErrorValidator
    {
        void Validate(NativeFunc functor);
        void Validate(ref SizeT size, NativeFunc1Ref<SizeT, Error> functor);
        void Validate(ref CommandQueueProperties properties, NativeFunc1Ref<CommandQueueProperties, Error> functor);
        TValue Validate<TValue>(NativeFunc1Ref<Error, TValue> functor);
        TValue Validate<TArg1, TValue>(ref TArg1 arg1, NativeFunc2Ref<TArg1, Error, TValue> functor);
        CommandQueue Validate(NativeFunc1Arg<IntPtr, CommandQueue> functor);
    }
}
