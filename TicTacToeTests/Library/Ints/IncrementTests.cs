using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Library.Ints;

namespace TicTacToeTests.Library.Ints {
    [TestClass]
    public class IncrementTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldIncrement()
        {
            //Arrange
            Increment subject = new Increment(new IntOf(0));

            //Act
            int actual = subject;

            //Assert
            actual.Should().Be(1);
        }
    }
}