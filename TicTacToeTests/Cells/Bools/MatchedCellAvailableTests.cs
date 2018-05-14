using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells.Bools;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Cells.Bools
{
    [TestClass]
    public class MatchedCellAvailableTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTrueGivenMatchAndNotSelected()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().IsSelected(Bool.False).Build();
            Bool areEqual = Bool.True;
            MatchedCellAvailable subject = new MatchedCellAvailable(fakeCell, areEqual);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeFalseGivenMatchAndSelected()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().IsSelected(Bool.True).Build();
            Bool areEqual = Bool.True;
            MatchedCellAvailable subject = new MatchedCellAvailable(fakeCell, areEqual);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeFalseGivenNonMatchAndNotSelected()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().IsSelected(Bool.False).Build();
            Bool areEqual = Bool.False;
            MatchedCellAvailable subject = new MatchedCellAvailable(fakeCell, areEqual);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeFalseGivenNonMatchAndSelected()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().IsSelected(Bool.True).Build();
            Bool areEqual = Bool.False;
            MatchedCellAvailable subject = new MatchedCellAvailable(fakeCell, areEqual);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }
    }
}
