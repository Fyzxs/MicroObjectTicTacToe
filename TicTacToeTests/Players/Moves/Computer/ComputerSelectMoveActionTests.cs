using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Players.Moves.Computer.Medium;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Players.Moves.Computer
{
    [TestClass]
    public class ComputerSelectMoveActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void Act_ShouldInvokeAct()
        {
            //Arrange
            FakeSelectMoveAction fakeSelectMoveAction = new FakeSelectMoveAction.Builder().Act(null).Build();
            MediumComputerSelectMoveAction subject = new MediumComputerSelectMoveAction(fakeSelectMoveAction);

            //Act
            subject.Act(null, null, null);

            //Assert
            fakeSelectMoveAction.AssertActInvoked();
        }
    }
}