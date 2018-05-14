using System.Collections.Generic;
using System.Diagnostics;
using tictactoe.Library.Bools;
using tictactoe.Library.Random;

namespace tictactoe.Cells
{
    [DebuggerDisplay("RandomCell=[{_origin.Value()}]")]
    public sealed class RandomCell : ICell
    {
        private readonly ISingleReservoirSample<ICell> _singleReservoirSample;
        private ICell _origin;

        public RandomCell(IEnumerable<ICell> cells) : this(new SingleReservoirSample<ICell>(cells, NullCell.Instance)) { }

        public RandomCell(ISingleReservoirSample<ICell> singleReservoirSample) => _singleReservoirSample = singleReservoirSample;

        public string Value() => Cached().Value();

        public Bool IsSelected() => Cached().IsSelected();

        public ICell AsSelected() => Cached().AsSelected();

        //Note: This is the only place caching happens. If it happens in more places; create a Cache<T> : ICache<T>
        private ICell Cached() => _origin ?? (_origin = _singleReservoirSample.Element());
    }
}