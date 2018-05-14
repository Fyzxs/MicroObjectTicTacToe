using tictactoe.Library.Bools;

namespace tictactoe.Cells.Bools
{
    public sealed class MatchedCellAvailable : Bool
    {
        private readonly ICell _boardCell;
        private readonly Bool _origin;

        public MatchedCellAvailable(ICell boardCell, ICell checkCell) : this(boardCell, new CellEquality(boardCell, checkCell)) { }

        public MatchedCellAvailable(ICell boardCell, Bool origin)
        {
            _boardCell = boardCell;
            _origin = origin;
        }

        protected override bool RawValue() => _origin.And(_boardCell.IsSelected().Not());
    }
}