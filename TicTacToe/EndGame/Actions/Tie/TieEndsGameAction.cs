using tictactoe.Library.Bools;

namespace tictactoe.EndGame.Actions.Tie
{
    public sealed class TieEndsGameAction : ITieEndsGameAction
    {
        private readonly ITieEndsGameAction _nextAction;

        public TieEndsGameAction() : this(
            new PrintTieEndsGameAction(
                new ReturnTieEndsGameAction()))
        { }

        public TieEndsGameAction(ITieEndsGameAction nextAction) => _nextAction = nextAction;

        public Bool Act(Bool tie) => _nextAction.Act(tie);
    }
}