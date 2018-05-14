using tictactoe.Library.Bools;

namespace tictactoe.Library.Ints
{
    public abstract class Int
    {
        public static implicit operator int(Int origin) => origin.RawValue();

        public Int Incremented() => new Increment(this);

        public Bool Equal(Int checkValue) => new IntEquality(this, checkValue);


        protected abstract int RawValue();
    }
}