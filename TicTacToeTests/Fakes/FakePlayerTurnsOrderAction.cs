using tictactoe.GameMode.TurnOrder;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes {
    public class FakePlayerTurnsOrderAction : IPlayerTurnsOrderAction
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<IPlayerOrder> _responseItem = new BuilderFuncReturn<IPlayerOrder>("FakePlayerTurnsOrderAction#Response");

            public Builder Response(IPlayerOrder expected)
            {
                _responseItem.UpdateInvocation(expected);
                return this;
            }
            public FakePlayerTurnsOrderAction Build()
            {
                return new FakePlayerTurnsOrderAction { _response = _responseItem };
            }
        }

        private BuilderFuncReturn<IPlayerOrder> _response;
        private FakePlayerTurnsOrderAction() { }
        public IPlayerOrder Response(string validInput) => _response.Invoke(validInput);

        public void AssertResponseInvoked() => _response.AssertInvoked();
    }
}