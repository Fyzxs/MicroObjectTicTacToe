using tictactoe.Library.Bools;
using tictactoe.Players;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakePlayersTurns : IPlayersTurns
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<Bool> _gameOverItem = new BuilderFuncReturn<Bool>("FakePlayersTurns#GameOver");

            public Builder GameOver(params Bool[] expected)
            {
                _gameOverItem.UpdateInvocation(expected);
                return this;
            }
            public FakePlayersTurns Build()
            {
                return new FakePlayersTurns { _gameOver = _gameOverItem };
            }
        }

        private BuilderFuncReturn<Bool> _gameOver;
        private FakePlayersTurns() { }
        public Bool GameOver() => _gameOver.Invoke();

        public void AssertGameOverInvokedCountMatches(int expected) => _gameOver.InvokedCountMatches(expected);
    }
}