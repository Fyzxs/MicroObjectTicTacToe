using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;
using tictactoe.EndGame;
using tictactoe.Library.Bools;
using tictactoe.Library.Ints;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.EndGame
{
    [TestClass]
    public class WinTests
    {
        [TestMethod, TestCategory("unit")]
        public void IsWin_ShouldReturnFalseWhenNotMatch()
        {
            //Arrange
            FakeCell fakeCell1 = new FakeCell.Builder().Value("1").Build();
            FakeCell fakeCell2 = new FakeCell.Builder().Value("2").Build();
            FakeCellCollection fakeCellCollection = new FakeCellCollection.Builder().At(fakeCell1, fakeCell2).Build();
            Win subject = new TestWin(fakeCellCollection, 1, 2, 3);

            //Act
            Bool actual = subject.IsWin();

            //Assert
            ((bool)actual).Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void IsWin_ShouldReturnTrueWhenIsWin()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().Value("1").Build();
            FakeCellCollection fakeCellCollection = new FakeCellCollection.Builder().At(fakeCell).Build();
            Win subject = new TestWin(fakeCellCollection, 1, 2, 3);

            //Act
            Bool actual = subject.IsWin();

            //Assert
            ((bool)actual).Should().BeTrue();
        }

        private class TestWin : Win
        {
            public TestWin(ICellCollection cells, int firstIndex, int secondIndex, int thirdIndex) : base(cells, new IntOf(firstIndex), new IntOf(secondIndex), new IntOf(thirdIndex)) { }
        }
    }
}