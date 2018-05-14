using tictactoe.EndGame.Actions.Tie;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes {
    public class FakeTieEndsGameAction : ITieEndsGameAction
    {

        public class Builder
        {
            private readonly BuilderFuncReturn<Bool> _actItem = new BuilderFuncReturn<Bool>("FakeTieEndsGameAction#Act");

            public Builder Act(Bool expected)
            {
                _actItem.UpdateInvocation(expected);
                return this;
            }
            public FakeTieEndsGameAction Build()
            {
                return new FakeTieEndsGameAction { _act = _actItem };
            }
        }
        private BuilderFuncReturn<Bool> _act;

        private FakeTieEndsGameAction() { }

        public Bool Act(Bool tie) => _act.Invoke();

        public void AssertActInvoked() => _act.AssertInvoked();
    }
}