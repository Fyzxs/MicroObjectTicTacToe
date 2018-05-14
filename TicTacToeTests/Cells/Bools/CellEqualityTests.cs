using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells.Bools;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Cells.Bools
{
    [TestClass]
    public class CellEqualityTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTrueForMatchingCells()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().Value("?").Build();
            FakeCell fakeCell2 = new FakeCell.Builder().Value("?").Build();
            CellEquality subject = new CellEquality(fakeCell, fakeCell2);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldBeFalseForNonMatchingCells()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().Value("?").Build();
            FakeCell fakeCell2 = new FakeCell.Builder().Value("X").Build();
            CellEquality subject = new CellEquality(fakeCell, fakeCell2);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }
    }
}
