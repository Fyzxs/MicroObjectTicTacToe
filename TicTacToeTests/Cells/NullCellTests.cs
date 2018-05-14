using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;

namespace TicTacToeTests.Cells
{
    [TestClass]
    public class NullCellTests
    {
        [TestMethod, TestCategory("unit")]
        public void Value_ShouldBeEmptyString()
        {
            NullCell.Instance.Value().Should().Be(string.Empty);
        }

        [TestMethod, TestCategory("unit")]
        public void IsSelected_ShouldBeTrue()
        {
            ((bool)NullCell.Instance.IsSelected()).Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void AsSelected_ShouldBeSelf()
        {
            NullCell.Instance.AsSelected().Should().Be(NullCell.Instance);
        }
    }
}
