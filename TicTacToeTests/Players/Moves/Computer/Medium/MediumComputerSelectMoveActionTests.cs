using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Players.Moves.Computer;
using tictactoe.Players.Moves.Computer.Medium;
using TicTacToeTests.Fakes;
using TicTacToeTests.Validators;

namespace TicTacToeTests.Players.Moves.Computer.Medium
{
    [TestClass]
    public class MediumComputerSelectMoveActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldInvokeAct()
        {
            //Arrange
            FakeSelectMoveAction nextAction = new FakeSelectMoveAction.Builder().Act(null).Build();
            MediumComputerSelectMoveAction subject = new MediumComputerSelectMoveAction(nextAction);

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
                .Add<CenterSquareSelectMoveAction>()
                .Add<CurrentPlayerWinningSelectMoveAction>()
                .Add<OtherPlayerWinningSelectMoveAction>()
                .Add<RandomSpaceSelectMoveAction>();

            //Act
            MediumComputerSelectMoveAction subject = new MediumComputerSelectMoveAction();

            //Assert
            chainValidation.AssertExpectedChain(subject);
        }
    }
}