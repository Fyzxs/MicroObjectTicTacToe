using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.GameMode;
using tictactoe.GameMode.Actions;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.GameMode.Actions {
    [TestClass]
    public class HumanVsComputerGameModeSelectionActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnHumanVsComputerGameMode()
        {
            //Arrange
            FakeGameModeSelectionAction nextAction = new FakeGameModeSelectionAction.Builder().Build();
            HumanVsComputerGameModeSelectionAction subject = new HumanVsComputerGameModeSelectionAction(nextAction);

            //Act
            IGameMode gameMode = subject.Act("1");

            //Assert
            gameMode.Should().BeOfType<HumanVsComputerGameMode>();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldInvokeAct()
        {
            //Arrange
            FakeGameMode fakeGameMode = new FakeGameMode.Builder().Build();
            FakeGameModeSelectionAction nextAction = new FakeGameModeSelectionAction.Builder().Act(fakeGameMode).Build();
            HumanVsComputerGameModeSelectionAction subject = new HumanVsComputerGameModeSelectionAction(nextAction);

            //Act
            subject.Act("not 1");

            //Assert
            nextAction.AssertActInvoked();
        }
    }
}