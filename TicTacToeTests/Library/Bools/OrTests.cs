using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Library.Bools;

namespace TicTacToeTests.Library.Bools {
    [TestClass]
    public class OrTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTrueGivenBothTrue()
        {
            //Arrange
            Or subject = new Or(Bool.True, Bool.True);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTrueGivenFirstTrue()
        {
            //Arrange
            Or subject = new Or(Bool.True, Bool.False);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTrueGivenSecondTrue()
        {
            //Arrange
            Or subject = new Or(Bool.True, Bool.False);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }


        [TestMethod, TestCategory("unit")]
        public void ShouldBeShortCircuitGivenFirstTrue()
        {
            //Arrange
            Or subject = new Or(Bool.True, new ThrowingBool());

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }

    }
}