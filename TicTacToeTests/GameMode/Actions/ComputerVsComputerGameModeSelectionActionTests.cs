using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.GameMode;
using tictactoe.GameMode.Actions;

namespace TicTacToeTests.GameMode.Actions
{
    [TestClass]
    public class ComputerVsComputerGameModeSelectionActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnComputerVsComputerGameMode()
        {
            //Arrange
            ComputerVsComputerGameModeSelectionAction subject = new ComputerVsComputerGameModeSelectionAction();

            //Act
            IGameMode gameMode = subject.Act(null);

            //Assert
            gameMode.Should().BeOfType<ComputerVsComputerGameMode>();
        }
    }
}
