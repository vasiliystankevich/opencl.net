using OpenCL.Core.Net.Types.Enums;

namespace OpenCL.Core.Net
{
    /// <summary>
    /// Represents an OpenCL(TM) exception that occured in one of the API functions.
    /// </summary>
    public class Exception : System.Exception
    {
        /// <summary>
        /// Creates a new exception instance with given error code.
        /// </summary>
        /// <param name="error">OpenCL(TM) error code.</param>
        public Exception(Error error)
        {
            ErrorCode = error;
        }

        /// <summary>
        /// Gets OpenCL(TM) error string and code.
        /// </summary>
        public override string Message => string.Format("OpenCL error {0} (Code: {1})", ErrorCode, (int)ErrorCode);

        /// <summary>
        /// OpenCL(TM) error code.
        /// </summary>
        public Error ErrorCode { get; }
    }
}
