using System.Diagnostics;

namespace tictactoe.Library.Bools
{
    [DebuggerDisplay("{RawValue()}")]
    public abstract class Bool
    {
        public static readonly Bool True = new BoolOf(true);
        public static readonly Bool False = new BoolOf(false);

        public static implicit operator bool(Bool origin) => origin.RawValue();

        public Bool Not() => new Not(this);

        public Bool And(Bool and) => new And(this, and);

        public Bool Or(Bool or) => new Or(this, or);

        protected abstract bool RawValue();
    }
}