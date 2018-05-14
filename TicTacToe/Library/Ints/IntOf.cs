namespace tictactoe.Library.Ints
{
    public sealed class IntOf : Int
    {
        private readonly int _origin;

        public IntOf(int origin) => _origin = origin;

        //Note: Not sure how/if to remove the getterness
        protected override int RawValue() => _origin;
    }
}