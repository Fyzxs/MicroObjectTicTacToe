using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.GameMode;
using tictactoe.Players;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.GameMode
{
    [TestClass]
    public class ComputerVsComputerGameModeTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnPlayersTurns()
        {
            //Arrange
            FakePlayer fakePlayer = new FakePlayer.Builder().Build();
            FakePlayerCreation fakePlayerCreation = new FakePlayerCreation.Builder().Player(fakePlayer).Build();
            FakeBoard fakeBoard = new FakeBoard.Builder().Build();
            ComputerVsComputerGameMode subject = new ComputerVsComputerGameMode(fakePlayerCreation);

            //Act
            IPlayersTurns actual = subject.ConfigurePlayers(fakeBoard);

            //Assert
            actual.Should().BeOfType<PlayersTurns>();
            fakePlayerCreation.PlayerInvokedWith("O");
            fakePlayerCreation.PlayerInvokedWith("X");
        }
    }
}
