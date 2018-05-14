using tictactoe.Boards;
using tictactoe.Library.Bools;
using tictactoe.Players;

namespace tictactoe.EndGame.Actions.Player {
    public sealed class PrintBoardPlayerEndsGameAction : IPlayerEndsGameAction
    {
        private readonly IPlayerEndsGameAction _nextAction;

        public PrintBoardPlayerEndsGameAction(IPlayerEndsGameAction nextAction) => _nextAction = nextAction;

        public Bool Act(IBoard board, IPlayer activePlayer, IPlayer inactivePlayer)
        {
            board.Print();
            return _nextAction.Act(board, activePlayer, inactivePlayer);
        }
    }
}