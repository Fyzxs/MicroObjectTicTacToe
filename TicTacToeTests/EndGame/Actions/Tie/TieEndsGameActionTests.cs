using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.EndGame.Actions.Tie;
using TicTacToeTests.Validators;

namespace TicTacToeTests.EndGame.Actions.Tie {
    [TestClass]
    public class TieEndsGameActionTests
    {

        [TestMethod, TestCategory("functional")]
        public void ShouldHaveExpectedOrder()
        {
            //Arrange
            ChainValidation chainValidation = new ChainValidation()
                .Add<PrintTieEndsGameAction>()
                .Add<ReturnTieEndsGameAction>();

            //Act
            TieEndsGameAction subject = new TieEndsGameAction();

            //Assert
            chainValidation.AssertExpectedChain(subject);
        }
    }
}