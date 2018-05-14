using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using tictactoe.Library.Bools;

namespace TicTacToeTests.Library.Bools
{
    [TestClass]
    public class IsCollectionEmptyTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTrueForEmpty()
        {
            //Arrange
            IsCollectionEmpty<string> subject = new IsCollectionEmpty<string>(new List<string>());

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeFalseForNonEmpty()
        {
            //Arrange
            IsCollectionEmpty<string> subject = new IsCollectionEmpty<string>(new List<string> { "" });

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }
    }
}