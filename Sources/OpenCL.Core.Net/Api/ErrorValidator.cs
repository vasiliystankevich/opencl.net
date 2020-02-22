using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Types.Enums;

namespace OpenCL.Core.Net.Api
{
    public class ErrorValidator : IErrorValidator
    {
        public void Validate(Error error)
        {
            if (error != Error.Success) throw new Exception(error);
        }
    }
}