using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;
using tictactoe.EndGame;
using tictactoe.Library.Bools;

namespace TicTacToeTests.EndGame
{
    [TestClass]
    public class BottomRowWinTests
    {
        [TestMethod, TestCategory("unit")]
        public void IsWin_ShouldReturnTrueForWin()
        {
            //Arrange
            ICell[] cells = {
                new UnselectedCell(new Glyph('0')), new UnselectedCell(new Glyph('1')), new UnselectedCell(new Glyph('2')),
                new UnselectedCell(new Glyph('3')), new UnselectedCell(new Glyph('4')), new UnselectedCell(new Glyph('5')),
                new UnselectedCell(new Glyph('?')), new UnselectedCell(new Glyph('?')), new UnselectedCell(new Glyph('?')),

            };
            CellCollection cellCollection = new CellCollection(cells);
            BottomRowWin subject = new BottomRowWin(cellCollection);

            //Act
            Bool actual = subject.IsWin();

            //Assert
            ((bool)actual).Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void IsWin_ShouldReturnFalseForNotWin()
        {
            //Arrange
            ICell[] cells = {
                new UnselectedCell(new Glyph('0')), new UnselectedCell(new Glyph('1')), new UnselectedCell(new Glyph('2')),
                new UnselectedCell(new Glyph('3')), new UnselectedCell(new Glyph('4')), new UnselectedCell(new Glyph('5')),
                new UnselectedCell(new Glyph('?')), new UnselectedCell(new Glyph('?')), new UnselectedCell(new Glyph('8')),

            };
            CellCollection cellCollection = new CellCollection(cells);
            BottomRowWin subject = new BottomRowWin(cellCollection);

            //Act
            Bool actual = subject.IsWin();

            //Assert
            ((bool)actual).Should().BeFalse();
        }
    }
}