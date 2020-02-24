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
        void Validate(ref SizeT size, NativeFuncRef<SizeT, Error> functor);
        void Validate(ref CommandQueueProperties properties, NativeFuncRef<CommandQueueProperties, Error> functor);
        TValue Validate<TValue>(NativeFuncRef<Error, TValue> functor);
        CommandQueue Validate(NativeFunc<IntPtr, CommandQueue> functor);
    }
}
