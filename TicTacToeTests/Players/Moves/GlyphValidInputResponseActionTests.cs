using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;
using tictactoe.Players.Moves;

namespace TicTacToeTests.Players.Moves {
    [TestClass]
    public class GlyphValidInputResponseActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnHuman()
        {
            //Arrange
            GlyphValidInputResponseAction subject = new GlyphValidInputResponseAction();

            //Act
            IGlyph actual = subject.Response("AB");

            //Assert
            actual.Value().Should().Be("A");
        }
    }
}