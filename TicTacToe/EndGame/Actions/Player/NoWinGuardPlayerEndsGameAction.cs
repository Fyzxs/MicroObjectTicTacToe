using tictactoe.Boards;
using tictactoe.Library.Bools;
using tictactoe.Players;

namespace tictactoe.EndGame.Actions.Player {
    public sealed class NoWinGuardPlayerEndsGameAction : IPlayerEndsGameAction
    {
        private readonly IPlayerEndsGameAction _nextAction;

        public NoWinGuardPlayerEndsGameAction(IPlayerEndsGameAction nextAction) => _nextAction = nextAction;

        public Bool Act(IBoard board, IPlayer activePlayer, IPlayer inactivePlayer)
        {
            if (board.GameState().HasWinner().Not()) return Bool.False;

            return _nextAction.Act(board, activePlayer, inactivePlayer);
        }
    }
}