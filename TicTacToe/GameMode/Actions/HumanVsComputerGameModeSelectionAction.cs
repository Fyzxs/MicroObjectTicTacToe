namespace tictactoe.GameMode.Actions {
    public sealed class HumanVsComputerGameModeSelectionAction : IGameModeSelectionAction
    {
        private readonly IGameModeSelectionAction _nextAction;
        public HumanVsComputerGameModeSelectionAction(IGameModeSelectionAction nextAction) => _nextAction = nextAction;

        public IGameMode Act(string selection)
        {
            if (selection == "1") return new HumanVsComputerGameMode();
            return _nextAction.Act(selection);
        }
    }
}