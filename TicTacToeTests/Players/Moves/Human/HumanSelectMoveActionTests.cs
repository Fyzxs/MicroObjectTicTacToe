using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;
using tictactoe.Library.Bools;
using tictactoe.Players.Moves.Human;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Players.Moves.Human
{
    [TestClass]
    public class HumanSelectMoveActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void Act_ShouldReturnAvailableCell()
        {
            //Arrange
            FakeCell expected = new FakeCell.Builder().Value("1").Build();
            FakeBoard fakeBoard = new FakeBoard.Builder()
                .Available(Bool.False, Bool.False, Bool.False, Bool.True).Build();
            FakeCell fakeCell = new FakeCell.Builder().Build();
            FakePlayer fakePlayer = new FakePlayer.Builder().Cell(fakeCell).Build();
            FakePlayer fakePlayerOther = new FakePlayer.Builder().Build();
            FakeMoveInput fakeMoveInput = new FakeMoveInput.Builder().Input(new Glyph('1')).Build();
            HumanSelectMoveAction subject = new HumanSelectMoveAction(fakeMoveInput);

            //Act
            ICell actual = subject.Act(fakeBoard, fakePlayer, fakePlayerOther);

            //Assert
            actual.Value().Should().Be(expected.Value());
        }
    }
}