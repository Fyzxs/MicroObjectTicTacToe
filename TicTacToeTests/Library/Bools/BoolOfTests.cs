using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Library.Bools;

namespace TicTacToeTests.Library.Bools {
    [TestClass]
    public class BoolOfTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnValue()
        {
            //Arrange
            BoolOf subject = new BoolOf(true);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }
    }
}