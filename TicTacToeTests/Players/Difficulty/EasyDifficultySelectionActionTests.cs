using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Players.Difficulity;
using tictactoe.Players.Moves;
using tictactoe.Players.Moves.Computer.Easy;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Players.Difficulty
{
    [TestClass]
    public class EasyDifficultySelectionActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnCorrectModeGivenInput()
        {
            //Arrange
            FakeDifficultySelectionAction nextAction = new FakeDifficultySelectionAction.Builder().Build();
            EasyDifficultySelectionAction subject = new EasyDifficultySelectionAction(nextAction);

            //Act
            ISelectMoveAction selectMoveAction = subject.Act("1");

            //Assert
            selectMoveAction.Should().BeOfType<EasyComputerSelectMoveAction>();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldInvokeNextActionIfNotHandled()
        {
            //Arrange
            FakeSelectMoveAction fakeSelectMoveAction = new FakeSelectMoveAction.Builder().Build();
            FakeDifficultySelectionAction nextAction = new FakeDifficultySelectionAction.Builder().Act(fakeSelectMoveAction).Build();
            EasyDifficultySelectionAction subject = new EasyDifficultySelectionAction(nextAction);

            //Act
            subject.Act("2");

            //Assert
            nextAction.AssertActInvoked();
        }
    }
}