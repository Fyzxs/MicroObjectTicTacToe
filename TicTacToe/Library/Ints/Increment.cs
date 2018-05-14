namespace tictactoe.Library.Ints
{
    public sealed class Increment : Int
    {
        private readonly Int _origin;

        public Increment(Int origin) => _origin = origin;

        protected override int RawValue() => _origin + 1;
    }
}