using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.EndGame.Actions.Player;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.EndGame.Actions.Player
{
    [TestClass]
    public class TakeTurnPlayerEndsGameActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldWinPrintActivePlayer()
        {
            //Arrange
            FakePlayerEndsGameAction fakePlayerEndsGameAction = new FakePlayerEndsGameAction.Builder().Act(Bool.True).Build();
            TakeTurnPlayerEndsGameAction subject = new TakeTurnPlayerEndsGameAction(fakePlayerEndsGameAction);
            FakePlayer fakePlayer = new FakePlayer.Builder().TakeAction().Build();

            //Act
            bool actual = subject.Act(null, fakePlayer, null);

            //Assert
            actual.Should().BeTrue();
            fakePlayer.AssertTakeActionInvoked();
            fakePlayerEndsGameAction.AssertActInvoked();
        }
    }
}