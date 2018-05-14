using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.EndGame.Actions.Player;

namespace TicTacToeTests.EndGame.Actions.Player {
    [TestClass]
    public class DefaultPlayerEndsGameActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldWinPrintActivePlayer()
        {
            //Arrange
            DefaultPlayerEndsGameAction subject = new DefaultPlayerEndsGameAction();

            //Act
            bool actual = subject.Act(null, null, null);

            //Assert
            actual.Should().BeTrue();
        }
    }
}