using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Primitives;

namespace OpenCL.Core.Net.Types
{
    public delegate Error NativeFunc();
    public delegate Error NativeFuncRefSizeT(ref SizeT size);

    public delegate T NativeFunc<out T>(ref Error error);
}