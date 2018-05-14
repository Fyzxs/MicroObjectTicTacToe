using tictactoe.EndGame;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeWin : IWin
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<Bool> _isWinItem = new BuilderFuncReturn<Bool>("FakeWin#IsWin");

            public Builder IsWin(Bool expected)
            {
                _isWinItem.UpdateInvocation(expected);
                return this;
            }
            public FakeWin Build()
            {
                return new FakeWin
                {
                    _isWin = _isWinItem
                };
            }
        }

        private BuilderFuncReturn<Bool> _isWin;
        private FakeWin() { }
        public Bool IsWin() => _isWin.Invoke();
    }
}