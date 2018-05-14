using tictactoe.IO;

namespace tictactoe.GameMode.Actions
{
    public sealed class GameModeSelectionAction : IValidInputResponseAction<IGameMode>
    {
        private readonly IGameModeSelectionAction _nextAction;

        public GameModeSelectionAction() : this(
            new HumanVsComputerGameModeSelectionAction(
                new HumanVsHumanGameModeSelectionAction(
                    new ComputerVsComputerGameModeSelectionAction())))
        { }
        public GameModeSelectionAction(IGameModeSelectionAction nextAction) => _nextAction = nextAction;

        public IGameMode Response(string selection) => _nextAction.Act(selection);
    }
}