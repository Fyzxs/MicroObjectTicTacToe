using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.EndGame.Actions.Player;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.EndGame.Actions.Player
{
    [TestClass]
    public class PrintWinPlayerEndsGameActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldWinPrintActivePlayer()
        {
            //Arrange
            FakePlayerEndsGameAction fakePlayerEndsGameAction = new FakePlayerEndsGameAction.Builder().Act(Bool.True).Build();
            PrintWinPlayerEndsGameAction subject = new PrintWinPlayerEndsGameAction(fakePlayerEndsGameAction);
            FakePrinter fakePrinter = new FakePrinter.Builder().Print().Build();
            FakePlayer fakePlayer = new FakePlayer.Builder().WinPrinter(fakePrinter).Build();

            //Act
            bool actual = subject.Act(null, fakePlayer, null);

            //Assert
            actual.Should().BeTrue();
            fakePrinter.AssertPrintInvoked();
            fakePlayerEndsGameAction.AssertActInvoked();
        }
    }
}