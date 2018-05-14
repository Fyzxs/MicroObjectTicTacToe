using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Boards;
using tictactoe.Cells;
using tictactoe.EndGame;
using tictactoe.Players;
using tictactoe.Players.Moves.Computer.Hard;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Players.Moves.Computer.Hard
{
    [TestClass]
    public class HardComputerSelectMoveActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldSelectCenter()
        {
            //Arrange
            CellCollection cellCollection = new CellCollection();
            ComputerPlayer playerOne = new ComputerPlayer(new Glyph('@'), new HardComputerSelectMoveAction());
            ComputerPlayer playerTwo = new ComputerPlayer(new Glyph('&'), new HardComputerSelectMoveAction());
            Board board = new Board(cellCollection, new GameState(cellCollection), new FakePrinter.Builder().Print().Build());
            HardComputerSelectMoveAction subject = new HardComputerSelectMoveAction();

            board.ClaimEndsGame(BoardPosition.TopRight, playerOne);

            //Act
            ICell cell = subject.Act(board, playerTwo, playerOne);

            //Assert
            cell.Value().Should().Be(BoardPosition.MiddleCenter.Value());
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldSelectBlock()
        {
            //Arrange
            CellCollection cellCollection = new CellCollection();
            ComputerPlayer playerOne = new ComputerPlayer(new Glyph('@'), new HardComputerSelectMoveAction());
            ComputerPlayer playerTwo = new ComputerPlayer(new Glyph('&'), new HardComputerSelectMoveAction());
            Board board = new Board(cellCollection, new GameState(cellCollection), new FakePrinter.Builder().Print().Build());
            HardComputerSelectMoveAction subject = new HardComputerSelectMoveAction();

            board.ClaimEndsGame(BoardPosition.TopRight, playerTwo);
            board.ClaimEndsGame(BoardPosition.TopLeft, playerTwo);
            board.ClaimEndsGame(BoardPosition.MiddleCenter, playerOne);

            //Act
            ICell cell = subject.Act(board, playerOne, playerTwo);

            //Assert
            cell.Value().Should().Be(BoardPosition.TopCenter.Value());
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldSelectWin()
        {
            //Arrange
            CellCollection cellCollection = new CellCollection();
            ComputerPlayer playerOne = new ComputerPlayer(new Glyph('@'), new HardComputerSelectMoveAction());
            ComputerPlayer playerTwo = new ComputerPlayer(new Glyph('&'), new HardComputerSelectMoveAction());
            Board board = new Board(cellCollection, new GameState(cellCollection), new FakePrinter.Builder().Print().Build());
            HardComputerSelectMoveAction subject = new HardComputerSelectMoveAction();

            board.ClaimEndsGame(BoardPosition.TopRight, playerTwo);
            board.ClaimEndsGame(BoardPosition.TopLeft, playerTwo);
            board.ClaimEndsGame(BoardPosition.MiddleRight, playerTwo);
            board.ClaimEndsGame(BoardPosition.BottomLeft, playerOne);
            board.ClaimEndsGame(BoardPosition.BottomRight, playerOne);

            //Act
            ICell cell = subject.Act(board, playerOne, playerTwo);

            //Assert
            cell.Value().Should().Be(BoardPosition.BottomCenter.Value());
        }

    }
}