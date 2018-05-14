using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.EndGame;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.EndGame
{
    [TestClass]
    public class PossibleWinsTests
    {
        [TestMethod, TestCategory("unit")]
        public void IsWin_ShouldReturnIfWinner()
        {
            //Arrange
            FakeWin fakeWin = new FakeWin.Builder().IsWin(Bool.True).Build();
            PossibleWins subject = new PossibleWins(fakeWin);

            //Act
            Bool actual = subject.IsWin();

            //Assert
            ((bool)actual).Should().BeTrue();
        }
        [TestMethod, TestCategory("unit")]
        public void IsWin_ShouldReturnFalseIfNoWinner()
        {
            //Arrange
            FakeWin fakeWin = new FakeWin.Builder().IsWin(Bool.False).Build();
            PossibleWins subject = new PossibleWins(fakeWin);

            //Act
            Bool actual = subject.IsWin();

            //Assert
            ((bool)actual).Should().BeFalse();
        }
    }
}