using tictactoe.Boards;
using tictactoe.Players;

namespace tictactoe.GameMode
{
    public interface IGameMode
    {
        IPlayersTurns ConfigurePlayers(IBoard board);
    }
}