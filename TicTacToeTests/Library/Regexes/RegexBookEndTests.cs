using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Library.Bools;
using tictactoe.Library.Regexs;

namespace TicTacToeTests.Library.Regexes
{
    [TestClass]
    public class RegexBookEndTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldMatch()
        {
            //Arrange
            RegexBookEnd subject = new RegexBookEnd(".");
            Bool isMatch = subject.IsMatch("a");

            //Act
            bool actual = isMatch;

            //Assert
            actual.Should().BeTrue();
        }
    }
}