using tictactoe.Boards;
using tictactoe.Cells;

namespace tictactoe.Players.Moves.Computer
{
    public sealed class CenterSquareSelectMoveAction : ISelectMoveAction
    {
        private readonly ISelectMoveAction _nextAction;

        public CenterSquareSelectMoveAction(ISelectMoveAction nextAction) => _nextAction = nextAction;

        public ICell Act(IBoard board, IPlayer thisPlayer, IPlayer otherPlayer) =>
            board.Available(BoardPosition.MiddleCenter)
                ? BoardPosition.MiddleCenter
                : _nextAction.Act(board, thisPlayer, otherPlayer);
    }
}