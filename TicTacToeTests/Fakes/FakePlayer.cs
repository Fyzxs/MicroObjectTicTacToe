using tictactoe.Boards;
using tictactoe.Cells;
using tictactoe.IO;
using tictactoe.Players;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakePlayer : IPlayer
    {
        public class Builder
        {
            private readonly BuilderFuncVoid<IPlayer> _takeActionItem = new BuilderFuncVoid<IPlayer>("FakePlayer#TakeAction");
            private readonly BuilderFuncReturn<ICell> _cellItem = new BuilderFuncReturn<ICell>("FakePlayer#Cell");
            private readonly BuilderFuncReturn<IPrinter> _winPrinterItem = new BuilderFuncReturn<IPrinter>("FakePlayer#WinPrinter");

            public Builder WinPrinter(IPrinter expected)
            {
                _winPrinterItem.UpdateInvocation(expected);
                return this;
            }
            public Builder Cell(ICell expected)
            {
                _cellItem.UpdateInvocation(expected);
                return this;
            }
            public Builder TakeAction()
            {
                _takeActionItem.UpdateInvocation();
                return this;
            }
            public FakePlayer Build()
            {
                return new FakePlayer
                {
                    _takeAction = _takeActionItem,
                    _cell = _cellItem,
                    _winPrinter = _winPrinterItem
                };
            }
        }

        private BuilderFuncReturn<ICell> _cell;
        private BuilderFuncVoid<IPlayer> _takeAction;
        private BuilderFuncReturn<IPrinter> _winPrinter;
        private FakePlayer() { }
        public void TakeAction(IBoard board, IPlayer otherPlayer) => _takeAction.Invoke(otherPlayer);

        public ICell Cell() => _cell.Invoke();
        public IPrinter WinPrinter() => _winPrinter.Invoke();

        public void AssertTakeActionInvoked() => _takeAction.AssertInvoked();
    }
}