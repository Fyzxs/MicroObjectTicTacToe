using tictactoe.Players.Moves;

namespace tictactoe.Players.Difficulity {
    public interface IDifficultySelectionAction
    {
        ISelectMoveAction Act(string input);
    }
}