namespace tictactoe.GameMode.Actions {
    public sealed class HumanVsHumanGameModeSelectionAction : IGameModeSelectionAction
    {
        private readonly IGameModeSelectionAction _nextAction;
        public HumanVsHumanGameModeSelectionAction(IGameModeSelectionAction nextAction) => _nextAction = nextAction;

        public IGameMode Act(string selection)
        {
            if (selection == "2") return new HumanVsHumanGameMode();
            return _nextAction.Act(selection);
        }
    }
}