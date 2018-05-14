using tictactoe.Boards;
using tictactoe.Library.Bools;
using tictactoe.Players;

namespace tictactoe.EndGame.Actions.Player
{
    public sealed class DefaultPlayerEndsGameAction : IPlayerEndsGameAction
    {
        public Bool Act(IBoard board, IPlayer activePlayer, IPlayer inactivePlayer) => Bool.True;
    }
}