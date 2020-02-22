using OpenCL.Core.Net.Types.Enums;

namespace OpenCL.Core.Net.Types
{
    public class ResultNativeCall<TValue>
    {
        public ResultNativeCall(TValue value, Error error)
        {
            Value = value;
            Error = error;
        }

        public TValue Value { get; }
        public Error Error { get; }
    }
}
