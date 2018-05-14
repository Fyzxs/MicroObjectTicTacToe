using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;
using tictactoe.Library.Bools;
using tictactoe.Library.Ints;
using tictactoe.Players.Moves.Computer;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Players.Moves.Computer
{
    [TestClass]
    public class CurrentPlayerWinningSelectMoveActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void Act_ShouldSelectThisPlayer()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().Build();
            FakeEnumerator<ICell> fakeEnumerator = new FakeEnumerator<ICell>.Builder()
                .MoveNext(true)
                .Current(fakeCell)
                .Build();
            FakeCellCollection fakeCellCollection = new FakeCellCollection.Builder()
                .Count(new IntOf(1))
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
            CurrentPlayerWinningSelectMoveAction subject = new CurrentPlayerWinningSelectMoveAction(fakeSelectMoveAction);

            //Act
            subject.Act(fakeBoard, fakePlayer, null);

            //Assert
            fakeBoardClone.AssertClaimEndsGameInvokedWith(fakeCell, fakePlayer);

        }
    }
}