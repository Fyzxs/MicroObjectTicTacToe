using tictactoe.Boards;
using tictactoe.Library.Bools;
using tictactoe.Players;

namespace tictactoe.EndGame.Actions.Player
{
    public sealed class PlayerEndsGameAction : IPlayerEndsGameAction
    {
        private readonly IPlayerEndsGameAction _nextAction;

        public PlayerEndsGameAction() : this(
            new GameOverGuardPlayerEndsGameAction(
                new TakeTurnPlayerEndsGameAction(
                    new PrintBoardPlayerEndsGameAction(
                        new NoWinGuardPlayerEndsGameAction(
                            new PrintWinPlayerEndsGameAction(
                                new DefaultPlayerEndsGameAction()))))))
        { }

        public PlayerEndsGameAction(IPlayerEndsGameAction nextaction) => _nextAction = nextaction;

        public Bool Act(IBoard board, IPlayer activePlayer, IPlayer inactivePlayer) => _nextAction.Act(board, activePlayer, inactivePlayer);
    }
}