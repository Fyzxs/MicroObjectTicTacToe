using tictactoe.Boards;
using tictactoe.Cells;
using tictactoe.IO;
using tictactoe.Players.Moves;
using tictactoe.Players.Moves.Human;

namespace tictactoe.Players
{
    public abstract class Player : IPlayer
    {
        private readonly IGlyph _glyph;
        private readonly ISelectMoveAction _selectMove;

        protected Player(IGlyph glyph, ISelectMoveAction selectMove)
        {
            _glyph = glyph;
            _selectMove = selectMove;
        }

        public void TakeAction(IBoard board, IPlayer otherPlayer) => board.ClaimEndsGame(SelectMove(board, otherPlayer), this);

        public ICell Cell() => new UnselectedCell(_glyph);

        public IPrinter WinPrinter() => new PlayerWinPrinter(this);

        private ICell SelectMove(IBoard board, IPlayer otherPlayer) => _selectMove.Act(board, this, otherPlayer);
    }

    public interface IPlayer
    {
        void TakeAction(IBoard board, IPlayer otherPlayer);
        ICell Cell();
        IPrinter WinPrinter();
    }

    public sealed class ComputerPlayer : Player
    {
        public ComputerPlayer(char glyph, ISelectMoveAction selectMove) : this(new Glyph(glyph), selectMove) { }
        public ComputerPlayer(IGlyph glyph, ISelectMoveAction selectMove) : base(glyph, selectMove) { }
    }

    public sealed class HumanPlayer : Player
    {
        public HumanPlayer(char glyph) : this(new Glyph(glyph)) { }
        public HumanPlayer(IGlyph glyph) : base(glyph, new HumanSelectMoveAction()) { }
    }
}