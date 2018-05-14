using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;
using tictactoe.Library.Ints;
using tictactoe.Players.Moves.Computer;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Players.Moves.Computer
{
    [TestClass]
    public class RandomSpaceSelectMoveActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void Act_ShouldSelectRandomSpace()
        {
            //Arrange
            Int expectedMax = new IntOf(57);
            FakeCell fakeCell = new FakeCell.Builder().Build();
            FakeCellCollection fakeCellCollection = new FakeCellCollection.Builder()
                .Count(expectedMax)
                .At(fakeCell)
                .Build();
            FakeBoard fakeBoard = new FakeBoard.Builder()
                .AvailableSpaces(fakeCellCollection)
                .Build();
            RandomSpaceSelectMoveAction subject = new RandomSpaceSelectMoveAction();

            //Act
            ICell actual = subject.Act(fakeBoard, null, null);

            //Assert
            actual.Should().BeOfType<RandomCell>();
        }
    }
}