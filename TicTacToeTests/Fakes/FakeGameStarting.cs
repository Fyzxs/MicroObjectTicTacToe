using tictactoe.Boards;
using tictactoe.Game;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeGameStarting : IGameStarting
    {
        public class Builder
        {
            private readonly BuilderFuncNone _displayWelcomeItem = new BuilderFuncNone("FakeGameStarting#DisplayWelcome");
            private readonly BuilderFuncVoid<IBoard> _displayInitialBoardItem = new BuilderFuncVoid<IBoard>("FakeGameStarting#DisplayInitialBoard");

            public Builder DisplayInitialBoard()
            {
                _displayInitialBoardItem.UpdateInvocation();
                return this;
            }

            public Builder DisplayWelcome()
            {
                _displayWelcomeItem.UpdateInvocation();
                return this;
            }
            public FakeGameStarting Build()
            {
                return new FakeGameStarting
                {
                    _displayWelcome = _displayWelcomeItem,
                    _displayInitialBoard = _displayInitialBoardItem
                };
            }
        }

        private BuilderFuncNone _displayWelcome;
        private BuilderFuncVoid<IBoard> _displayInitialBoard;
        private FakeGameStarting() { }
        public void DisplayWelcome() => _displayWelcome.Invoke();

        public void DisplayInitialBoard(IBoard board) => _displayInitialBoard.Invoke(board);

        public void AssertDisplayWelcomeInvoked() => _displayWelcome.AssertInvoked();

        public void AssertDisplayInitialBoardInvoked() => _displayInitialBoard.AssertInvoked();
    }
}