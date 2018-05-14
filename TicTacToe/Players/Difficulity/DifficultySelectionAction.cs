using tictactoe.IO;
using tictactoe.Players.Moves;

namespace tictactoe.Players.Difficulity
{
    public sealed class DifficultySelectionAction : IValidInputResponseAction<ISelectMoveAction>
    {
        private readonly IDifficultySelectionAction _nextAction;

        public DifficultySelectionAction() : this(
            new EasyDifficultySelectionAction(
                new MediumDifficultySelectionAction(
                    new HardDifficultySelectionAction())))
        { }

        public DifficultySelectionAction(IDifficultySelectionAction nextAction) => _nextAction = nextAction;

        public ISelectMoveAction Response(string input) => _nextAction.Act(input);
    }
}