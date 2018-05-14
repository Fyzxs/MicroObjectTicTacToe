using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;
using tictactoe.Cells.Bools;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Cells.Bools
{
    [TestClass]
    public class AllCellsSelectedTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnTrueWhenAllSelected()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().IsSelected(Bool.True).Build();
            List<ICell> cells = new List<ICell>() { fakeCell };
            FakeCellCollection fakeCellCollection = new FakeCellCollection.Builder().GetEnumerator(cells.GetEnumerator()).Build();
            AllCellsSelected subject = new AllCellsSelected(fakeCellCollection);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldReturnFalseWhenNotAllSelected()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().IsSelected(Bool.False).Build();
            List<ICell> cells = new List<ICell>() { fakeCell };
            FakeCellCollection fakeCellCollection = new FakeCellCollection.Builder().GetEnumerator(cells.GetEnumerator()).Build();
            AllCellsSelected subject = new AllCellsSelected(fakeCellCollection);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }
    }
}
