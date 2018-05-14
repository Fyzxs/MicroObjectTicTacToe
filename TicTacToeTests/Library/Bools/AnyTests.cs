using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using tictactoe.Library.Bools;

namespace TicTacToeTests.Library.Bools
{
    [TestClass]
    public class AnyTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeFalseForEmpty()
        {
            //Arrange
            Any<string> subject = new Any<string>(new List<string>(), s => throw new Exception());

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldBeFalseForNoMatches()
        {
            //Arrange
            Any<string> subject = new Any<string>(new List<string> { "" }, s => Bool.False);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTrueForAnyMatch()
        {
            //Arrange
            Any<string> subject = new Any<string>(new List<string> { "" }, s => Bool.True);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }
    }
}