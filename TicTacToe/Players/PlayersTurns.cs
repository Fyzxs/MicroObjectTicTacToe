using tictactoe.Boards;
using tictactoe.EndGame.Actions.Tie;
using tictactoe.Library.Bools;

namespace tictactoe.Players
{
    public sealed class PlayersTurns : IPlayersTurns
    {
        private readonly Bool _pOneEndsGame;
        private readonly Bool _pTwoEndsGame;
        private readonly Bool _tieEndsGame;

        public PlayersTurns(IBoard board, IPlayer playerOne, IPlayer playerTwo) : this(
            new PlayerTurnEndsGame(board, playerOne, playerTwo),
            new PlayerTurnEndsGame(board, playerTwo, playerOne),
            new TieEndsGame(board))
        { }

        public PlayersTurns(Bool pOneEndsGame, Bool pTwoEndsGame, Bool tieEndsGame)
        {
            _pOneEndsGame = pOneEndsGame;
            _pTwoEndsGame = pTwoEndsGame;
            _tieEndsGame = tieEndsGame;
        }

        public Bool GameOver() => _pOneEndsGame.Or(_pTwoEndsGame).Or(_tieEndsGame);
    }

    public interface IPlayersTurns
    {
        Bool GameOver();
    }
}