using tictactoe.Players.Moves;
using tictactoe.Players.Moves.Computer.Hard;

namespace tictactoe.Players.Difficulity
{
    public sealed class HardDifficultySelectionAction : IDifficultySelectionAction
    {
        public ISelectMoveAction Act(string input) => new HardComputerSelectMoveAction();
    }
}