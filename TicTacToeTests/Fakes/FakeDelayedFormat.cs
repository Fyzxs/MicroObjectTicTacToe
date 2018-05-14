using tictactoe.Library;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeDelayedFormat : IDelayedFormat
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<string> _valueItem = new BuilderFuncReturn<string>("FakeDelayedFormat#Value");
            private readonly BuilderFuncVoid<string> _addItem = new BuilderFuncVoid<string>("FakeDelayedFormat#Add");

            public Builder Add()
            {
                _addItem.UpdateInvocation();
                return this;
            }
            public Builder Value(string expected)
            {
                _valueItem.UpdateInvocation(expected);
                return this;
            }
            public FakeDelayedFormat Build()
            {

                return new FakeDelayedFormat
                {
                    _add = _addItem,
                    _value = _valueItem
                };
            }
        }

        private BuilderFuncVoid<string> _add;
        private BuilderFuncReturn<string> _value;

        private FakeDelayedFormat() { }
        public void Add(string value) => _add.Invoke(value);

        public string Value() => _value.Invoke();

        public void AssertAddInvokedWith(string expected) => _add.AssertInvokedWith(expected);

        public void AssertValueInvoked() => _value.AssertInvoked();
    }
}