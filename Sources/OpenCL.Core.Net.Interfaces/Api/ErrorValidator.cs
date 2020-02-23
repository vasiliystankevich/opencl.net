using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Api
{
    public interface IErrorValidator
    {
        void Validate(NativeFunc functor);
        void Validate(ref SizeT size, NativeFunc<SizeT, Error> functor);
        TValue Validate<TValue>(NativeFunc<Error, TValue> functor);
    }
}
