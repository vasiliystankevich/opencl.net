using System;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Command;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Api
{
    public class ErrorValidator : IErrorValidator
    {
        public void Validate(NativeFunc functor)
        {
            var error = functor();
            if (error != Error.Success) throw new Exception(error);
        }

        public void Validate(ref SizeT size, NativeFuncRef<SizeT, Error> functor)
        {
            var error = functor(ref size);
            if (error != Error.Success) throw new Exception(error);
        }

        public void Validate(ref CommandQueueProperties properties, NativeFuncRef<CommandQueueProperties, Error> functor)
        {
            var error = functor(ref properties);
            if (error != Error.Success) throw new Exception(error);
        }

        public TValue Validate<TValue>(NativeFuncRef<Error, TValue> functor)
        {
            var error = Error.Success;
            var result = functor(ref error);
            if (error != Error.Success) throw new Exception(error);
            return result;
        }

        public CommandQueue Validate(NativeFunc<IntPtr, CommandQueue> functor)
        {
            var error = IntPtr.Zero;
            var result = functor(error);
            if (error != IntPtr.Zero) throw new Exception((Error)error.ToInt32());
            return result;
        }
    }
}