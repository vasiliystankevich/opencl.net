namespace OpenCL.Core.Net.Types
{
    public class NativeCallError<TError>
    {
        public NativeCallError(TError error)
        {
            Error = error;
        }

        public TError Error { get; }
    }

    public class NativeCallValue<TValue>
    {
        public NativeCallValue(TValue value)
        {
            Value = value;
        }

        public TValue Value { get; }
    }

    public class NativeCallState<TError, TValue>
    {
        public NativeCallState(TError error, TValue value)
        {
            Error = error;
            Value = value;
        }

        public TError Error { get; }
        public TValue Value { get; }
    }
}