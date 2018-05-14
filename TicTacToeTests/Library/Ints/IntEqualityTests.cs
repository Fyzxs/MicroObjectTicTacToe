using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Library.Ints;

namespace TicTacToeTests.Library.Ints
{
    [TestClass]
    public class IntEqualityTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTrueForEqualValues()
        {
            //Arrange
            IntEquality subject = new IntEquality(new IntOf(1), new IntOf(1));

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeFalseForNotEqualValues()
        {
            //Arrange
            IntEquality subject = new IntEquality(new IntOf(5), new IntOf(1));

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }
    }
}