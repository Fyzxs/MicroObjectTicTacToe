using tictactoe.Library.Bools;

namespace tictactoe.EndGame.Actions.Tie {
    public interface ITieEndsGameAction
    {
        Bool Act(Bool tie);
    }
}