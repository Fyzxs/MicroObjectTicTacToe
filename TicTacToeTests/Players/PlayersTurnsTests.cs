using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Boards;
using tictactoe.EndGame.Actions.Tie;
using tictactoe.Library.Bools;
using tictactoe.Players;
using TicTacToeTests.Validators;

namespace TicTacToeTests.Players
{
    [TestClass]
    public class PlayersTurnsTests
    {
        [TestMethod, TestCategory("unit")]
        public void GameOver_ShouldReturnFalseGivenGameNotOver()
        {

            PlayersTurns subject = new PlayersTurns(Bool.False, Bool.False, Bool.False);

            //Act
            Bool actual = subject.GameOver();

            //Assert
            ((bool)actual).Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void GameOver_ShouldReturnTrueGivenCatsGame()
        {
            //Arrange
            PlayersTurns subject = new PlayersTurns(Bool.False, Bool.False, Bool.True);

            //Act
            Bool actual = subject.GameOver();

            //Assert
            ((bool)actual).Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void GameOver_ShouldReturnTrueGivenPlayerTwoWins()
        {
            PlayersTurns subject = new PlayersTurns(Bool.False, Bool.True, Bool.False);

            //Act
            Bool actual = subject.GameOver();

            //Assert
            ((bool)actual).Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void GameOver_ShouldReturnTrueGivenPlayerOneWins()
        {
            PlayersTurns subject = new PlayersTurns(Bool.True, Bool.False, Bool.False);

            //Act
            Bool actual = subject.GameOver();

            //Assert
            ((bool)actual).Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldValidateDependencyConstructors()
        {
            new ClassVariableTypeValidation()
                .Add<PlayerTurnEndsGame>("_pOneEndsGame")
                .Add<PlayerTurnEndsGame>("_pTwoEndsGame")
                .Add<TieEndsGame>("_tieEndsGame")
                .AssertExpectedVariables(new PlayersTurns((IBoard)null, null, null));
        }

    }
}
