using tictactoe.EndGame;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeTie : ITie
    {

        public class Builder
        {
            private readonly BuilderFuncReturn<Bool> _isTieItem = new BuilderFuncReturn<Bool>("FakeTie#IsTie");

            public Builder IsTie(Bool expected)
            {
                _isTieItem.UpdateInvocation(expected);
                return this;
            }
            public FakeTie Build()
            {
                return new FakeTie
                {
                    _isTie = _isTieItem
                };
            }
        }
        private BuilderFuncReturn<Bool> _isTie;

        private FakeTie() { }
        public Bool IsTie() => _isTie.Invoke();
    }
}