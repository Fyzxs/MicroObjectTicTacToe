using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.GameMode.TurnOrder;

namespace TicTacToeTests.GameMode.TurnOrder
{
    [TestClass]
    public class ComputerFirstPlayerTurnTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnComputerFirstOrder()
        {
            //Arrange
            ComputerFirstPlayerTurn subject = new ComputerFirstPlayerTurn();

            //Act
            IPlayerOrder actual = subject.Response("");

            //Assert
            actual.Should().BeOfType<ComputerFirstOrder>();
        }
    }
}