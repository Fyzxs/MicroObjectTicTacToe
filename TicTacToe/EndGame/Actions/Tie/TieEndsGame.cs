using tictactoe.Boards;
using tictactoe.Library.Bools;

namespace tictactoe.EndGame.Actions.Tie
{
    public sealed class TieEndsGame : Bool
    {
        private readonly IBoard _board;
        private readonly ITieEndsGameAction _command;

        public TieEndsGame(IBoard board) : this(board, new TieEndsGameAction()) { }

        public TieEndsGame(IBoard board, ITieEndsGameAction command)
        {
            _board = board;
            _command = command;
        }

        protected override bool RawValue() => _command.Act(_board.GameState().IsTie());
    }
}