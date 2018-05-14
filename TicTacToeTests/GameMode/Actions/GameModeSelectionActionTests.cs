using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.GameMode.Actions;
using TicTacToeTests.Fakes;
using TicTacToeTests.Validators;

namespace TicTacToeTests.GameMode.Actions
{
    [TestClass]
    public class GameModeSelectionActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldInvokedNextAction()
        {
            //Arrange
            FakeGameModeSelectionAction nextAction = new FakeGameModeSelectionAction.Builder().Act(null).Build();
            GameModeSelectionAction subject = new GameModeSelectionAction(nextAction);

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
                .Add<HumanVsComputerGameModeSelectionAction>()
                .Add<HumanVsHumanGameModeSelectionAction>()
                .Add<ComputerVsComputerGameModeSelectionAction>();
            //Act
            GameModeSelectionAction subject = new GameModeSelectionAction();

            //Assert
            chainValidation.AssertExpectedChain(subject);
        }
    }
}