using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Library;

namespace TicTacToeTests.Library {
    [TestClass]
    public class DelayedFormatTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldFormatEachLineWithArgs()
        {
            //Arrange
            DelayedFormat subject = new DelayedFormat("zero{0}three{3}");
            subject.Add("0");
            subject.Add("1");
            subject.Add("2");
            subject.Add("3");

            //Act
            string actual = subject.Value();

            //Assert
            actual.Should().Be("zero0three3");
        }
    }
}