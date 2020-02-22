using OpenCL.Core.Net.Interfaces.Api;
using OpenCL.Core.Net.Types;
using OpenCL.Core.Net.Types.Enums;

namespace OpenCL.Core.Net.Api
{
    public class ResultNativeCallFactory: IResultNativeCallFactory
    {
        public ResultNativeCall<TValue> Create<TValue>(TValue value, Error error) =>
            new ResultNativeCall<TValue>(value, error);
    }
}