using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;

namespace TicTacToeTests.Cells
{
    [TestClass]
    public class GlyphTests
    {
        [TestMethod, TestCategory("unit")]
        public void Value_ShouldReturnSymbol()
        {
            //Arrange
            Glyph subject = new Glyph('?');

            //Act
            string actual = subject.Value();

            //Assert
            actual.Should().Be("?");
        }
    }
}