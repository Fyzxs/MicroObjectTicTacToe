using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;
using tictactoe.Library.Bools;

namespace TicTacToeTests.Cells
{
    [TestClass]
    public class UnselectedCellTests
    {
        [TestMethod, TestCategory("unit")]
        public void IsSelected_ShouldReturnTrueForReplaced()
        {
            //Arrange
            UnselectedCell subject = new UnselectedCell(null);

            //Act
            Bool actual = subject.IsSelected();

            //Assert
            ((bool)actual).Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void Value_ShouldReturnValueOfOrigin()
        {
            //Arrange
            Glyph origin = new Glyph('?');
            UnselectedCell subject = new UnselectedCell(origin);

            //Act
            string actual = subject.Value();

            //Assert
            actual.Should().Be("?");
        }
    }
}