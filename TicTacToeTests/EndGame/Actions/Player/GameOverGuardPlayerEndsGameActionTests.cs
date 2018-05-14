using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.EndGame.Actions.Player;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.EndGame.Actions.Player
{
    [TestClass]
    public class GameOverGuardPlayerEndsGameActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnFalseGivenGameOver()
        {
            //Arrange
            FakePlayerEndsGameAction fakePlayerEndsGameAction = new FakePlayerEndsGameAction.Builder().Build();
            GameOverGuardPlayerEndsGameAction subject = new GameOverGuardPlayerEndsGameAction(fakePlayerEndsGameAction);
            FakeGameState fakeGameState = new FakeGameState.Builder().IsGameOver(Bool.True).Build();
            FakeBoard fakeBoard = new FakeBoard.Builder().GameState(fakeGameState).Build();
            //Act
            bool actual = subject.Act(fakeBoard, null, null);

            //Assert
            actual.Should().BeFalse();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnResultGivenNotGameOver()
        {
            //Arrange
            FakePlayerEndsGameAction fakePlayerEndsGameAction = new FakePlayerEndsGameAction.Builder().Act(Bool.True).Build();
            GameOverGuardPlayerEndsGameAction subject = new GameOverGuardPlayerEndsGameAction(fakePlayerEndsGameAction);
            FakeGameState fakeGameState = new FakeGameState.Builder().IsGameOver(Bool.False).Build();
            FakeBoard fakeBoard = new FakeBoard.Builder().GameState(fakeGameState).Build();
            //Act
            bool actual = subject.Act(fakeBoard, null, null);

            //Assert
            actual.Should().BeTrue();
            fakePlayerEndsGameAction.AssertActInvoked();
        }
    }
}
