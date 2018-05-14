using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.EndGame.Actions.Player;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes;
using TicTacToeTests.Validators;

namespace TicTacToeTests.EndGame.Actions.Player
{
    [TestClass]
    public class PlayerEndsGameActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldInvokedNextAction()
        {
            //Arrange
            FakePlayerEndsGameAction nextAction = new FakePlayerEndsGameAction.Builder().Act(Bool.True).Build();
            PlayerEndsGameAction subject = new PlayerEndsGameAction(nextAction);

            //Act
            subject.Act(null, null, null);

            //Assert
            nextAction.AssertActInvoked();
        }

        [TestMethod, TestCategory("functional")]
        public void ShouldHaveExpectedOrder()
        {
            //Arrange
            ChainValidation chainValidation = new ChainValidation()
                .Add<GameOverGuardPlayerEndsGameAction>()
                .Add<TakeTurnPlayerEndsGameAction>()
                .Add<PrintBoardPlayerEndsGameAction>()
                .Add<NoWinGuardPlayerEndsGameAction>()
                .Add<PrintWinPlayerEndsGameAction>()
                .Add<DefaultPlayerEndsGameAction>();

            //Act
            PlayerEndsGameAction subject = new PlayerEndsGameAction();

            //Assert
            chainValidation.AssertExpectedChain(subject);
        }
    }
}
