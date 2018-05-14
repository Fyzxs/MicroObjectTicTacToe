using tictactoe.Library.Bools;

namespace tictactoe.EndGame.Actions.Tie
{
    public sealed class ReturnTieEndsGameAction : ITieEndsGameAction
    {
        public Bool Act(Bool tie) => tie;
    }
}