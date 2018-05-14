using tictactoe.Library.Bools;
using tictactoe.Library.Regexs;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeRegexBookEnd : IRegexBookEnd
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<Bool> _isMatchItem = new BuilderFuncReturn<Bool>("FakeRegexBookEnd#IsMatch");

            public Builder IsMatch(params Bool[] expected)
            {
                _isMatchItem.UpdateInvocation(expected);
                return this;
            }
            public FakeRegexBookEnd Build()
            {
                return new FakeRegexBookEnd { _isMatch = _isMatchItem };
            }
        }
        private BuilderFuncReturn<Bool> _isMatch;

        private FakeRegexBookEnd() { }
        public Bool IsMatch(string value) => _isMatch.Invoke(value);

        public void AssertIsMatchInvokedCountMatches(int expected) => _isMatch.InvokedCountMatches(expected);
    }
}