using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Players;
using tictactoe.Players.Creation;

namespace TicTacToeTests.Players.Creation
{
    [TestClass]
    public class HumanPlayerValidInputResponseActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnHuman()
        {
            //Arrange
            HumanPlayerValidInputResponseAction subject = new HumanPlayerValidInputResponseAction();

            //Act
            IPlayer actual = subject.Response("A");

            //Assert
            actual.Should().BeOfType<HumanPlayer>();
        }
    }
}