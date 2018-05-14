using FluentAssertions;
using tictactoe.GameMode;
using tictactoe.GameMode.Actions;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeGameModeSelectionAction : IGameModeSelectionAction
    {

        public class Builder
        {
            private readonly BuilderFuncReturn<IGameMode> _actItem = new BuilderFuncReturn<IGameMode>("FakeGameModeSelectionAction#Act");

            public Builder Act(IGameMode expected)
            {
                _actItem.UpdateInvocation(expected);
                return this;
            }
            public FakeGameModeSelectionAction Build()
            {
                return new FakeGameModeSelectionAction { _act = _actItem };
            }
        }

        private BuilderFuncReturn<IGameMode> _act;
        private FakeGameModeSelectionAction() { }
        public IGameMode Act(string selection) => _act.Invoke(selection);

        public void AssertActInvoked() => _act.AssertInvoked();

        public void AssertActInvokedWith(string expected)
        {
            _act.AssertValue(m => m.Should().Be(expected));
        }
    }
}