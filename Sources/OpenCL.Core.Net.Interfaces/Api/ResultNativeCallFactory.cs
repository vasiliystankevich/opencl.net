using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;

namespace OpenCL.Core.Net.Interfaces.Api
{
    public interface IResultNativeCallFactory
    {
        ResultNativeCall<TValue> Create<TValue>(TValue value, Error error);
    }
}
