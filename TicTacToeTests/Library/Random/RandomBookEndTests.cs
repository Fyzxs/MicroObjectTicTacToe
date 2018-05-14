using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Library.Ints;
using tictactoe.Library.Random;

namespace TicTacToeTests.Library.Random
{
    [TestClass]
    public class RandomBookEndTests
    {
        [TestMethod, TestCategory("integration")]
        public void ShouldReturnIntInRange()
        {
            //Arrange
            Int inclusiveMin = new IntOf(5);
            RandomBookEnd subject = new RandomBookEnd();

            //Act
            Int actual = subject.NextInt(inclusiveMin, new IntOf(50));

            //Assert
            ((int)actual).Should().BeLessThan(50);
            ((int)inclusiveMin).Should().BeLessOrEqualTo(actual);
        }
    }
}
