using tictactoe.Cells;
using tictactoe.Cells.Bools;
using tictactoe.Library.Bools;

namespace tictactoe.EndGame
{
    public sealed class Tie : ITie
    {
        private readonly ICellCollection _cellCollection;

        public Tie(ICellCollection cellCollection) => _cellCollection = cellCollection;

        public Bool IsTie() => new AllCellsSelected(_cellCollection);
    }

    public interface ITie
    {
        Bool IsTie();
    }
}