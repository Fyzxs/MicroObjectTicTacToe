namespace tictactoe.GameMode.Actions {
    public interface IGameModeSelectionAction
    {
        IGameMode Act(string selection);
    }
}