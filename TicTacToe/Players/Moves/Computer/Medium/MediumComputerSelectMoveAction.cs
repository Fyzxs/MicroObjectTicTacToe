using tictactoe.Boards;
using tictactoe.Cells;

namespace tictactoe.Players.Moves.Computer.Medium
{
    public sealed class MediumComputerSelectMoveAction : ISelectMoveAction
    {
        private readonly ISelectMoveAction _nextAction;
        public MediumComputerSelectMoveAction() : this(
                new CenterSquareSelectMoveAction(
                    new CurrentPlayerWinningSelectMoveAction(
                        new OtherPlayerWinningSelectMoveAction(
                            new RandomSpaceSelectMoveAction()))))
        { }

        public MediumComputerSelectMoveAction(ISelectMoveAction nextAction) => _nextAction = nextAction;

        public ICell Act(IBoard board, IPlayer thisPlayer, IPlayer otherPlayer) => _nextAction.Act(board, thisPlayer, otherPlayer);
    }
}