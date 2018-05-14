using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Players;
using tictactoe.Players.Creation;
using tictactoe.Players.Moves;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Players.Creation
{
    [TestClass]
    public class ComputerCreationTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldCreateComputerPlayerFromInput()
        {
            //Arrange
            FakeSelectMoveAction fakeSelectMoveAction = new FakeSelectMoveAction.Builder().Build();
            FakeValidResponse<ISelectMoveAction> fakeValidResponse = new FakeValidResponse<ISelectMoveAction>.Builder().Response(fakeSelectMoveAction).Build();
            FakeFormattedValidInput<ISelectMoveAction> fakeFormattedValidInput = new FakeFormattedValidInput<ISelectMoveAction>.Builder()
                .AddPromptArg()
                .ValidInput(fakeValidResponse)
                .Build();
            ComputerCreation subject = new ComputerCreation(fakeFormattedValidInput);

            //Act
            IPlayer actual = subject.Player("mark");

            //Assert
            actual.Cell().Value().Should().Be("m");
            actual.Should().BeOfType<ComputerPlayer>();
            fakeFormattedValidInput.AssertAddPromptArgInvokedWith("mark");
            fakeValidResponse.AssertInputInvoked();
        }
    }
}