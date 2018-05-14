using tictactoe.Cells;
using tictactoe.Cells.Bools;
using tictactoe.Library.Bools;
using tictactoe.Library.Ints;

namespace tictactoe.EndGame
{
    public abstract class Win : IWin
    {
        protected static readonly Int TopLeft = new IntOf(0);
        protected static readonly Int TopCenter = new IntOf(1);
        protected static readonly Int TopRight = new IntOf(2);
        protected static readonly Int MiddleLeft = new IntOf(3);
        protected static readonly Int MiddleCenter = new IntOf(4);
        protected static readonly Int MiddleRight = new IntOf(5);
        protected static readonly Int BottomLeft = new IntOf(6);
        protected static readonly Int BottomCenter = new IntOf(7);
        protected static readonly Int BottomRight = new IntOf(8);
        private readonly Bool _firstPairEqual;
        private readonly Bool _secondPairEqual;

        protected Win(ICellCollection cells, Int firstIndex, Int secondIndex, Int thirdIndex) :
            this(new IndexedCellEquality(cells, firstIndex, secondIndex), new IndexedCellEquality(cells, firstIndex, thirdIndex))
        { }

        protected Win(Bool firstPairEqual, Bool secondPairEqual)
        {
            _firstPairEqual = firstPairEqual;
            _secondPairEqual = secondPairEqual;
        }

        public Bool IsWin() => _firstPairEqual.And(_secondPairEqual);
    }

    public sealed class TopRowWin : Win
    {
        public TopRowWin(ICellCollection cells) : base(cells, TopLeft, TopCenter, TopRight) { }
    }

    public sealed class CenterRowWin : Win
    {
        public CenterRowWin(ICellCollection cells) : base(cells, MiddleLeft, MiddleCenter, MiddleRight) { }
    }

    public sealed class BottomRowWin : Win
    {
        public BottomRowWin(ICellCollection cells) : base(cells, BottomLeft, BottomCenter, BottomRight) { }
    }

    public sealed class LeftColumnWin : Win
    {
        public LeftColumnWin(ICellCollection cells) : base(cells, TopLeft, MiddleLeft, BottomLeft) { }
    }

    public sealed class CenterColumnWin : Win
    {
        public CenterColumnWin(ICellCollection cells) : base(cells, TopCenter, MiddleCenter, BottomCenter) { }
    }

    public sealed class RightColumnWin : Win
    {
        public RightColumnWin(ICellCollection cells) : base(cells, TopRight, MiddleRight, BottomRight) { }
    }

    public sealed class TopRightSlashWin : Win
    {
        public TopRightSlashWin(ICellCollection cells) : base(cells, TopRight, MiddleCenter, BottomLeft) { }
    }

    public sealed class TopLeftSlashWin : Win
    {
        public TopLeftSlashWin(ICellCollection cells) : base(cells, TopLeft, MiddleCenter, BottomRight) { }
    }
}