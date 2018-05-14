using tictactoe.Boards;
using tictactoe.Library.Bools;
using tictactoe.Players;

namespace tictactoe.EndGame.Actions.Player {
    public sealed class PrintWinPlayerEndsGameAction : IPlayerEndsGameAction
    {
        private readonly IPlayerEndsGameAction _nextAction;

        public PrintWinPlayerEndsGameAction(IPlayerEndsGameAction nextAction) => _nextAction = nextAction;

        public Bool Act(IBoard board, IPlayer activePlayer, IPlayer inactivePlayer)
        {
            activePlayer.WinPrinter().Print();
            return _nextAction.Act(board, activePlayer, inactivePlayer);
        }
    }
}