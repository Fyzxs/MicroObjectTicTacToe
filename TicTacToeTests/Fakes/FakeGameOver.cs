using tictactoe.EndGame;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeGameState : IGameState
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<Bool> _isGameOverItem = new BuilderFuncReturn<Bool>("FakeGameState#IsGameOver");
            private readonly BuilderFuncReturn<Bool> _hasWinnerItem = new BuilderFuncReturn<Bool>("FakeGameState#HasWinner");
            private readonly BuilderFuncReturn<Bool> _isTieItem = new BuilderFuncReturn<Bool>("FakeGameState#IsGameOver");
            public Builder IsGameOver(Bool expected)
            {
                _isGameOverItem.UpdateInvocation(expected);
                return this;
            }
            public Builder HasWinner(params Bool[] expected)
            {
                _hasWinnerItem.UpdateInvocation(expected);
                return this;
            }
            public Builder IsTie(Bool expected)
            {
                _isTieItem.UpdateInvocation(expected);
                return this;
            }
            public FakeGameState Build()
            {
                return new FakeGameState
                {
                    _isGameOver = _isGameOverItem,
                    _hasWinner = _hasWinnerItem,
                    _isTie = _isTieItem
                };
            }
        }

        private BuilderFuncReturn<Bool> _isGameOver;
        private BuilderFuncReturn<Bool> _hasWinner;
        private BuilderFuncReturn<Bool> _isTie;
        private FakeGameState() { }
        public Bool IsGameOver() => _isGameOver.Invoke();
        public Bool HasWinner() => _hasWinner.Invoke();
        public Bool IsTie() => _isTie.Invoke();
    }
}