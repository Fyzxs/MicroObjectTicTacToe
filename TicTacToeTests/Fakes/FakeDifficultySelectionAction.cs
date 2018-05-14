using tictactoe.Players.Difficulity;
using tictactoe.Players.Moves;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeDifficultySelectionAction : IDifficultySelectionAction
    {

        public class Builder
        {
            private readonly BuilderFuncReturn<ISelectMoveAction> _actItem = new BuilderFuncReturn<ISelectMoveAction>("FakeDifficultySelectionAction#Act");

            public Builder Act(ISelectMoveAction expected)
            {
                _actItem.UpdateInvocation(expected);
                return this;
            }
            public FakeDifficultySelectionAction Build()
            {
                return new FakeDifficultySelectionAction
                {
                    _act = _actItem
                };
            }
        }
        private BuilderFuncReturn<ISelectMoveAction> _act;

        private FakeDifficultySelectionAction() { }
        public ISelectMoveAction Act(string input) => _act.Invoke(input);

        public void AssertActInvoked() => _act.AssertInvoked();

    }
}