using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;
using tictactoe.Library.Bools;
using tictactoe.Players.Moves.Computer;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Players.Moves.Computer
{
    [TestClass]
    public class OtherPlayerSelectMoveActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void Act_ShouldSelectOtherPlayer()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().Build();
            FakeEnumerator<ICell> fakeEnumerator = new FakeEnumerator<ICell>.Builder()
                .MoveNext(true)
                .Current(fakeCell)
                .Build();
            FakeCellCollection fakeCellCollection = new FakeCellCollection.Builder()
                .GetEnumerator(fakeEnumerator)
                .Build();
            FakeBoard fakeBoardClone = new FakeBoard.Builder()
                .ClaimEndsGame(Bool.True)
                .Build();
            FakeBoard fakeBoard = new FakeBoard.Builder()
                .AvailableSpaces(fakeCellCollection)
                .Clone(fakeBoardClone)
                .Build();
            FakePlayer fakePlayer = new FakePlayer.Builder().Build();
            FakeSelectMoveAction fakeSelectMoveAction = new FakeSelectMoveAction.Builder().Act(null).Build();
            OtherPlayerWinningSelectMoveAction subject = new OtherPlayerWinningSelectMoveAction(fakeSelectMoveAction);

            //Act
            subject.Act(fakeBoard, null, fakePlayer);

            //Assert
            fakeBoardClone.AssertClaimEndsGameInvokedWith(fakeCell, fakePlayer);

        }
    }
}