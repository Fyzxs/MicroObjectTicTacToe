using tictactoe.Library.Bools;

namespace tictactoe.Cells.Bools
{
    public sealed class CellEquality : Bool
    {
        private readonly ICell _cellA;
        private readonly ICell _cellB;

        public CellEquality(ICell cellA, ICell cellB)
        {
            _cellA = cellA;
            _cellB = cellB;
        }

        protected override bool RawValue() => _cellA.Value() == _cellB.Value();
    }
}