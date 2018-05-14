using tictactoe.IO;
using tictactoe.Library.Bools;

namespace tictactoe.EndGame.Actions.Tie
{
    public sealed class PrintTieEndsGameAction : ITieEndsGameAction
    {
        private readonly ITieEndsGameAction _nextAction;
        private readonly IPrinter _printer;

        public PrintTieEndsGameAction(ITieEndsGameAction nextAction) : this(nextAction, new CatsGamePrinter()) { }

        public PrintTieEndsGameAction(ITieEndsGameAction nextAction, IPrinter printer)
        {
            _nextAction = nextAction;
            _printer = printer;
        }

        public Bool Act(Bool tie)
        {
            Print(tie);
            return _nextAction.Act(tie);
        }

        private void Print(Bool tie)
        {
            if (tie.Not()) return;
            _printer.Print();
        }
    }
}