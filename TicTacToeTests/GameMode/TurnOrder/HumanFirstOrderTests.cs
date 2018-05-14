using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.GameMode.TurnOrder;

namespace TicTacToeTests.GameMode.TurnOrder {
    [TestClass]
    public class HumanFirstOrderTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnTrue()
        {
            //Arrange
            HumanFirstOrder subject = new HumanFirstOrder();

            //Act
            bool actual = subject.HumanFirst();

            //Assert
            actual.Should().BeTrue();
        }
    }
}