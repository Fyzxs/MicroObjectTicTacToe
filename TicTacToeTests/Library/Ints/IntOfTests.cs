using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Library.Ints;

namespace TicTacToeTests.Library.Ints
{
    [TestClass]
    public class IntOfTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnValue()
        {
            //Arrange
            IntOf subject = new IntOf(12);

            //Act
            int actual = subject;

            //Assert
            actual.Should().Be(12);
        }
    }
}