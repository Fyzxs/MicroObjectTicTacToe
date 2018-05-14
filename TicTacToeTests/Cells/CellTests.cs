using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;
using tictactoe.Library.Bools;

namespace TicTacToeTests.Cells
{
    [TestClass]
    public class CellTests
    {

        [TestMethod, TestCategory("unit")]
        public void Value_ShouldReturnSymbol()
        {
            //Arrange
            Cell subject = new TestUnselectedCell(new Glyph('?'));

            //Act
            string actual = subject.Value();

            //Assert
            actual.Should().Be("?");
        }

        [TestMethod, TestCategory("unit")]
        public void IsSelected_ShouldNotBeReplaced()
        {
            //Arrange
            Cell subject = new TestUnselectedCell(new Glyph('?'));

            //Act
            Bool actual = subject.IsSelected();

            //Assert
            ((bool)actual).Should().BeFalse();
        }

        private class TestUnselectedCell : Cell
        {
            public TestUnselectedCell(IGlyph glyph) : base(glyph, Unselected) { }
        }
    }
}