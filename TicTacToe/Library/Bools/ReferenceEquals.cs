namespace tictactoe.Library.Bools
{
    public sealed class ReferenceEquals : Bool
    {
        private readonly object _objA;
        private readonly object _objB;

        public ReferenceEquals(object objA, object objB)
        {
            _objA = objA;
            _objB = objB;
        }

        protected override bool RawValue() => ReferenceEquals(_objA, _objB);
    }
}