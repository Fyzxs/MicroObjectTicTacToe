using FluentAssertions;
using System;
using tictactoe.Boards;
using tictactoe.Cells;
using tictactoe.Players;
using tictactoe.Players.Moves;
using TicTacToeTests.Fakes.Builders;

namespace TicTacToeTests.Fakes
{
    public class FakeSelectMoveAction : ISelectMoveAction
    {
        public class Builder
        {
            private readonly BuilderFuncReturn<ICell> _actItem = new BuilderFuncReturn<ICell>("FakeSelectMoveAction#Act");

            public Builder Act(ICell expected)
            {
                _actItem.UpdateInvocation(expected);
                return this;
            }
            public FakeSelectMoveAction Build()
            {
                return new FakeSelectMoveAction { _act = _actItem };
            }
        }

        private BuilderFuncReturn<ICell> _act;
        private FakeSelectMoveAction() { }
        public ICell Act(IBoard board, IPlayer thisPlayer, IPlayer otherPlayer) => _act.Invoke(new Tuple<IBoard, IPlayer, IPlayer>(board, thisPlayer, otherPlayer));

        public void AssertActInvokedWith(Tuple<IBoard, IPlayer, IPlayer> expected)
        {
            _act.AssertValue(actual =>
            {
                Tuple<IBoard, IPlayer, IPlayer> tuple = actual as Tuple<IBoard, IPlayer, IPlayer>;
                tuple.Item1.Should().Be(expected.Item1);
                tuple.Item2.Should().Be(expected.Item2);
                tuple.Item3.Should().Be(expected.Item3);
            });
        }

        public void AssertActInvoked() => _act.AssertInvoked();
    }
}