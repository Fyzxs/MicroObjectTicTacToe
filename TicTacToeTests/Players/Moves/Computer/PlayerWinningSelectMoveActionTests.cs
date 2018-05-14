using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;
using tictactoe.Library.Bools;
using tictactoe.Players;
using tictactoe.Players.Moves;
using tictactoe.Players.Moves.Computer;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Players.Moves.Computer
{
    [TestClass]
    public class PlayerWinningSelectMoveActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void Act_ShouldInvokeActWhenNoSpacesAvailable()
        {
            //Arrange
            FakeEnumerator<ICell> fakeEnumerator = new FakeEnumerator<ICell>.Builder()
                .MoveNext(false)
                .Build();
            FakeCellCollection fakeCellCollection = new FakeCellCollection.Builder()
                .GetEnumerator(fakeEnumerator)
                .Build();
            FakeBoard fakeBoard = new FakeBoard.Builder().AvailableSpaces(fakeCellCollection).Build();
            FakeSelectMoveAction fakeSelectMoveAction = new FakeSelectMoveAction.Builder().Act(null).Build();
            PlayerWinningSelectMoveAction subject = new AbstractWrapper(fakeSelectMoveAction);

            //Act
            subject.Act(fakeBoard, null, null);

            //Assert
            fakeSelectMoveAction.AssertActInvoked();
        }


        [TestMethod, TestCategory("unit")]
        public void Act_ShouldAttemptToClaimEachCellForWin()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().Build();
            FakeEnumerator<ICell> fakeEnumerator = new FakeEnumerator<ICell>.Builder()
                .MoveNext(true, true, true, true, true, false)
                .Current(fakeCell)
                .Build();
            FakeCellCollection fakeCellCollection = new FakeCellCollection.Builder()
                .GetEnumerator(fakeEnumerator)
                .Build();
            FakeBoard fakeBoardClone = new FakeBoard.Builder()
                .ClaimEndsGame(Bool.False)
                .Build();
            FakeBoard fakeBoard = new FakeBoard.Builder()
                .AvailableSpaces(fakeCellCollection)
                .Clone(fakeBoardClone)
                .Build();
            FakeSelectMoveAction fakeSelectMoveAction = new FakeSelectMoveAction.Builder().Act(null).Build();
            PlayerWinningSelectMoveAction subject = new AbstractWrapper(fakeSelectMoveAction);

            //Act
            subject.Act(fakeBoard, null, null);

            //Assert
            fakeSelectMoveAction.AssertActInvoked();
            fakeBoard.CloneInvokedCount(5);
            fakeBoardClone.AssertClaimEndsGameInvokedCount(5);
        }



        private class AbstractWrapper : PlayerWinningSelectMoveAction
        {
            public AbstractWrapper(ISelectMoveAction nextAction) : base(nextAction) { }
            protected override IPlayer Player(IPlayer thisPlayer, IPlayer otherPlayer) => thisPlayer;
        }
    }
}