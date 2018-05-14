using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Library.Bools;

namespace TicTacToeTests.Library.Bools
{
    [TestClass]
    public class AndTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTrueGivenBothTrue()
        {
            //Arrange
            And subject = new And(Bool.True, Bool.True);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeFalseGivenFirstFalse()
        {
            //Arrange
            And subject = new And(Bool.False, Bool.True);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeFalseGivenSecondFalse()
        {
            //Arrange
            And subject = new And(Bool.True, Bool.False);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeShortCircuitGivenFirstFalse()
        {
            //Arrange
            And subject = new And(Bool.False, new ThrowingBool());

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }
    }
}
