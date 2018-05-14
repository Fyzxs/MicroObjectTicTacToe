using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Players.Difficulity;
using tictactoe.Players.Moves;
using tictactoe.Players.Moves.Computer.Hard;

namespace TicTacToeTests.Players.Difficulty
{
    [TestClass]
    public class HardDifficultySelectionActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnCorrectModeGivenInput()
        {
            //Arrange
            HardDifficultySelectionAction subject = new HardDifficultySelectionAction();

            //Act
            ISelectMoveAction selectMoveAction = subject.Act("2");

            //Assert
            selectMoveAction.Should().BeOfType<HardComputerSelectMoveAction>();
        }
    }
}