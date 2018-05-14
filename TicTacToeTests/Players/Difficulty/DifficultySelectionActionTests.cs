using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Players.Difficulity;
using TicTacToeTests.Fakes;
using TicTacToeTests.Validators;

namespace TicTacToeTests.Players.Difficulty
{
    [TestClass]
    public class DifficultySelectionActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldInvokedNextAction()
        {
            //Arrange
            FakeDifficultySelectionAction nextAction = new FakeDifficultySelectionAction.Builder().Act(null).Build();
            DifficultySelectionAction subject = new DifficultySelectionAction(nextAction);

            //Act
            subject.Response("");

            //Assert
            nextAction.AssertActInvoked();
        }

        [TestMethod, TestCategory("functional")]
        public void ShouldHaveExpectedOrder()
        {
            //Arrange
            ChainValidation chainValidation = new ChainValidation()
                .Add<EasyDifficultySelectionAction>()
                .Add<MediumDifficultySelectionAction>()
                .Add<HardDifficultySelectionAction>();

            //Act
            DifficultySelectionAction subject = new DifficultySelectionAction();

            //Assert
            chainValidation.AssertExpectedChain(subject);
        }
    }
}