namespace tictactoe.Library.Ints
{
    public sealed class Increment : Int
    {
        private readonly int _origin;

        public Increment(Int origin) => _origin = origin + 1;

        protected override int RawValue() => _origin;
    }
}
