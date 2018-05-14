using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.GameMode.TurnOrder;

namespace TicTacToeTests.GameMode.TurnOrder {
    [TestClass]
    public class ComputerFirstOrderTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnFalse()
        {
            //Arrange
            ComputerFirstOrder subject = new ComputerFirstOrder();

            //Act
            bool actual = subject.HumanFirst();

            //Assert
            actual.Should().BeFalse();
        }
    }
}