using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Library.Ints;

namespace TicTacToeTests.Library.Ints
{
    [TestClass]
    public class IntTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldIncrement()
        {
            //Arrange
            TestInt subject = new TestInt(0);

            //Act
            int actual = subject.Incremented();

            //Assert
            actual.Should().Be(1);
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldBeEqual()
        {
            //Arrange
            TestInt subject = new TestInt(1);

            //Act
            bool actual = subject.Equal(new IntOf(1));

            //Assert
            actual.Should().BeTrue();
        }

        private class TestInt : Int
        {
            private readonly int _val;

            public TestInt(int val) => _val = val;

            protected override int RawValue() => _val;
        }
    }
}