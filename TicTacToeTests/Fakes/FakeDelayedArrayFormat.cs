using tictactoe.Library;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeDelayedArrayFormat : IDelayedArrayFormat
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<string[]> _valueItem = new BuilderFuncReturn<string[]>("FakeDelayedArrayFormat#Value");
            private readonly BuilderFuncVoid<string> _addItem = new BuilderFuncVoid<string>("FakeDelayedArrayFormat#Add");

            public Builder Add()
            {
                _addItem.UpdateInvocation();
                return this;
            }
            public Builder Value(string[] expected)
            {
                _valueItem.UpdateInvocation(expected);
                return this;
            }
            public FakeDelayedArrayFormat Build()
            {

                return new FakeDelayedArrayFormat
                {
                    _add = _addItem,
                    _value = _valueItem
                };
            }
        }

        private BuilderFuncVoid<string> _add;
        private BuilderFuncReturn<string[]> _value;

        private FakeDelayedArrayFormat() { }
        public void Add(string value) => _add.Invoke(value);

        public string[] Value() => _value.Invoke();

        public void AssertAddInvokedWith(string expected) => _add.AssertInvokedWith(expected);

        public void AssertValueInvoked() => _value.AssertInvoked();
    }
}