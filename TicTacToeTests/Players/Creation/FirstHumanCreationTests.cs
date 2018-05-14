using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Players;
using tictactoe.Players.Creation;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Players.Creation
{
    [TestClass]
    public class FirstHumanCreationTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldCreateFirstHumanPlayerFromInput()
        {
            //Arrange
            FakePlayer fakePlayer = new FakePlayer.Builder().Build();
            FakeValidResponse<IPlayer> fakeValidResponse = new FakeValidResponse<IPlayer>.Builder().Response(fakePlayer).Build();
            FirstHumanCreation subject = new FirstHumanCreation(fakeValidResponse);

            //Act
            IPlayer actual = subject.Player("mark");

            //Assert
            actual.Should().Be(fakePlayer);
        }
    }
}