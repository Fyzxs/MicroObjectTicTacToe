using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Players;
using tictactoe.Players.Creation;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Players.Creation
{
    [TestClass]
    public class OnlyHumanCreationTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldCreateOnlyHumanPlayerFromInput()
        {
            //Arrange
            FakePlayer fakePlayer = new FakePlayer.Builder().Build();
            FakeValidResponse<IPlayer> fakeValidResponse = new FakeValidResponse<IPlayer>.Builder().Response(fakePlayer).Build();
            OnlyHumanCreation subject = new OnlyHumanCreation(fakeValidResponse);

            //Act
            IPlayer actual = subject.Player("mark");

            //Assert
            actual.Should().Be(fakePlayer);
        }
    }
}