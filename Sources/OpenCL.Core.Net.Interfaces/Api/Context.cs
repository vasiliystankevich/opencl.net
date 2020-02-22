using OpenCL.Core.Net.Types.Enums.Context;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Interfaces.Api
{
    public interface IContextApi
    {
        object GetContextInfo(ContextInfo info);
        object GetContextInfo(Context ctx, ContextInfo info);
    }
}