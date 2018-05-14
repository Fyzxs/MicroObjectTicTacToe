using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Library.Bools;

namespace TicTacToeTests.Library.Bools
{
    [TestClass]
    public class ReferenceEqualsTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTrueGivenSame()
        {
            //Arrange
            object it = new object();
            ReferenceEquals subject = new ReferenceEquals(it, it);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldBeFalseGivenNotSame()
        {
            //Arrange
            object it = new object();
            object its = new object();
            ReferenceEquals subject = new ReferenceEquals(it, its);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }
    }
}