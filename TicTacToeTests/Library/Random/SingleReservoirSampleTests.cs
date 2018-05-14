using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using tictactoe.Library.Ints;
using tictactoe.Library.Random;
using TicTacToeTests.Fakes;
using TicTacToeTests.Validators;

namespace TicTacToeTests.Library.Random
{
    [TestClass]
    public class SingleReservoirSampleTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnSampledValue()
        {
            //Arrange
            List<string> initial = new List<string> { "a", "b", "c", "d" };
            FakeRandomBookEnd fakeRandomBookEnd = new FakeRandomBookEnd.Builder().NextInt(new IntOf(0), new IntOf(1), new IntOf(0), new IntOf(1)).Build();
            SingleReservoirSample<string> subject = new SingleReservoirSample<string>(initial, "DEFAULT", fakeRandomBookEnd);

            //Act
            string actual = subject.Element();

            //Assert
            actual.Should().Be("c");
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnFirstIfNeverChurned()
        {
            //Arrange
            FakeRandomBookEnd fakeRandomBookEnd = new FakeRandomBookEnd.Builder().NextInt(new IntOf(1)).Build();
            SingleReservoirSample<string> subject = new SingleReservoirSample<string>(new List<string>(), "DEFAULT", fakeRandomBookEnd);

            //Act
            string actual = subject.Element();

            //Assert
            actual.Should().Be("DEFAULT");
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnDefaultGivenNoElements()
        {
            //Arrange
            FakeRandomBookEnd fakeRandomBookEnd = new FakeRandomBookEnd.Builder().Build();
            SingleReservoirSample<string> subject = new SingleReservoirSample<string>(new List<string>(), "DEFAULT", fakeRandomBookEnd);

            //Act
            string actual = subject.Element();

            //Assert
            actual.Should().Be("DEFAULT");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldValidateDependencyConstructors()
        {
            new ClassVariableTypeValidation()
                .Add<RandomBookEnd>("_randomBookEnd")
                .AssertExpectedVariables(new SingleReservoirSample<string>(null, null));
        }
    }
}
