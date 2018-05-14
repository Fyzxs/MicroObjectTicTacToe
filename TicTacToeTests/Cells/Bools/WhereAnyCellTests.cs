using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using tictactoe.Cells;
using tictactoe.Cells.Bools;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Cells.Bools
{
    [TestClass]
    public class WhereAnyCellTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTrueWhenAnyCell()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().Build();
            List<ICell> cells = new List<ICell> { fakeCell };
            WhereAnyCell subject = new WhereAnyCell(cells, cell => true);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeFakseWhenAnyCell()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().Build();
            List<ICell> cells = new List<ICell> { fakeCell };
            WhereAnyCell subject = new WhereAnyCell(cells, cell => false);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }
    }
}
