using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.GameMode;
using tictactoe.Players;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.GameMode {
    [TestClass]
    public class HumanVsHumanGameModeTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnPlayersTurns()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().Value("?").Build();
            FakePlayer fakePlayer = new FakePlayer.Builder().Cell(fakeCell).Build();
            FakePlayer fakePlayer2 = new FakePlayer.Builder().Build();
            FakePlayerCreation fakePlayerCreation = new FakePlayerCreation.Builder().Player(fakePlayer, fakePlayer2).Build();
            FakeBoard fakeBoard = new FakeBoard.Builder().Build();
            HumanVsHumanGameMode subject = new HumanVsHumanGameMode(fakePlayerCreation, fakePlayerCreation);

            //Act
            IPlayersTurns actual = subject.ConfigurePlayers(fakeBoard);

            //Assert
            actual.Should().BeOfType<PlayersTurns>();
            fakePlayerCreation.PlayerInvokedWith("");
            fakePlayerCreation.PlayerInvokedWith("?");
        }
    }
}