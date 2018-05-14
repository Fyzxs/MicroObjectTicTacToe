using tictactoe.IO;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakePrinter : IPrinter
    {
        public class Builder
        {
            private readonly BuilderFuncNone _printItem = new BuilderFuncNone("FakePrinter#Print");

            public Builder Print()
            {
                _printItem.UpdateInvocation();
                return this;
            }
            public FakePrinter Build()
            {
                return new FakePrinter
                {
                    _print = _printItem
                };
            }
        }
        private BuilderFuncNone _print;

        private FakePrinter() { }
        public void Print() => _print.Invoke();

        public void AssertPrintInvoked() => _print.AssertInvoked();
    }
}