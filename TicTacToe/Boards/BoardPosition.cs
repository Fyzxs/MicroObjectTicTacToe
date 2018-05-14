using tictactoe.Cells;

namespace tictactoe.Boards
{
    public static class BoardPosition
    {
        public static readonly ICell TopLeft = new UnselectedCell(new Glyph('0'));
        public static readonly ICell TopCenter = new UnselectedCell(new Glyph('1'));
        public static readonly ICell TopRight = new UnselectedCell(new Glyph('2'));
        public static readonly ICell MiddleLeft = new UnselectedCell(new Glyph('3'));
        public static readonly ICell MiddleCenter = new UnselectedCell(new Glyph('4'));
        public static readonly ICell MiddleRight = new UnselectedCell(new Glyph('5'));
        public static readonly ICell BottomLeft = new UnselectedCell(new Glyph('6'));
        public static readonly ICell BottomCenter = new UnselectedCell(new Glyph('7'));
        public static readonly ICell BottomRight = new UnselectedCell(new Glyph('8'));
    }
}