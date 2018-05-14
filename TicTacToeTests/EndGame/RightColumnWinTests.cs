using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;
using tictactoe.EndGame;
using tictactoe.Library.Bools;

namespace TicTacToeTests.EndGame
{
    [TestClass]
    public class RightColumnWinTests
    {
        [TestMethod, TestCategory("unit")]
        public void IsWin_ShouldReturnTrueForWin()
        {
            //Arrange
            ICell[] cells = {
                new UnselectedCell(new Glyph('0')), new UnselectedCell(new Glyph('1')), new UnselectedCell(new Glyph('?')),
                new UnselectedCell(new Glyph('3')), new UnselectedCell(new Glyph('4')), new UnselectedCell(new Glyph('?')),
                new UnselectedCell(new Glyph('6')), new UnselectedCell(new Glyph('7')), new UnselectedCell(new Glyph('?'))

            };
            CellCollection cellCollection = new CellCollection(cells);
            RightColumnWin subject = new RightColumnWin(cellCollection);

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
                new UnselectedCell(new Glyph('0')), new UnselectedCell(new Glyph('1')), new UnselectedCell(new Glyph('?')),
                new UnselectedCell(new Glyph('3')), new UnselectedCell(new Glyph('4')), new UnselectedCell(new Glyph('?')),
                new UnselectedCell(new Glyph('6')), new UnselectedCell(new Glyph('7')), new UnselectedCell(new Glyph('8'))

            };
            CellCollection cellCollection = new CellCollection(cells);
            RightColumnWin subject = new RightColumnWin(cellCollection);

            //Act
            Bool actual = subject.IsWin();

            //Assert
            ((bool)actual).Should().BeFalse();
        }
    }
}