using tictactoe.Players.Moves;
using tictactoe.Players.Moves.Computer.Easy;

namespace tictactoe.Players.Difficulity
{
    public sealed class EasyDifficultySelectionAction : IDifficultySelectionAction
    {
        private readonly IDifficultySelectionAction _nextAction;

        public EasyDifficultySelectionAction(IDifficultySelectionAction nextAction) => _nextAction = nextAction;
        public ISelectMoveAction Act(string input)
        {
            if (input == "1") return new EasyComputerSelectMoveAction();
            return _nextAction.Act(input);
        }
    }
}