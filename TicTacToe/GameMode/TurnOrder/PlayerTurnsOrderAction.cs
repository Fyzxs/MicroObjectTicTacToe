namespace tictactoe.GameMode.TurnOrder
{
    public sealed class PlayerTurnsOrderAction : IPlayerTurnsOrderAction
    {
        private readonly IPlayerTurnsOrderAction _nextAction;
        public PlayerTurnsOrderAction() : this(
            new HumanFirstPlayerTurn(
                new ComputerFirstPlayerTurn()))
        { }

        public PlayerTurnsOrderAction(IPlayerTurnsOrderAction nextAction) => _nextAction = nextAction;

        public IPlayerOrder Response(string validInput) => _nextAction.Response(validInput);
    }
}