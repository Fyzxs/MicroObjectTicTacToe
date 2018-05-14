using tictactoe.Boards;
using tictactoe.Cells;

namespace tictactoe.Players.Moves.Computer.Easy
{
    public sealed class EasyComputerSelectMoveAction : ISelectMoveAction
    {
        private readonly ISelectMoveAction _nextAction;

        public EasyComputerSelectMoveAction() : this(
                new CurrentPlayerWinningSelectMoveAction(
                    new RandomSpaceSelectMoveAction()))
        { }

        public EasyComputerSelectMoveAction(ISelectMoveAction nextAction) => _nextAction = nextAction;

        public ICell Act(IBoard board, IPlayer thisPlayer, IPlayer otherPlayer) => _nextAction.Act(board, thisPlayer, otherPlayer);
    }
}