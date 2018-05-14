namespace tictactoe.GameMode.Actions {
    public sealed class ComputerVsComputerGameModeSelectionAction : IGameModeSelectionAction
    {
        public IGameMode Act(string selection) => new ComputerVsComputerGameMode();
    }
}