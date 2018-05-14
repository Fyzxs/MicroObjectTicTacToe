using tictactoe.Library.Bools;
using tictactoe.Library.Ints;

namespace tictactoe.Cells.Bools
{
    public sealed class IndexedCellEquality : Bool
    {
        private readonly ICellCollection _cells;
        private readonly Int _firstIndex;
        private readonly Int _secondIndex;

        public IndexedCellEquality(ICellCollection cells, Int firstIndex, Int secondIndex)
        {
            _cells = cells;
            _firstIndex = firstIndex;
            _secondIndex = secondIndex;
        }

        protected override bool RawValue() => new CellEquality(_cells.At(_firstIndex), _cells.At(_secondIndex));
    }
}