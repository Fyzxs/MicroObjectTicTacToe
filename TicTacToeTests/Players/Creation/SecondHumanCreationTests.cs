using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Players;
using tictactoe.Players.Creation;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Players.Creation
{
    [TestClass]
    public class SecondHumanCreationTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldCreateSecondHumanCreationFromInput()
        {
            //Arrange
            FakePlayer fakePlayer = new FakePlayer.Builder().Build();
            FakeValidResponse<IPlayer> fakeValidResponse = new FakeValidResponse<IPlayer>.Builder().Response(fakePlayer).Build();
            FakeFormattedValidInput<IPlayer> fakeFormattedValidInput = new FakeFormattedValidInput<IPlayer>.Builder()
                .AddPromptArg()
                .AddPatternArg()
                .ValidInput(fakeValidResponse)
                .Build();
            SecondHumanCreation subject = new SecondHumanCreation(fakeFormattedValidInput);

            //Act
            IPlayer actual = subject.Player("mark");

            //Assert
            actual.Should().Be(fakePlayer);
            fakeFormattedValidInput.AssertAddPromptArgInvokedWith("mark");
            fakeFormattedValidInput.AssertAddPatternArgInvokedWith("mark");
        }
    }
}