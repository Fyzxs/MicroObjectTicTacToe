namespace tictactoe.Library.Ints
{
    public sealed class ArrayLength : Int
    {
        private readonly object[] _origin;

        public ArrayLength(object[] origin) => _origin = origin;

        protected override int RawValue() => _origin.Length;
    }
}