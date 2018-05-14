using System;
using System.Collections.Generic;
using System.Linq;
using tictactoe.Library.Bools;

namespace tictactoe.Cells.Bools
{
    public sealed class WhereAnyCell : Bool
    {
        private readonly IEnumerable<ICell> _cells;
        private readonly Func<ICell, bool> _predicate;

        public WhereAnyCell(IEnumerable<ICell> cells, Func<ICell, bool> predicate)
        {
            _cells = cells;
            _predicate = predicate;
        }

        protected override bool RawValue() => _cells.Where(_predicate).Any();
    }
}