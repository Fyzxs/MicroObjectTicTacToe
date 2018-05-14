using System.Linq;
using tictactoe.Cells;
using tictactoe.Cells.Bools;
using tictactoe.EndGame;
using tictactoe.IO;
using tictactoe.Library.Bools;
using tictactoe.Players;

namespace tictactoe.Boards
{
    public sealed class Board : IBoard
    {
        private readonly ICellCollection _cellCollection;
        private readonly IGameState _gameState;
        private readonly IPrinter _printer;

        public Board() : this(new CellCollection()) { }

        private Board(ICellCollection cellCollection) : this(
            cellCollection,
            new GameState(cellCollection),
            new BoardPrinter(cellCollection))
        { }

        public Board(ICellCollection cellCollection,
            IGameState gameState,
            IPrinter printer)
        {
            _cellCollection = cellCollection;
            _gameState = gameState;
            _printer = printer;
        }

        public IBoard Clone() => new Board(_cellCollection.Clone());

        public void Print() => _printer.Print();

        public Bool ClaimEndsGame(ICell boardCell, IPlayer player)
        {
            Claim(boardCell, player);
            return _gameState.IsGameOver();
        }

        public IGameState GameState() => new GameState(_cellCollection);

        public Bool Available(ICell cell) => _cellCollection.WhereAny(source => new MatchedCellAvailable(source, cell));

        public ICellCollection AvailableSpaces() => new CellCollection(_cellCollection.Where(cell => cell.IsSelected().Not()).ToArray());

        private void Claim(ICell boardCell, IPlayer player) => _cellCollection.UpdateTo(boardCell, player.Cell());
    }

    public interface IBoard
    {
        IBoard Clone();
        void Print();
        Bool Available(ICell cell);
        ICellCollection AvailableSpaces();
        Bool ClaimEndsGame(ICell cell, IPlayer player);
        IGameState GameState();
    }
}