using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using tictactoe.Cells;
using tictactoe.Library.Bools;
using tictactoe.Library.Ints;

namespace TicTacToeTests.Cells
{
    [TestClass]
    public class CellCollectionTests
    {
        private static readonly ICell Cell0 = new UnselectedCell(new Glyph('0'));
        private static readonly ICell CellX = new UnselectedCell(new Glyph('X'));
        private static readonly ICell Cell1 = new UnselectedCell(new Glyph('1'));

        [TestMethod, TestCategory("unit")]
        public void UpdateTo_ShouldUpdateCell()
        {
            //Arrange
            ICell[] cells = { Cell0 };
            CellCollection subject = new CellCollection(cells);

            //Act
            subject.UpdateTo(Cell0, Cell1);

            //Assert
            cells[0].Value().Should().Be(Cell1.Value());
        }

        [TestMethod, TestCategory("unit")]
        public void UpdateTo_ShouldNotReplaceIfNotFound()
        {
            //Arrange
            ICell[] cells = { Cell0 };
            CellCollection subject = new CellCollection(cells);

            //Act
            subject.UpdateTo(CellX, Cell1);

            //Assert
            cells[0].Should().Be(Cell0);
        }

        [TestMethod, TestCategory("unit")]
        public void Any_ShouldReturnResultOfAny()
        {
            //Arrange
            ICell[] cells = { Cell0 };
            CellCollection subject = new CellCollection(cells);

            //Act
            bool actual = subject.Any(cell => true);

            //Assert
            actual.Should().BeTrue();
        }
        [TestMethod, TestCategory("unit")]
        public void Where_ShouldReturnResultOfWhereIndex()
        {
            //Arrange
            ICell[] cells = { Cell0 };
            CellCollection subject = new CellCollection(cells);

            //Act
            IEnumerable<ICell> actual = subject.Where((cell, index) => true);

            //Assert
            actual.Should().BeEquivalentTo(cells);
        }

        [TestMethod, TestCategory("unit")]
        public void Where_ShouldReturnResultOfWhere()
        {
            //Arrange
            ICell[] cells = { Cell0 };
            CellCollection subject = new CellCollection(cells);

            //Act
            IEnumerable<ICell> actual = subject.Where(cell => false);

            //Assert
            actual.Count().Should().Be(0);
        }

        [TestMethod, TestCategory("unit")]
        public void WhereAny_ShouldReturnResultOfWhereAny()
        {
            //Arrange
            ICell[] cells = { Cell0 };
            CellCollection subject = new CellCollection(cells);

            //Act
            Bool actual = subject.WhereAny(cell => true);

            //Assert
            ((bool)actual).Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void At_ShouldReturnCellAt()
        {
            //Arrange
            ICell expected = Cell0;
            ICell[] cells = { expected };
            CellCollection subject = new CellCollection(cells);

            //Act
            ICell actual = subject.At(new IntOf(0));

            //Assert
            actual.Should().Be(expected);
        }

        [TestMethod, TestCategory("unit")]
        public void Count_ShouldReturnCount()
        {
            //Arrange
            ICell expected = Cell0;
            ICell[] cells = { expected };
            CellCollection subject = new CellCollection(cells);

            //Act
            Int actual = subject.Count();

            //Assert
            ((int)actual).Should().Be(1);
        }

        [TestMethod, TestCategory("unit")]
        public void All_ShouldReturnAllMatchCondition()
        {
            //Arrange
            ICell expected = Cell0;
            ICell[] cells = { expected };
            CellCollection subject = new CellCollection(cells);

            //Act
            bool actual = subject.All(cell => true);

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void Clone_ShouldClone()
        {
            //Arrange
            ICell expected = Cell0;
            ICell[] cells = { expected };
            CellCollection subject = new CellCollection(cells);

            //Act
            ICellCollection actual = subject.Clone();

            //Assert
            ReferenceEquals(subject, actual).Should().BeFalse();
            ReferenceEquals(subject.At(new IntOf(0)), actual.At(new IntOf(0))).Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void IEnumerableGetEnumerator_ShouldReturn()
        {
            //Arrange
            ICell expected = Cell0;
            ICell[] cells = { expected };
            CellCollection subject = new CellCollection(cells);

            //Act
            IEnumerator actual = ((IEnumerable)subject).GetEnumerator();

            //Assert
            actual.Should().NotBeNull();
        }
    }
}