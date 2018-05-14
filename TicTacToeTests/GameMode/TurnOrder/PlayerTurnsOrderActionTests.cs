using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.GameMode.TurnOrder;
using TicTacToeTests.Fakes;
using TicTacToeTests.Validators;

namespace TicTacToeTests.GameMode.TurnOrder
{
    [TestClass]
    public class PlayerTurnsOrderActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnTieStatus()
        {
            //Arrange
            FakePlayerTurnsOrderAction fakePlayerTurnsOrderAction = new FakePlayerTurnsOrderAction.Builder().Response(null).Build();
            PlayerTurnsOrderAction subject = new PlayerTurnsOrderAction(fakePlayerTurnsOrderAction);

            //Act
            subject.Response("");

            //Assert
            fakePlayerTurnsOrderAction.AssertResponseInvoked();
        }

        [TestMethod, TestCategory("functional")]
        public void ShouldHaveExpectedOrder()
        {
            //Arrange
            ChainValidation chainValidation = new ChainValidation()
                .Add<HumanFirstPlayerTurn>()
                .Add<ComputerFirstPlayerTurn>();

            //Act
            PlayerTurnsOrderAction subject = new PlayerTurnsOrderAction();

            //Assert
            chainValidation.AssertExpectedChain(subject);
        }
    }
}