using tictactoe.Boards;
using tictactoe.EndGame.Actions.Player;
using tictactoe.Library.Bools;
using tictactoe.Players;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakePlayerEndsGameAction : IPlayerEndsGameAction
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<Bool> _actItem = new BuilderFuncReturn<Bool>("FakePlayerEndsGameAction#Act");

            public Builder Act(Bool expected)
            {
                _actItem.UpdateInvocation(expected);
                return this;
            }
            public FakePlayerEndsGameAction Build()
            {
                return new FakePlayerEndsGameAction
                {
                    _act = _actItem
                };
            }
        }

        private BuilderFuncReturn<Bool> _act;
        private FakePlayerEndsGameAction() { }
        public Bool Act(IBoard board, IPlayer activePlayer, IPlayer inactivePlayer) => _act.Invoke();

        public void AssertActInvoked() => _act.AssertInvoked();
    }
}