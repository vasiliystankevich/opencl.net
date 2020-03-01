using System;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Command;
using OpenCL.Core.Net.Types.Interfaces;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Api
{
    public interface IErrorValidator
    {
        void Validate(Func<IWrapper<Error>> functor);
        IWrapper<Error, TValue> Validate<TValue>(Func<IWrapper<Error, TValue>> functor);
        IWrapper<Error, TValue1, TValue2> Validate<TValue1, TValue2>(Func<IWrapper<Error, TValue1, TValue2>> functor);
    }
}
