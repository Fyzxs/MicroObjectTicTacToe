using tictactoe.IO;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeFormattedValidInput<T> : IFormattedValidInput<T>
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<IValidResponse<T>> _validInputItem = new BuilderFuncReturn<IValidResponse<T>>("FakeFormattedValidInput#ValidInput");
            private readonly BuilderFuncVoid<string> _addPatternArgItem = new BuilderFuncVoid<string>("FakeFormattedValidInput#AddPatternArg");
            private readonly BuilderFuncVoid<string> _addPromptArgItem = new BuilderFuncVoid<string>("FakeFormattedValidInput#AddPromptArg");

            public Builder AddPromptArg()
            {
                _addPromptArgItem.UpdateInvocation();
                return this;
            }
            public Builder AddPatternArg()
            {
                _addPatternArgItem.UpdateInvocation();
                return this;
            }
            public Builder ValidInput(IValidResponse<T> expected)
            {
                _validInputItem.UpdateInvocation(expected);
                return this;
            }

            public FakeFormattedValidInput<T> Build()
            {
                return new FakeFormattedValidInput<T>
                {
                    _addPromptArg = _addPromptArgItem,
                    _addPatternArg = _addPatternArgItem,
                    _validInput = _validInputItem
                };
            }
        }

        private BuilderFuncVoid<string> _addPromptArg;
        private BuilderFuncReturn<IValidResponse<T>> _validInput;
        private BuilderFuncVoid<string> _addPatternArg;

        private FakeFormattedValidInput() { }
        public void AddPatternArg(string arg) => _addPatternArg.Invoke(arg);

        public void AddPromptArg(string arg) => _addPromptArg.Invoke(arg);

        public IValidResponse<T> ValidInput() => _validInput.Invoke();

        public void AssertAddPromptArgInvokedWith(string expected) => _addPromptArg.AssertInvokedWith(expected);

        public void AssertAddPatternArgInvokedWith(string expected) => _addPatternArg.AssertInvokedWith(expected);
    }
}