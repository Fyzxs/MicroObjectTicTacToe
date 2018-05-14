using tictactoe.Cells;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeCell : ICell
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<string> _valueItem = new BuilderFuncReturn<string>("FakeCell#Value");
            private readonly BuilderFuncReturn<Bool> _isSelectedItem = new BuilderFuncReturn<Bool>("FakeCell#Replaced");
            private readonly BuilderFuncReturn<ICell> _asSelectedItem = new BuilderFuncReturn<ICell>("FakeCell#AsSelected");

            public Builder AsSelected(ICell expected)
            {
                _asSelectedItem.UpdateInvocation(expected);
                return this;
            }
            public Builder IsSelected(Bool expected)
            {
                _isSelectedItem.UpdateInvocation(expected);
                return this;
            }
            public Builder Value(string expected)
            {
                _valueItem.UpdateInvocation(expected);
                return this;
            }
            public FakeCell Build()
            {
                return new FakeCell
                {
                    _value = _valueItem,
                    _isSelected = _isSelectedItem,
                    _asSelected = _asSelectedItem
                };
            }
        }

        private BuilderFuncReturn<string> _value;
        private BuilderFuncReturn<Bool> _isSelected;
        private BuilderFuncReturn<ICell> _asSelected;
        private FakeCell() { }
        public string Value() => _value.Invoke();

        public Bool IsSelected() => _isSelected.Invoke();

        public ICell AsSelected() => _asSelected.Invoke();

        public void AssertIsSelectedInvoked() => _isSelected.AssertInvoked();
        public void AssertAsSelectedInvoked() => _asSelected.AssertInvoked();
        public void AssertValueInvoked() => _value.AssertInvoked();
    }
}