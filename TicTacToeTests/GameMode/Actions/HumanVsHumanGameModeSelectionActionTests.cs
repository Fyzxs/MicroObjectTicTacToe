using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.GameMode;
using tictactoe.GameMode.Actions;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.GameMode.Actions {
    [TestClass]
    public class HumanVsHumanGameModeSelectionActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnHumanVsHumanGameMode()
        {
            //Arrange
            FakeGameModeSelectionAction nextAction = new FakeGameModeSelectionAction.Builder().Build();
            HumanVsHumanGameModeSelectionAction subject = new HumanVsHumanGameModeSelectionAction(nextAction);

            //Act
            IGameMode gameMode = subject.Act("2");

            //Assert
            gameMode.Should().BeOfType<HumanVsHumanGameMode>();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldInvokeAct()
        {
            //Arrange
            FakeGameMode fakeGameMode = new FakeGameMode.Builder().Build();
            FakeGameModeSelectionAction nextAction = new FakeGameModeSelectionAction.Builder().Act(fakeGameMode).Build();
            HumanVsHumanGameModeSelectionAction subject = new HumanVsHumanGameModeSelectionAction(nextAction);

            //Act
            subject.Act("not 2");

            //Assert
            nextAction.AssertActInvoked();
        }
    }
}