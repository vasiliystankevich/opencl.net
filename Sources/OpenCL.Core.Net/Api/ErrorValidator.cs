using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;
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

        public void Validate(ref SizeT size, NativeFunc<SizeT, Error> functor)
        {
            var error = functor(ref size);
            if (error != Error.Success) throw new Exception(error);
        }

        public TValue Validate<TValue>(NativeFunc<Error, TValue> functor)
        {
            var error = Error.Success;
            var result = functor(ref error);
            if (error != Error.Success) throw new Exception(error);
            return result;
        }
    }
}