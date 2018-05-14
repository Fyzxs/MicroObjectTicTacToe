using System.Collections.Generic;

namespace tictactoe.Library.Bools
{
    public sealed class IsCollectionEmpty<T> : Bool
    {
        private readonly Bool _origin;

        public IsCollectionEmpty(IEnumerable<T> enumerable) : this(new Any<T>(enumerable, t => Bool.True)) { }

        private IsCollectionEmpty(Bool origin) => _origin = origin;

        protected override bool RawValue() => _origin.Not();
    }
}