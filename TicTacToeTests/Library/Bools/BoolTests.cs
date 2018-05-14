using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Library.Bools;

namespace TicTacToeTests.Library.Bools
{
    [TestClass]
    public class BoolTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnTrueAsTrue()
        {
            //Arrange
            Bool subject = new TestBool(true);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldReturnFalseAsFalse()
        {
            //Arrange
            Bool subject = new TestBool(false);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldReturnFalseAsTrueNot()
        {
            //Arrange
            Bool subject = new TestBool(true);

            //Act
            bool actual = subject.Not();

            //Assert
            actual.Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldReturnFalseAsTrueAndFalse()
        {
            //Arrange
            Bool subject = new TestBool(true);

            //Act
            bool actual = subject.And(Bool.False);

            //Assert
            actual.Should().BeFalse();
        }

        private class TestBool : Bool
        {
            private readonly bool _origin;

            public TestBool(bool origin) => _origin = origin;

            protected override bool RawValue() => _origin;
        }
    }
}
