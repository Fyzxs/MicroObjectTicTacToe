using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;
using tictactoe.EndGame;
using tictactoe.Library.Bools;

namespace TicTacToeTests.EndGame
{
    [TestClass]
    public class TieTests
    {
        [TestMethod, TestCategory("unit")]
        public void IsTie_ShouldReturnTrueForTie()
        {
            //Arrange
            ICellCollection cellCollection = new CellCollection(new ICell[] { new SelectedCell(null) });
            Tie subject = new Tie(cellCollection);

            //Act
            Bool actual = subject.IsTie();

            //Assert
            ((bool)actual).Should().BeTrue();
        }
        [TestMethod, TestCategory("unit")]
        public void IsTie_ShouldReturnFalseForNoneTie()
        {
            //Arrange
            ICellCollection cellCollection = new CellCollection(new ICell[] { new UnselectedCell(new Glyph('.')) });
            Tie subject = new Tie(cellCollection);

            //Act
            Bool actual = subject.IsTie();

            //Assert
            ((bool)actual).Should().BeFalse();
        }
    }
}
