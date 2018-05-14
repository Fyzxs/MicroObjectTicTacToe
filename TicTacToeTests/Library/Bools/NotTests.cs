using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Library.Bools;

namespace TicTacToeTests.Library.Bools
{
    [TestClass]
    public class NotTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTrueWhenFalse()
        {
            //Arrange
            Not subject = new Not(Bool.False);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldBeFalseWhenTrue()
        {
            //Arrange
            Not subject = new Not(Bool.True);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }
    }
}