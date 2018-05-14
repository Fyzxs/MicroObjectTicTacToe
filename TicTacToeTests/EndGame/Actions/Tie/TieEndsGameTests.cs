using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.EndGame.Actions.Tie;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes;
using TicTacToeTests.Validators;

namespace TicTacToeTests.EndGame.Actions.Tie
{
    [TestClass]
    public class TieEndsGameTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnTieStatus()
        {
            //Arrange
            Bool expected = Bool.True;
            FakeGameState fakeGameState = new FakeGameState.Builder().IsTie(expected).Build();
            FakeBoard fakeBoard = new FakeBoard.Builder().GameState(fakeGameState).Build();
            TieEndsGame subject = new TieEndsGame(fakeBoard);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldValidateDependencyConstructors()
        {
            new ClassVariableTypeValidation()
                .Add<TieEndsGameAction>("_command")
                .AssertExpectedVariables(new TieEndsGame(null));
        }
    }
}
