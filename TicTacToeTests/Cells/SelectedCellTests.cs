using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;
using tictactoe.Library.Bools;

namespace TicTacToeTests.Cells
{
    [TestClass]
    public class SelectedCellTests
    {
        [TestMethod, TestCategory("unit")]
        public void IsSelected_ShouldReturnTrueForReplaced()
        {
            //Arrange
            SelectedCell subject = new SelectedCell(null);

            //Act
            Bool actual = subject.IsSelected();

            //Assert
            ((bool)actual).Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void Value_ShouldReturnValueOfOrigin()
        {
            //Arrange
            Glyph origin = new Glyph('?');
            SelectedCell subject = new SelectedCell(origin);

            //Act
            string actual = subject.Value();

            //Assert
            actual.Should().Be("?");
        }
    }
}