using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.EndGame.Actions.Player;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.EndGame.Actions.Player
{
    [TestClass]
    public class PrintBoardPlayerEndsGameActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnResultGivenHasWinner()
        {
            //Arrange
            FakePlayerEndsGameAction fakePlayerEndsGameAction = new FakePlayerEndsGameAction.Builder().Act(Bool.True).Build();
            PrintBoardPlayerEndsGameAction subject = new PrintBoardPlayerEndsGameAction(fakePlayerEndsGameAction);
            FakeBoard fakeBoard = new FakeBoard.Builder().Print().Build();

            //Act
            bool actual = subject.Act(fakeBoard, null, null);

            //Assert
            actual.Should().BeTrue();
            fakeBoard.AssertPrintInvoked();
            fakePlayerEndsGameAction.AssertActInvoked();
        }
    }
}