namespace tictactoe.GameMode.TurnOrder
{
    public sealed class ComputerFirstPlayerTurn : IPlayerTurnsOrderAction
    {
        public IPlayerOrder Response(string validInput) => new ComputerFirstOrder();
    }
}