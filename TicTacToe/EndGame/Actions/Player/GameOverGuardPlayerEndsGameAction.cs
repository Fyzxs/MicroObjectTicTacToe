using tictactoe.Boards;
using tictactoe.Library.Bools;
using tictactoe.Players;

namespace tictactoe.EndGame.Actions.Player {
    public sealed class GameOverGuardPlayerEndsGameAction : IPlayerEndsGameAction
    {
        private readonly IPlayerEndsGameAction _nextAction;

        public GameOverGuardPlayerEndsGameAction(IPlayerEndsGameAction nextAction) => _nextAction = nextAction;

        public Bool Act(IBoard board, IPlayer activePlayer, IPlayer inactivePlayer)
        {
            if (board.GameState().IsGameOver()) return Bool.False;

            return _nextAction.Act(board, activePlayer, inactivePlayer);
        }
    }
}