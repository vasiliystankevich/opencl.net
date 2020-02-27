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
        public void Validate(Func<NativeCallError<Error>> functor)
        {
            var result = functor();
            if (result.Error != Error.Success) throw new Exception(result.Error);
        }

        public void Validate(ref SizeT size, NativeFunc1Ref<SizeT, Error> functor)
        {
            var error = functor(ref size);
            if (error != Error.Success) throw new Exception(error);
        }

        public void Validate(ref CommandQueueProperties properties, NativeFunc1Ref<CommandQueueProperties, Error> functor)
        {
            var error = functor(ref properties);
            if (error != Error.Success) throw new Exception(error);
        }

        public TValue Validate<TValue>(NativeFunc1Ref<Error, TValue> functor)
        {
            var error = Error.Success;
            var result = functor(ref error);
            if (error != Error.Success) throw new Exception(error);
            return result;
        }

        public TValue Validate<TArg1, TValue>(ref TArg1 arg1, NativeFunc2Ref<TArg1, Error, TValue> functor)
        {
            var error = Error.Success;
            var result = functor(ref arg1, ref error);
            if (error != Error.Success) throw new Exception(error);
            return result;
        }

        public CommandQueue Validate(NativeFunc1Arg<IntPtr, CommandQueue> functor)
        {
            var error = IntPtr.Zero;
            var result = functor(error);
            if (error != IntPtr.Zero) throw new Exception((Error)error.ToInt32());
            return result;
        }
    }
}