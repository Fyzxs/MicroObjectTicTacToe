using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using tictactoe.Boards;
using tictactoe.Cells;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Boards
{
    [TestClass]
    public class BoardConsolePrinterTests
    {
        [TestMethod, TestCategory("unit")]
        public void Into_ShouldWriteInto()
        {
            string rn = Environment.NewLine;
            //Arrange
            CellCollection cellCollection = new CellCollection(new ICell[]
            {
                new UnselectedCell(new Glyph('0')),
                new UnselectedCell(new Glyph('1')),
                new UnselectedCell(new Glyph('2')),
                new UnselectedCell(new Glyph('3')),
                new UnselectedCell(new Glyph('4')),
                new UnselectedCell(new Glyph('5')),
                new UnselectedCell(new Glyph('6')),
                new UnselectedCell(new Glyph('7')),
                new UnselectedCell(new Glyph('8'))
            });
            FakeWriter fakeWriter = new FakeWriter();
            BoardPrinter subject = new BoardPrinter(cellCollection, fakeWriter);

            //Act
            subject.Print();

            //Assert
            fakeWriter.AssertLinesWritten($" 0 | 1 | 2{rn}===+===+==={rn} 3 | 4 | 5{rn}===+===+==={rn} 6 | 7 | 8{rn}");
        }
    }
}
