using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.EndGame;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.EndGame
{
    [TestClass]
    public class GameStateTests
    {
        [TestMethod, TestCategory("unit")]
        public void IsGameOver_ShouldReturnFalseGivenNotIsWinOrIsTie()
        {
            //Arrange
            FakeWin fakeWin = new FakeWin.Builder().IsWin(Bool.False).Build();
            FakeTie fakeTie = new FakeTie.Builder().IsTie(Bool.False).Build();
            GameState subject = new GameState(fakeWin, fakeTie);

            //Act
            Bool actual = subject.IsGameOver();

            //Assert
            ((bool)actual).Should().BeFalse();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnTrueGivenIsWin()
        {
            //Arrange
            FakeWin fakeWin = new FakeWin.Builder().IsWin(Bool.True).Build();
            FakeTie fakeTie = new FakeTie.Builder().IsTie(Bool.False).Build();
            GameState subject = new GameState(fakeWin, fakeTie);

            //Act
            Bool actual = subject.IsGameOver();

            //Assert
            ((bool)actual).Should().BeTrue();
        }
        [TestMethod, TestCategory("unit")]
        public void IsGameOver_ShouldReturnTrueGivenIsTie()
        {
            //Arrange
            FakeWin fakeWin = new FakeWin.Builder().IsWin(Bool.False).Build();
            FakeTie fakeTie = new FakeTie.Builder().IsTie(Bool.True).Build();
            GameState subject = new GameState(fakeWin, fakeTie);

            //Act
            Bool actual = subject.IsGameOver();

            //Assert
            ((bool)actual).Should().BeTrue();
        }
        [TestMethod, TestCategory("unit")]
        public void IsGameOver_ShouldReturnTrueGivenBoth()
        {
            //Arrange
            FakeWin fakeWin = new FakeWin.Builder().IsWin(Bool.True).Build();
            FakeTie fakeTie = new FakeTie.Builder().IsTie(Bool.True).Build();
            GameState subject = new GameState(fakeWin, fakeTie);

            //Act
            Bool actual = subject.IsGameOver();

            //Assert
            ((bool)actual).Should().BeTrue();
        }
    }
}