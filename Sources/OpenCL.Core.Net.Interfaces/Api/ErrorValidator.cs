using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Api
{
    public interface IErrorValidator
    {
        void Validate(NativeFunc functor);
        void Validate(ref SizeT size, NativeFuncRefSizeT functor);
        TValue Validate<TValue>(NativeFunc<TValue> functor);
    }
}
