using tictactoe.Boards;
using tictactoe.Cells;

namespace tictactoe.Players.Moves.Computer
{
    public abstract class PlayerWinningSelectMoveAction : ISelectMoveAction
    {
        private readonly ISelectMoveAction _nextAction;

        protected PlayerWinningSelectMoveAction(ISelectMoveAction nextAction) => _nextAction = nextAction;

        public ICell Act(IBoard board, IPlayer thisPlayer, IPlayer otherPlayer)
        {
            IPlayer player = Player(thisPlayer, otherPlayer);
            ICellCollection availableSpaces = board.AvailableSpaces();
            foreach (ICell cell in availableSpaces)
            {
                if (board.Clone().ClaimEndsGame(cell, player)) return cell;
            }

            return _nextAction.Act(board, thisPlayer, otherPlayer);
        }

        protected abstract IPlayer Player(IPlayer thisPlayer, IPlayer otherPlayer);
    }

    public sealed class CurrentPlayerWinningSelectMoveAction : PlayerWinningSelectMoveAction
    {
        public CurrentPlayerWinningSelectMoveAction(ISelectMoveAction nextAction) : base(nextAction) { }

        protected override IPlayer Player(IPlayer thisPlayer, IPlayer otherPlayer) => thisPlayer;
    }

    public sealed class OtherPlayerWinningSelectMoveAction : PlayerWinningSelectMoveAction
    {
        public OtherPlayerWinningSelectMoveAction(ISelectMoveAction nextAction) : base(nextAction) { }

        protected override IPlayer Player(IPlayer thisPlayer, IPlayer otherPlayer) => otherPlayer;
    }
}