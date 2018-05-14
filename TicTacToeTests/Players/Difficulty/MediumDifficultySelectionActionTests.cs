using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Players.Difficulity;
using tictactoe.Players.Moves;
using tictactoe.Players.Moves.Computer.Medium;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Players.Difficulty
{
    [TestClass]
    public class MediumDifficultySelectionActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnCorrectModeGivenInput()
        {
            //Arrange
            FakeDifficultySelectionAction nextAction = new FakeDifficultySelectionAction.Builder().Build();
            MediumDifficultySelectionAction subject = new MediumDifficultySelectionAction(nextAction);

            //Act
            ISelectMoveAction selectMoveAction = subject.Act("2");

            //Assert
            selectMoveAction.Should().BeOfType<MediumComputerSelectMoveAction>();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldInvokeNextActionIfNotHandled()
        {
            //Arrange
            FakeSelectMoveAction fakeSelectMoveAction = new FakeSelectMoveAction.Builder().Build();
            FakeDifficultySelectionAction nextAction = new FakeDifficultySelectionAction.Builder().Act(fakeSelectMoveAction).Build();
            MediumDifficultySelectionAction subject = new MediumDifficultySelectionAction(nextAction);

            //Act
            subject.Act("3");

            //Assert
            nextAction.AssertActInvoked();
        }
    }
}