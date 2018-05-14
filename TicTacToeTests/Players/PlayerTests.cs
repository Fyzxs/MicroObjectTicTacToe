using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;
using tictactoe.IO;
using tictactoe.Library.Bools;
using tictactoe.Players;
using tictactoe.Players.Moves;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Players
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod, TestCategory("unit")]
        public void Cell_ShouldCreateCellForSymbol()
        {
            //Arrange
            TestPlayer subject = new TestPlayer();

            //Act
            ICell actual = subject.Cell();

            //Assert
            actual.Value().Should().Be("?");
        }

        [TestMethod, TestCategory("unit")]
        public void TakeActionEnds_ShouldIndicateGameEnds()
        {
            //Arrange
            FakeBoard fakeBoard = new FakeBoard.Builder()
                .ClaimEndsGame(Bool.True)
                .Build();
            FakeCell fakeCell = new FakeCell.Builder().Build();
            FakeSelectMoveAction fakeSelectMoveAction = new FakeSelectMoveAction.Builder().Act(fakeCell).Build();
            TestPlayer subject = new TestPlayer(fakeSelectMoveAction);

            //Act
            subject.TakeAction(fakeBoard, null);

            //Assert
            fakeBoard.AssertClaimEndsGameInvoked();
        }

        [TestMethod, TestCategory("unit")]
        public void WinPrinter_ShouldReturnPrinter()
        {
            //Arrange
            TestPlayer subject = new TestPlayer();

            //Act
            IPrinter actual = subject.WinPrinter();

            //Assert
            actual.Should().NotBeNull();
        }

        public class TestPlayer : Player
        {
            public TestPlayer(ISelectMoveAction selectMove = null) : base(new Glyph('?'), selectMove) { }
        }
    }
}
