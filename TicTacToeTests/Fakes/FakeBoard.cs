using FluentAssertions;
using System;
using tictactoe.Boards;
using tictactoe.Cells;
using tictactoe.EndGame;
using tictactoe.Library.Bools;
using tictactoe.Players;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeBoard : IBoard
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<IBoard> _cloneItem = new BuilderFuncReturn<IBoard>("FakeBoard#Clone");
            private readonly BuilderFuncReturn<Bool> _claimEndsGameItem = new BuilderFuncReturn<Bool>("FakeBoard#ClaimEndsGame");
            private readonly BuilderFuncReturn<Bool> _availableItem = new BuilderFuncReturn<Bool>("FakeBoard#Available");
            private readonly BuilderFuncNone _printItem = new BuilderFuncNone("FakeBoard#Print");
            private readonly BuilderFuncReturn<ICellCollection> _availableSpacesItem = new BuilderFuncReturn<ICellCollection>("FakeBoard#AvailableSpaces");
            private readonly BuilderFuncReturn<IGameState> _gameStateItem = new BuilderFuncReturn<IGameState>("FakeBoard#GameState");

            public Builder GameState(IGameState expected)
            {
                _gameStateItem.UpdateInvocation(expected);
                return this;
            }
            public Builder Print()
            {
                _printItem.UpdateInvocation();
                return this;
            }
            public Builder AvailableSpaces(params ICellCollection[] expected)
            {
                _availableSpacesItem.UpdateInvocation(expected);
                return this;
            }
            public Builder Available(params Bool[] expected)
            {
                _availableItem.UpdateInvocation(expected);
                return this;
            }
            public Builder ClaimEndsGame(params Bool[] expected)
            {
                _claimEndsGameItem.UpdateInvocation(expected);
                return this;
            }
            public Builder Clone(params IBoard[] expected)
            {
                _cloneItem.UpdateInvocation(expected);
                return this;
            }

            public FakeBoard Build()
            {
                return new FakeBoard
                {
                    _availableSpaces = _availableSpacesItem,
                    _available = _availableItem,
                    _claimEndsGame = _claimEndsGameItem,
                    _clone = _cloneItem,
                    _print = _printItem,
                    _gameState = _gameStateItem
                };
            }
        }

        private BuilderFuncReturn<ICellCollection> _availableSpaces;
        private BuilderFuncReturn<Bool> _available;
        private BuilderFuncReturn<IBoard> _clone;
        private BuilderFuncReturn<Bool> _claimEndsGame;
        private BuilderFuncNone _print;
        private BuilderFuncReturn<IGameState> _gameState;
        private FakeBoard() { }

        public IBoard Clone() => _clone.Invoke();

        public void Print() => _print.Invoke();
        public Bool Available(ICell cell) => _available.Invoke(cell);

        public ICellCollection AvailableSpaces() => _availableSpaces.Invoke();

        public Bool ClaimEndsGame(ICell cell, IPlayer player) => _claimEndsGame.Invoke(new Tuple<ICell, IPlayer>(cell, player));
        public IGameState GameState() => _gameState.Invoke();


        public Bool Available(int cell) => _available.Invoke(cell);

        public void AssertClaimInvokedFor(ICell cell) => _claimEndsGame.AssertValue(action => (action as Tuple<ICell, IPlayer>).Item1.Value().Should().Be(cell.Value()));

        public void AssertCloneInvokeCount(int invokeCount) => _clone.InvokedCountMatches(invokeCount);

        public void AssertAvailableInvokedCount(int invokeCount) => _available.InvokedCountMatches(invokeCount);

        public void AssertPrintInvoked() => _print.AssertInvoked();

        public void AssertClaimEndsGameInvokedCount(int expected) => _claimEndsGame.InvokedCountMatches(expected);

        public void CloneInvokedCount(int expected) => _clone.InvokedCountMatches(expected);

        public void AssertClaimEndsGameInvokedWith(ICell expectedCell, IPlayer expectedPlayer)
        {
            _claimEndsGame.AssertValue(actual =>
            {
                Tuple<ICell, IPlayer> tuple = actual as Tuple<ICell, IPlayer>;
                tuple.Item1.Should().Be(expectedCell);
                tuple.Item2.Should().Be(expectedPlayer);
            });
        }

        public void AssertClaimEndsGameInvoked() => _claimEndsGame.AssertInvoked();
    }
}