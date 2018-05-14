using System;
using tictactoe.Cells;
using tictactoe.IO;
using tictactoe.Library.Ints;

namespace tictactoe.Boards
{
    public sealed class BoardPrinter : IPrinter
    {
        private const string VertDivider = " | ";
        private static readonly string HorzLine = $"===+===+==={Environment.NewLine}";
        private static readonly Int TopLeft = new IntOf(0);
        private static readonly Int TopCenter = new IntOf(1);
        private static readonly Int TopRight = new IntOf(2);
        private static readonly Int CenterLeft = new IntOf(3);
        private static readonly Int CenterCenter = new IntOf(4);
        private static readonly Int CenterRight = new IntOf(5);
        private static readonly Int BottomLeft = new IntOf(6);
        private static readonly Int BottomCenter = new IntOf(7);
        private static readonly Int BottomRight = new IntOf(8);

        private readonly ICellCollection _cellBoard;
        private readonly IWriter _writer;

        public BoardPrinter(ICellCollection cellBoard) : this(cellBoard, new ConsoleWriterBookEnd()) { }

        public BoardPrinter(ICellCollection cellBoard, IWriter writer)
        {
            _cellBoard = cellBoard;
            _writer = writer;
        }

        public void Print() => _writer.WriteLine(
            TopRow() +
            HorzLine +
            CenterRow() +
            HorzLine +
            BottomRow()
        );

        private string TopRow() => CellLine(TopLeft, TopCenter, TopRight);
        private string CenterRow() => CellLine(CenterLeft, CenterCenter, CenterRight);
        private string BottomRow() => CellLine(BottomLeft, BottomCenter, BottomRight);
        private ICell Cell(Int index) => _cellBoard.At(index);
        private string CellLine(Int leftCell, Int centerCell, Int rightCell) =>
            $" {Cell(leftCell).Value()}{VertDivider}" +
            $"{Cell(centerCell).Value()}{VertDivider}" +
            $"{Cell(rightCell).Value()}{Environment.NewLine}";
    }
}