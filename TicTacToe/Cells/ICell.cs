using tictactoe.Library.Bools;

namespace tictactoe.Cells
{
    public interface ICell
    {
        string Value();
        Bool IsSelected();
        ICell AsSelected();
    }
}