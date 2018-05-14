using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Boards;
using tictactoe.Cells;
using tictactoe.Library.Bools;
using tictactoe.Players;
using tictactoe.Players.Moves.Computer;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Players.Moves.Computer
{
    [TestClass]
    public class CenterSquareSelectMoveActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void Act_ShouldReturnExpectedCellWhenCenterAvailable()
        {
            //Arrange
            FakeCell expectedCell = new FakeCell.Builder().Value("4").Build();
            FakeSelectMoveAction fakeSelectMoveAction = new FakeSelectMoveAction.Builder().Build();
            FakeBoard fakeBoard = new FakeBoard.Builder().Available(Bool.True).Build();
            CenterSquareSelectMoveAction subject = new CenterSquareSelectMoveAction(fakeSelectMoveAction);

            //Act
            ICell cell = subject.Act(fakeBoard, null, null);

            //Assert
            cell.Value().Should().Be(expectedCell.Value());
        }
        [TestMethod, TestCategory("unit")]
        public void Act_ShouldCallActWhenCenterNotAvailable()
        {
            //Arrange
            FakeCell expectedCell = new FakeCell.Builder().Build();
            FakeSelectMoveAction fakeSelectMoveAction = new FakeSelectMoveAction.Builder().Act(expectedCell).Build();
            FakeBoard fakeBoard = new FakeBoard.Builder().Available(Bool.False).Build();
            FakePlayer fakePlayerA = new FakePlayer.Builder().Build();
            FakePlayer fakePlayerB = new FakePlayer.Builder().Build();
            CenterSquareSelectMoveAction subject = new CenterSquareSelectMoveAction(fakeSelectMoveAction);

            //Act
            subject.Act(fakeBoard, fakePlayerA, fakePlayerB);

            //Assert
            fakeSelectMoveAction.AssertActInvokedWith(new Tuple<IBoard, IPlayer, IPlayer>(fakeBoard, fakePlayerA, fakePlayerB));
        }
    }
}