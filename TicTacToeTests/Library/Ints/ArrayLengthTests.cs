using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Library.Ints;

namespace TicTacToeTests.Library.Ints
{
    [TestClass]
    public class ArrayLengthTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnLengthOfArray()
        {
            //Arrange
            object[] objects = new object[0];
            ArrayLength arrayLength = new ArrayLength(objects);

            //Act
            int actual = arrayLength;

            //Assert
            actual.Should().Be(0);
        }
    }
}