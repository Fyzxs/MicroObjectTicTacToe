using tictactoe.Cells;
using tictactoe.Players.Moves;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeMoveInput : IMoveInput
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<IGlyph> _inputItem = new BuilderFuncReturn<IGlyph>("FakeMoveInput#Input");

            public Builder Input(IGlyph expected)
            {
                _inputItem.UpdateInvocation(expected);
                return this;
            }
            public FakeMoveInput Build()
            {
                return new FakeMoveInput { _input = _inputItem };
            }
        }

        private BuilderFuncReturn<IGlyph> _input;

        private FakeMoveInput() { }
        public IGlyph Input(ICell playerCell) => _input.Invoke();
    }
}