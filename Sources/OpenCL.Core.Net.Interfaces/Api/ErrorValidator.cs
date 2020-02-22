using System;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;

namespace OpenCL.Core.Net.Interfaces.Api
{
    public interface IErrorValidator
    {
        void Validate(Func<Error> functor);
        TValue Validate<TValue>(Func<ResultNativeCall<TValue>> functor);
    }
}
