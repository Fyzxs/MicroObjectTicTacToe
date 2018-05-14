using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using tictactoe.Cells;
using tictactoe.Library.Bools;
using tictactoe.Library.Ints;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeCellCollection : ICellCollection
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<ICellCollection> _cloneItem = new BuilderFuncReturn<ICellCollection>("FakeCellCollection#Clone");
            private readonly BuilderFuncVoid<Tuple<ICell, ICell>> _updateToItem = new BuilderFuncVoid<Tuple<ICell, ICell>>("FakeCellCollection#UpdateTo");
            private readonly BuilderFuncReturn<Bool> _whereAnyItem = new BuilderFuncReturn<Bool>("FakeCellCollection#WhereAny");
            private readonly BuilderFuncReturn<ICell> _atItem = new BuilderFuncReturn<ICell>("FakeCellCollection#At");
            private readonly BuilderFuncReturn<Int> _countItem = new BuilderFuncReturn<Int>("FakeCellCollection#Count");
            private readonly BuilderFuncReturn<IEnumerator<ICell>> _getEnumeratorItem = new BuilderFuncReturn<IEnumerator<ICell>>("FakeCellCollection#GetEnumerator");

            public Builder GetEnumerator(IEnumerator<ICell> expected)
            {
                _getEnumeratorItem.UpdateInvocation(expected);
                return this;
            }

            public Builder Count(Int expected)
            {
                _countItem.UpdateInvocation(expected);
                return this;
            }

            public Builder At(params ICell[] expected)
            {
                _atItem.UpdateInvocation(expected);
                return this;
            }

            public Builder WhereAny(Bool expected)
            {
                _whereAnyItem.UpdateInvocation(expected);
                return this;
            }

            public Builder UpdateTo()
            {
                _updateToItem.UpdateInvocation();
                return this;
            }
            public Builder Clone(ICellCollection expected)
            {
                _cloneItem.UpdateInvocation(expected);
                return this;
            }
            public FakeCellCollection Build()
            {
                return new FakeCellCollection
                {
                    _clone = _cloneItem,
                    _updateTo = _updateToItem,
                    _whereAny = _whereAnyItem,
                    _at = _atItem,
                    _count = _countItem,
                    _getEnumerator = _getEnumeratorItem
                };
            }
        }

        private BuilderFuncReturn<ICellCollection> _clone;
        private BuilderFuncVoid<Tuple<ICell, ICell>> _updateTo;
        private BuilderFuncReturn<Bool> _whereAny;
        private BuilderFuncReturn<ICell> _at;
        private BuilderFuncReturn<Int> _count;
        private BuilderFuncReturn<IEnumerator<ICell>> _getEnumerator;

        private FakeCellCollection() { }

        public ICellCollection Clone() => _clone.Invoke();
        public void UpdateTo(ICell current, ICell update) => _updateTo.Invoke(new Tuple<ICell, ICell>(current, update));
        public Bool WhereAny(Func<ICell, bool> predicate) => _whereAny.Invoke();
        public ICell At(Int index) => _at.Invoke(index);
        public Int Count() => _count.Invoke();
        public IEnumerator<ICell> GetEnumerator() => _getEnumerator.Invoke();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void AssertAtInvokedWith(Int indexOne, Int indexTwo)
        {
            _at.AssertValue(v => v.Should().Be(indexOne));
            _at.AssertValue(v => v.Should().Be(indexTwo));
        }
    }
}