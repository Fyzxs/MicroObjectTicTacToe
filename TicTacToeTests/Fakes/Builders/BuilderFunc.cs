using FluentAssertions;
using System;

namespace TicTacToeTests.Fakes.Builders
{
    public abstract class BuilderFunc<T>
    {
        private readonly string _name;
        protected int InvokedCount;

        protected BuilderFunc(string name) => _name = name;
        public void AssertInvoked() => Invoked().Should().BeTrue($"{_name} was expected but not invoked.");
        public abstract void Assert(Action<T> assertion);
        private bool Invoked() => 0 < InvokedCount;
        public void InvokedCountMatches(int count) => InvokedCount.Should().Be(count, $"{_name} [InvokedCount={InvokedCount}] does not match expected [count={count}].");
    }
}