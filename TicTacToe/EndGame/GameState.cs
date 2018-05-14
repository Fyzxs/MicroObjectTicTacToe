using tictactoe.Cells;
using tictactoe.Library.Bools;

namespace tictactoe.EndGame
{
    public sealed class GameState : IGameState
    {
        private readonly ITie _tie;
        private readonly IWin _win;

        public GameState(ICellCollection cellCollection) : this(
            new PossibleWins(cellCollection),
            new Tie(cellCollection))
        { }

        public GameState(IWin win, ITie tie)
        {
            _win = win;
            _tie = tie;
        }

        public Bool IsGameOver() => HasWinner().Or(IsTie());

        public Bool HasWinner() => _win.IsWin();

        public Bool IsTie() => _tie.IsTie();
    }

    public interface IGameState
    {
        Bool IsGameOver();
        Bool HasWinner();
        Bool IsTie();
    }
}