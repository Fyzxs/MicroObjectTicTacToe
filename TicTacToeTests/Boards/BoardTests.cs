using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Boards;
using tictactoe.Cells;
using tictactoe.EndGame;
using tictactoe.Library.Bools;
using tictactoe.Library.Ints;
using TicTacToeTests.Fakes;
using TicTacToeTests.Validators;

namespace TicTacToeTests.Boards
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod, TestCategory("unit")]
        public void Clone_ShouldReturnBoard()
        {
            //Arrange
            FakeCellCollection fakeCellCollectionClone = new FakeCellCollection.Builder().Build();
            FakeCellCollection fakeCellCollection = new FakeCellCollection.Builder()
                .Clone(fakeCellCollectionClone)
                .Build();
            Board subject = new Board(fakeCellCollection, null, null);

            //Act
            IBoard actual = subject.Clone();

            //Assert
            actual.Should().BeOfType<Board>();
        }

        [TestMethod, TestCategory("integration")]
        public void Available_ShouldIdentifyCellAsAvailable()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().IsSelected(Bool.False).Value("1").Build();
            CellCollection cellCollection = new CellCollection(new ICell[] { fakeCell });
            Board subject = new Board(cellCollection, null, null);

            //Act
            Bool actual = subject.Available(fakeCell);

            //Assert
            ((bool)actual).Should().BeTrue();
        }

        [TestMethod, TestCategory("integration")]
        public void Available_ShouldIdentifyCellAsNotAvailable()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().IsSelected(Bool.True).Value("1").Build();
            CellCollection cellCollection = new CellCollection(new ICell[] { fakeCell });
            Board subject = new Board(cellCollection, null, null);

            //Act
            Bool actual = subject.Available(fakeCell);

            //Assert
            ((bool)actual).Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void AvailableSpaces_ShouldHaveOnlyAvailableCells()
        {
            //Arrange
            FakePrinter fakePrinter = new FakePrinter.Builder().Build();
            FakeGameState fakeGameState = new FakeGameState.Builder().Build();
            FakeCell fakeCell = new FakeCell.Builder().IsSelected(Bool.False).Build();
            FakeCell fakeCellSelected = new FakeCell.Builder().IsSelected(Bool.True).Build();
            Board subject = new Board(new CellCollection(new ICell[] { fakeCell, fakeCellSelected }),
                fakeGameState, fakePrinter);

            //Act
            ICellCollection actual = subject.AvailableSpaces();

            //Assert
            ((int)actual.Count()).Should().Be(1);
        }

        [TestMethod, TestCategory("unit")]
        public void ClaimEndsGame_ReturnTrueWhenOver()
        {
            //Arrange
            FakePrinter fakePrinter = new FakePrinter.Builder().Build();
            FakeCell fakeCell = new FakeCell.Builder().Build();
            FakeCellCollection fakeCellCollection = new FakeCellCollection.Builder()
                .UpdateTo()
                .Build();
            FakeGameState fakeGameState = new FakeGameState.Builder().IsGameOver(Bool.True).Build();
            FakePlayer fakePlayer = new FakePlayer.Builder().Cell(fakeCell).Build();
            Board subject = new Board(fakeCellCollection, fakeGameState, fakePrinter);

            //Act
            Bool actual = subject.ClaimEndsGame(null, fakePlayer);

            //Assert
            ((bool)actual).Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void ClaimEndsGame_ReturnFalseWhenNotOver()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().Build();
            FakeCellCollection fakeCellCollection = new FakeCellCollection.Builder()
                .UpdateTo()
                .Build();
            FakePrinter fakePrinter = new FakePrinter.Builder().Print().Build();
            FakeGameState fakeGameState = new FakeGameState.Builder().IsGameOver(Bool.False).Build();
            FakePlayer fakePlayer = new FakePlayer.Builder().Cell(fakeCell).Build();
            Board subject = new Board(fakeCellCollection, fakeGameState, fakePrinter);

            //Act
            Bool actual = subject.ClaimEndsGame(null, fakePlayer);

            //Assert
            ((bool)actual).Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void ClaimEndsGame_ShouldClaimCellForPlayer()
        {
            //Arrange
            FakePrinter fakePrinter = new FakePrinter.Builder().Build();
            FakeCell fakeCellBoard = new FakeCell.Builder().IsSelected(Bool.False).Value("1").Build();
            FakeCell fakeCellSelected = new FakeCell.Builder().IsSelected(Bool.False).Value("1").Build();
            FakeCell fakeCellPlayer = new FakeCell.Builder().AsSelected(fakeCellSelected).Value("1").Build();
            ICellCollection cellCollection = new CellCollection(new ICell[] { fakeCellBoard });
            FakeGameState fakeGameState = new FakeGameState.Builder().IsGameOver(Bool.False).Build();
            FakePlayer fakePlayer = new FakePlayer.Builder().Cell(fakeCellPlayer).Build();
            Board subject = new Board(cellCollection, fakeGameState, fakePrinter);

            //Act
            subject.ClaimEndsGame(fakeCellBoard, fakePlayer);

            //Assert
            cellCollection.At(new IntOf(0)).Should().NotBe(fakeCellBoard);
        }

        [TestMethod, TestCategory("unit")]
        public void Print_ShouldPrint()
        {
            //Arrange
            FakePrinter fakePrinter = new FakePrinter.Builder().Print().Build();
            Board subject = new Board(null, null, fakePrinter);

            //Act
            subject.Print();

            //Assert
            fakePrinter.AssertPrintInvoked();
        }

        [TestMethod, TestCategory("unit")]
        public void GameState_ShouldReturnGameState()
        {
            //Arrange FakePrinter fakePrinter = new FakePrinter.Builder().Build();
            ICellCollection cellCollection = new CellCollection();
            Board subject = new Board(cellCollection, null, null);

            //Act
            IGameState gameState = subject.GameState();

            //Assert
            ((bool)gameState.IsGameOver()).Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldValidateDependencyConstructors()
        {
            new ClassVariableTypeValidation()
                .Add<GameState>("_gameState")
                .Add<BoardPrinter>("_printer")
                .Add<CellCollection>("_cellCollection")
                .AssertExpectedVariables(new Board());
        }
    }
}
