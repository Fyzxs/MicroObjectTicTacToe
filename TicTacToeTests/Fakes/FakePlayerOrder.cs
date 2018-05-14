using tictactoe.GameMode.TurnOrder;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes {
    public class FakePlayerOrder : IPlayerOrder
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<Bool> _humanFirstItem = new BuilderFuncReturn<Bool>("FakePlayerOrder#HumanFirst");

            public Builder HumanFirst(Bool expected)
            {
                _humanFirstItem.UpdateInvocation(expected);
                return this;
            }
            public FakePlayerOrder Build()
            {
                return new FakePlayerOrder { _humanFirst = _humanFirstItem };
            }
        }

        public BuilderFuncReturn<Bool> _humanFirst;
        private FakePlayerOrder() { }
        public Bool HumanFirst() => _humanFirst.Invoke();
    }
}