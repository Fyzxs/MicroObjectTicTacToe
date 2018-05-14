using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Library;

namespace TicTacToeTests.Library
{
    [TestClass]
    public class DelayedArrayFormatTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldFormatEachLineWithArgs()
        {
            //Arrange
            DelayedArrayFormat subject = new DelayedArrayFormat(new[] { "zero{0}three{3}", "one{1}", "two{2}" });
            subject.Add("0");
            subject.Add("1");
            subject.Add("2");
            subject.Add("3");

            //Act
            string[] actual = subject.Value();

            //Assert
            actual[0].Should().Be("zero0three3");
            actual[1].Should().Be("one1");
            actual[2].Should().Be("two2");
        }
    }
}