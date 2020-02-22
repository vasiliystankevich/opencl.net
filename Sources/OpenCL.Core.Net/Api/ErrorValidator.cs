using System;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;

namespace OpenCL.Core.Net.Api
{
    public class ErrorValidator : IErrorValidator
    {
        public void Validate(Func<Error> functor)
        {
            var error = functor();
            if (error != Error.Success) throw new Exception(error);
        }

        public TValue Validate<TValue>(Func<ResultNativeCall<TValue>> functor)
        {
            var result = functor();
            if (result.Error != Error.Success) throw new Exception(result.Error);
            return result.Value;
        }
    }
}