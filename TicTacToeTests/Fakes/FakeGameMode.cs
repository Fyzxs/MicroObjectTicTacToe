using FluentAssertions;
using tictactoe.Boards;
using tictactoe.GameMode;
using tictactoe.Players;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeGameMode : IGameMode
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<IPlayersTurns> _configurePlayersItem = new BuilderFuncReturn<IPlayersTurns>("FakeGameMode#ConfigurePlayers");

            public Builder ConfigurePlayers(IPlayersTurns expected)
            {
                _configurePlayersItem.UpdateInvocation(expected);
                return this;
            }
            public FakeGameMode Build()
            {
                return new FakeGameMode
                {
                    _configurePlayers = _configurePlayersItem
                };
            }
        }

        private BuilderFuncReturn<IPlayersTurns> _configurePlayers;
        private FakeGameMode() { }
        public IPlayersTurns ConfigurePlayers(IBoard board) => _configurePlayers.Invoke(board);

        public void AssertConfigurePlayersInvokedWith(IBoard expected) => _configurePlayers.AssertValue(b => b.Should().Be(expected));
    }
}