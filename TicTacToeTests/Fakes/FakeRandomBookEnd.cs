using FluentAssertions;
using System;
using tictactoe.Library.Ints;
using tictactoe.Library.Random;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeRandomBookEnd : IRandomBookEnd
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<Int> _nextIntItem = new BuilderFuncReturn<Int>("FakeRandomBookEnd#NextInt");

            public Builder NextInt(params Int[] expected)
            {
                _nextIntItem.UpdateInvocation(expected);
                return this;
            }
            public FakeRandomBookEnd Build()
            {
                return new FakeRandomBookEnd { _nextInt = _nextIntItem };
            }
        }
        private BuilderFuncReturn<Int> _nextInt;

        private FakeRandomBookEnd() { }
        public Int NextInt(Int inclusiveMin, Int exclusiveMax) => _nextInt.Invoke(new Tuple<Int, Int>(inclusiveMin, exclusiveMax));

        public void AssertNextIntInvokedWith(Int expectedMin, Int expectedMax)
        {
            _nextInt.AssertValue(action =>
            {
                Tuple<Int, Int> tuple = action as Tuple<Int, Int>;
                ((int)tuple.Item1).Should().Be((int)expectedMin);
                ((int)tuple.Item2).Should().Be((int)expectedMax);
            });
        }
    }
}