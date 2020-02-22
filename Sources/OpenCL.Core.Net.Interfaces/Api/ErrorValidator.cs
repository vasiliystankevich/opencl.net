using OpenCL.Core.Net.Types.Enums;

namespace OpenCL.Core.Net.Interfaces.Kernel
{
    public interface IErrorValidator
    {
        void Validate(Error error);
    }
}
