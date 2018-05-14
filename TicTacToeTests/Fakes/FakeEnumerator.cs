using System.Collections;
using System.Collections.Generic;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeEnumerator<T> : IEnumerator<T>
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<bool> _moveNextItem = new BuilderFuncReturn<bool>("FakeEnumerator#MoveNext");
            private readonly BuilderFuncNone _resetItem = new BuilderFuncNone("FakeEnumerator#Reset");
            private readonly BuilderFuncReturn<T> _currentItem = new BuilderFuncReturn<T>("FakeEnumerator#Current");

            public Builder Current(T expected)
            {
                _currentItem.UpdateInvocation(expected);
                return this;
            }
            public Builder Reset()
            {
                _resetItem.UpdateInvocation();
                return this;
            }
            public Builder MoveNext(params bool[] expected)
            {
                _moveNextItem.UpdateInvocation(expected);
                return this;
            }
            public FakeEnumerator<T> Build()
            {
                return new FakeEnumerator<T>
                {
                    _moveNext = _moveNextItem,
                    _reset = _resetItem,
                    _current = _currentItem
                };
            }
        }

        private BuilderFuncReturn<bool> _moveNext;
        private BuilderFuncNone _reset;
        private BuilderFuncReturn<T> _current;

        private FakeEnumerator() { }
        public bool MoveNext() => _moveNext.Invoke();

        public void Reset() => _reset.Invoke();

        public T Current => _current.Invoke();

        object IEnumerator.Current => Current;

        public void Dispose() { }//NoOp
    }
}