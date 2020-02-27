using System;

namespace OpenCL.Core.Net.Types
{
    public class Wrapper<TArg1>:IDisposable
    {
        public Wrapper(TArg1 arg1)
        {
            Arg1 = arg1;
        }

        public virtual void Dispose()
        {
            Dispose(Arg1);
        }
        protected void Dispose<T>(T field)
        {
            if (!(field is IDisposable)) return;
            ((IDisposable)field).Dispose();
        }

        public TArg1 Arg1 { get; }
    }
    public class Wrapper<TArg1, TArg2>:Wrapper<TArg1>
    {
        public Wrapper(TArg1 arg1, TArg2 arg2) : base(arg1)
        {
            Arg2 = arg2;
        }

        public override void Dispose()
        {
            Dispose(Arg2);
            base.Dispose();
        }

        public TArg2 Arg2 { get; }
    }

    public class Wrapper<TArg1, TArg2, TArg3> : Wrapper<TArg1, TArg2>
    {
        public Wrapper(TArg1 arg1, TArg2 arg2, TArg3 arg3) : base(arg1, arg2)
        {
            Arg3 = arg3;
        }

        public override void Dispose()
        {
            Dispose(Arg3);
            base.Dispose();
        }

        public TArg3 Arg3 { get; }
    }

    public class Wrapper<TArg1, TArg2, TArg3, TArg4> : Wrapper<TArg1, TArg2, TArg3>
    {
        public Wrapper(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) : base(arg1, arg2, arg3)
        {
            Arg4 = arg4;
        }

        public override void Dispose()
        {
            Dispose(Arg4);
            base.Dispose();
        }

        public TArg4 Arg4 { get; }
    }

    public class Wrapper<TArg1, TArg2, TArg3, TArg4, TArg5> : Wrapper<TArg1, TArg2, TArg3, TArg4>
    {
        public Wrapper(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5) : base(arg1, arg2, arg3, arg4)
        {
            Arg5 = arg5;
        }

        public override void Dispose()
        {
            Dispose(Arg5);
            base.Dispose();
        }

        public TArg5 Arg5 { get; }
    }
}