using System;
using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Interfaces;

namespace OpenCL.Core.Net.Api
{
    public class ErrorValidator : IErrorValidator
    {
        public void Validate(Func<IWrapper<Error>> functor)
        {
            var result = functor();
            if (result.Arg1 != Error.Success) throw new Exception(result.Arg1);
        }

        public IWrapper<Error, TValue> Validate<TValue>(Func<IWrapper<Error, TValue>> functor)
        {
            var result = functor();
            if (result.Arg1 != Error.Success) throw new Exception(result.Arg1);
            return result;
        }

        public IWrapper<Error, TValue1, TValue2> Validate<TValue1, TValue2>(Func<IWrapper<Error, TValue1, TValue2>> functor)
        {
            var result = functor();
            if (result.Arg1 != Error.Success) throw new Exception(result.Arg1);
            return result;
        }
    }
}