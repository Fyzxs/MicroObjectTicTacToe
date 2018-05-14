using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.EndGame.Actions.Player;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.EndGame.Actions.Player
{
    [TestClass]
    public class NoWinGuardPlayerEndsGameActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnTrueGivenNotHasWinner()
        {
            //Arrange
            FakePlayerEndsGameAction fakePlayerEndsGameAction = new FakePlayerEndsGameAction.Builder().Build();
            NoWinGuardPlayerEndsGameAction subject = new NoWinGuardPlayerEndsGameAction(fakePlayerEndsGameAction);
            FakeGameState fakeGameState = new FakeGameState.Builder().HasWinner(Bool.False).Build();
            FakeBoard fakeBoard = new FakeBoard.Builder().GameState(fakeGameState).Build();
            //Act
            bool actual = subject.Act(fakeBoard, null, null);

            //Assert
            actual.Should().BeFalse();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnResultGivenHasWinner()
        {
            //Arrange
            FakePlayerEndsGameAction fakePlayerEndsGameAction = new FakePlayerEndsGameAction.Builder().Act(Bool.True).Build();
            NoWinGuardPlayerEndsGameAction subject = new NoWinGuardPlayerEndsGameAction(fakePlayerEndsGameAction);
            FakeGameState fakeGameState = new FakeGameState.Builder().HasWinner(Bool.True).Build();
            FakeBoard fakeBoard = new FakeBoard.Builder().GameState(fakeGameState).Build();
            //Act
            bool actual = subject.Act(fakeBoard, null, null);

            //Assert
            actual.Should().BeTrue();
            fakePlayerEndsGameAction.AssertActInvoked();
        }
    }
}