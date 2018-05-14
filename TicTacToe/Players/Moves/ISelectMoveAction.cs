using tictactoe.Boards;
using tictactoe.Cells;

namespace tictactoe.Players.Moves
{
    public interface ISelectMoveAction
    {
        ICell Act(IBoard board, IPlayer thisPlayer, IPlayer otherPlayer);
    }
}