using FluentAssertions;
using tictactoe.Players;
using tictactoe.Players.Creation;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakePlayerCreation : IPlayerCreation
    {
        public class Builder
        {

            private readonly BuilderFuncReturn<IPlayer> _playerItem = new BuilderFuncReturn<IPlayer>("FakePlayerCreation#Player");

            public Builder Player(params IPlayer[] expected)
            {
                _playerItem.UpdateInvocation(expected);
                return this;
            }

            public FakePlayerCreation Build()
            {
                return new FakePlayerCreation { _player = _playerItem };
            }
        }

        private BuilderFuncReturn<IPlayer> _player;
        private FakePlayerCreation() { }
        public IPlayer Player(string mark) => _player.Invoke(mark);

        public void PlayerInvokedWith(string mark)
        {
            _player.AssertValue(m => m.Should().Be(mark));
        }
    }
}