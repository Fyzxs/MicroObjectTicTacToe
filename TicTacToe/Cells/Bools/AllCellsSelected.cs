using System.Linq;
using tictactoe.Library.Bools;

namespace tictactoe.Cells.Bools
{
    public sealed class AllCellsSelected : Bool
    {
        private readonly ICellCollection _cellCollection;

        public AllCellsSelected(ICellCollection cellCollection) => _cellCollection = cellCollection;

        protected override bool RawValue() => _cellCollection.All(cell => cell.IsSelected());
    }
}