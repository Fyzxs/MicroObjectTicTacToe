using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.GameMode;
using tictactoe.GameMode.TurnOrder;
using tictactoe.Players;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.GameMode
{
    [TestClass]
    public class HumanVsComputerGameModeTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnPlayersTurnsComputerAsO()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().Value("?").Build();
            FakePlayer fakePlayer = new FakePlayer.Builder().Cell(fakeCell).Build();
            FakePlayer fakePlayerComputer = new FakePlayer.Builder().Build();
            FakeValidResponse<IPlayerOrder> fakeValidResponse = new FakeValidResponse<IPlayerOrder>.Builder().Response(new HumanFirstOrder()).Build();
            FakePlayerCreation fakePlayerCreation = new FakePlayerCreation.Builder().Player(fakePlayer, fakePlayerComputer).Build();
            FakeBoard fakeBoard = new FakeBoard.Builder().Build();
            HumanVsComputerGameMode subject = new HumanVsComputerGameMode(fakeValidResponse, fakePlayerCreation, fakePlayerCreation);

            //Act
            IPlayersTurns actual = subject.ConfigurePlayers(fakeBoard);

            //Assert
            actual.Should().BeOfType<PlayersTurns>();
            fakePlayerCreation.PlayerInvokedWith("");
            fakePlayerCreation.PlayerInvokedWith("O");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldReturnPlayersTurnsComputerAsX()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().Value("O").Build();
            FakePlayer fakePlayer = new FakePlayer.Builder().Cell(fakeCell).Build();
            FakePlayer fakePlayerComputer = new FakePlayer.Builder().Build();
            FakeValidResponse<IPlayerOrder> fakeValidResponse = new FakeValidResponse<IPlayerOrder>.Builder().Response(new HumanFirstOrder()).Build();
            FakePlayerCreation fakePlayerCreation = new FakePlayerCreation.Builder().Player(fakePlayer, fakePlayerComputer).Build();
            FakeBoard fakeBoard = new FakeBoard.Builder().Build();
            HumanVsComputerGameMode subject = new HumanVsComputerGameMode(fakeValidResponse, fakePlayerCreation, fakePlayerCreation);

            //Act
            IPlayersTurns actual = subject.ConfigurePlayers(fakeBoard);

            //Assert
            actual.Should().BeOfType<PlayersTurns>();
            fakePlayerCreation.PlayerInvokedWith("");
            fakePlayerCreation.PlayerInvokedWith("X");
        }
    }
}