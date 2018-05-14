using tictactoe.Boards;
using tictactoe.Cells;

namespace tictactoe.Players.Moves.Computer
{
    public sealed class RandomSpaceSelectMoveAction : ISelectMoveAction
    {
        public ICell Act(IBoard board, IPlayer thisPlayer, IPlayer otherPlayer) => new RandomCell(board.AvailableSpaces());
    }
}