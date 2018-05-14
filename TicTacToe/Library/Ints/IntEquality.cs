using tictactoe.Library.Bools;

namespace tictactoe.Library.Ints
{
    public sealed class IntEquality : Bool
    {
        private readonly Int _lhs;
        private readonly Int _rhs;

        public IntEquality(Int lhs, Int rhs)
        {
            _lhs = lhs;
            _rhs = rhs;
        }

        protected override bool RawValue() => _lhs == (int)_rhs;
    }
}