using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.EndGame.Actions.Tie;
using tictactoe.Library.Bools;

namespace TicTacToeTests.EndGame.Actions.Tie
{
    [TestClass]
    public class ReturnTieEndsGameActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnTieStatus()
        {
            //Arrange
            Bool expected = Bool.True;
            ReturnTieEndsGameAction subject = new ReturnTieEndsGameAction();

            //Act
            bool actual = subject.Act(expected);

            //Assert
            actual.Should().Be(expected);
        }
    }
}