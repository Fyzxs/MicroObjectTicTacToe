using tictactoe.GameMode;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeGameModeSelection : IGameModeSelection
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<IGameMode> _selectItem = new BuilderFuncReturn<IGameMode>("FakeGameModeSelection#Select");

            public Builder Select(IGameMode expected)
            {
                _selectItem.UpdateInvocation(expected);
                return this;
            }
            public FakeGameModeSelection Build()
            {
                return new FakeGameModeSelection { _select = _selectItem };
            }
        }

        private BuilderFuncReturn<IGameMode> _select;
        private FakeGameModeSelection() { }
        public IGameMode Select() => _select.Invoke();

        public void AssertSelectInvoked() => _select.AssertInvoked();
    }
}