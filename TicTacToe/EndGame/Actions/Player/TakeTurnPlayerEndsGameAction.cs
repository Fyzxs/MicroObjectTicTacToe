using tictactoe.Boards;
using tictactoe.Library.Bools;
using tictactoe.Players;

namespace tictactoe.EndGame.Actions.Player
{
    public sealed class TakeTurnPlayerEndsGameAction : IPlayerEndsGameAction
    {
        private readonly IPlayerEndsGameAction _nextAction;

        public TakeTurnPlayerEndsGameAction(IPlayerEndsGameAction nextAction) => _nextAction = nextAction;

        public Bool Act(IBoard board, IPlayer activePlayer, IPlayer inactivePlayer)
        {
            activePlayer.TakeAction(board, inactivePlayer);
            return _nextAction.Act(board, activePlayer, inactivePlayer);
        }
    }
}