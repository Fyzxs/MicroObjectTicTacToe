using tictactoe.Boards;
using tictactoe.Library.Bools;
using tictactoe.Players;

namespace tictactoe.EndGame.Actions.Player {
    public interface IPlayerEndsGameAction
    {
        Bool Act(IBoard board, IPlayer activePlayer, IPlayer inactivePlayer);
    }
}