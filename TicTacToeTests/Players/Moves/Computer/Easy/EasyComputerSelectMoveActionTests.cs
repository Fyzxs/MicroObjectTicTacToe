using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Players.Moves.Computer;
using tictactoe.Players.Moves.Computer.Easy;
using TicTacToeTests.Fakes;
using TicTacToeTests.Validators;

namespace TicTacToeTests.Players.Moves.Computer.Easy
{
    [TestClass]
    public class EasyComputerSelectMoveActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldInvokeAct()
        {
            //Arrange
            FakeSelectMoveAction nextAction = new FakeSelectMoveAction.Builder().Act(null).Build();
            EasyComputerSelectMoveAction subject = new EasyComputerSelectMoveAction(nextAction);

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
                .Add<CurrentPlayerWinningSelectMoveAction>()
                .Add<RandomSpaceSelectMoveAction>();

            //Act
            EasyComputerSelectMoveAction subject = new EasyComputerSelectMoveAction();

            //Assert
            chainValidation.AssertExpectedChain(subject);
        }
    }
}