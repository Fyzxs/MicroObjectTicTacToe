using tictactoe.Players.Moves;
using tictactoe.Players.Moves.Computer.Medium;

namespace tictactoe.Players.Difficulity
{
    public sealed class MediumDifficultySelectionAction : IDifficultySelectionAction
    {
        private readonly IDifficultySelectionAction _nextAction;

        public MediumDifficultySelectionAction(IDifficultySelectionAction nextAction) => _nextAction = nextAction;
        public ISelectMoveAction Act(string input)
        {
            if (input == "2") return new MediumComputerSelectMoveAction();
            return _nextAction.Act(input);
        }
    }
}