using tictactoe.Library.Random;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes {
    public class FakeSingleReservoirSample<T> : ISingleReservoirSample<T>
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<T> _elementItem = new BuilderFuncReturn<T>("FakeSingleReservoirSample#Element");

            public Builder Element(T expected)
            {
                _elementItem.UpdateInvocation(expected);
                return this;
            }
            public FakeSingleReservoirSample<T> Build()
            {
                return new FakeSingleReservoirSample<T>
                {
                    _element = _elementItem
                };
            }
        }

        private BuilderFuncReturn<T> _element;
        private FakeSingleReservoirSample() { }
        public T Element() => _element.Invoke();
    }
}