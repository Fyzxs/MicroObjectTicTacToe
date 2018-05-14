using tictactoe.Game;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeGameEnding : IGameEnding
    {

        public class Builder
        {
            private readonly BuilderFuncNone _displayItem = new BuilderFuncNone("FakeGameEnding#Display");

            public Builder Display()
            {
                _displayItem.UpdateInvocation();
                return this;
            }
            public FakeGameEnding Build()
            {
                return new FakeGameEnding { _display = _displayItem };
            }
        }

        private BuilderFuncNone _display;

        private FakeGameEnding() { }
        public void Display() => _display.Invoke();

        public void AssertDisplayInvoked() => _display.AssertInvoked();
    }
}