using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes;

namespace TicTacToeTests.Cells
{
    [TestClass]
    public class RandomCellTests
    {
        [TestMethod, TestCategory("unit")]
        public void IsSelected_ShouldCallThrough()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().IsSelected(Bool.True).Build();
            FakeSingleReservoirSample<ICell> fakeSingleReservoirSample = new FakeSingleReservoirSample<ICell>.Builder().Element(fakeCell).Build();
            RandomCell subject = new RandomCell(fakeSingleReservoirSample);

            //Act
            subject.IsSelected();

            //Assert
            fakeCell.AssertIsSelectedInvoked();
        }
        [TestMethod, TestCategory("unit")]
        public void AsSelected_ShouldCallThrough()
        {
            //Arrange
            FakeCell fakeCellSelected = new FakeCell.Builder().Build();
            FakeCell fakeCell = new FakeCell.Builder().AsSelected(fakeCellSelected).Build();
            FakeSingleReservoirSample<ICell> fakeSingleReservoirSample = new FakeSingleReservoirSample<ICell>.Builder().Element(fakeCell).Build();
            RandomCell subject = new RandomCell(fakeSingleReservoirSample);

            //Act
            subject.AsSelected();

            //Assert
            fakeCell.AssertAsSelectedInvoked();
        }
        [TestMethod, TestCategory("unit")]
        public void Value_ShouldCallThrough()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().Value("?").Build();
            FakeSingleReservoirSample<ICell> fakeSingleReservoirSample = new FakeSingleReservoirSample<ICell>.Builder().Element(fakeCell).Build();
            RandomCell subject = new RandomCell(fakeSingleReservoirSample);

            //Act
            subject.Value();

            //Assert
            fakeCell.AssertValueInvoked();
        }
    }
}
