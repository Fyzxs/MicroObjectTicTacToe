using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells.Bools;
using tictactoe.Library.Ints;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Cells.Bools
{
    [TestClass]
    public class IndexedCellEqualityTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldInvokeIndexes()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().Value("").Build();
            FakeCellCollection fakeCellCollection = new FakeCellCollection.Builder().At(fakeCell).Build();
            Int indexOne = new IntOf(1);
            Int indexTwo = new IntOf(2);
            IndexedCellEquality subject = new IndexedCellEquality(fakeCellCollection, indexOne, indexTwo);

            //Act
            bool actual = subject;

            //Assert
            fakeCellCollection.AssertAtInvokedWith(indexOne, indexTwo);
        }
    }
}
