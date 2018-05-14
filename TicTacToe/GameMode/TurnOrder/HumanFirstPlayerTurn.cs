namespace tictactoe.GameMode.TurnOrder
{
    public sealed class HumanFirstPlayerTurn : IPlayerTurnsOrderAction
    {
        private readonly IPlayerTurnsOrderAction _nextAction;

        public HumanFirstPlayerTurn(IPlayerTurnsOrderAction nextAction) => _nextAction = nextAction;

        public IPlayerOrder Response(string validInput)
        {
            if (validInput == "1") return new HumanFirstOrder();
            return _nextAction.Response(validInput);
        }
    }
}