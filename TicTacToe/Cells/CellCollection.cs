using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using tictactoe.Boards;
using tictactoe.Cells.Bools;
using tictactoe.Library.Bools;
using tictactoe.Library.Ints;

namespace tictactoe.Cells
{
    public sealed class CellCollection : ICellCollection
    {
        private readonly ICell[] _cells;

        public CellCollection() : this(new[]
        {
            BoardPosition.TopLeft,
            BoardPosition.TopCenter,
            BoardPosition.TopRight,
            BoardPosition.MiddleLeft,
            BoardPosition.MiddleCenter,
            BoardPosition.MiddleRight,
            BoardPosition.BottomLeft,
            BoardPosition.BottomCenter,
            BoardPosition.BottomRight
        })
        { }

        public CellCollection(ICell[] cells) => _cells = cells;

        public ICellCollection Clone() => new CellCollection(_cells.Select(c => c).ToArray());

        public void UpdateTo(ICell current, ICell update)
        {
            for (int boardIndex = 0; boardIndex < _cells.Length; boardIndex++)
            {
                if (NotCurrentCell(current, boardIndex)) continue;

                _cells[boardIndex] = update.AsSelected();
                break;
            }
        }

        public Bool WhereAny(Func<ICell, bool> predicate) => new WhereAnyCell(_cells, predicate);

        public ICell At(Int index) => _cells[index];

        public Int Count() => new ArrayLength(_cells);

        public IEnumerator<ICell> GetEnumerator() => ((IEnumerable<ICell>)_cells).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private Bool NotCurrentCell(ICell current, int boardIndex) => new CellEquality(_cells[boardIndex], current).Not();
    }

    public interface ICellCollection : IEnumerable<ICell>
    {
        ICellCollection Clone();
        Bool WhereAny(Func<ICell, bool> predicate);
        ICell At(Int index); //NOTE: I don't like indexing. I dislike more using an iterator where this is used.
        Int Count();
        void UpdateTo(ICell current, ICell update);
    }
}