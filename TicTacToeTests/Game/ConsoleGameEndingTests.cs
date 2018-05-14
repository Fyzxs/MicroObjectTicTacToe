using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using tictactoe.Game;
using tictactoe.IO;
using TicTacToeTests.Fakes;
using TicTacToeTests.Validators;

namespace TicTacToeTests.Game
{
    [TestClass]
    public class ConsoleGameEndingTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldPrintOutGameOverAndWaitForInput()
        {
            //Arrange
            FakeWriter fakeWriter = new FakeWriter();
            FakeReader fakeReader = new FakeReader(Environment.NewLine);
            ConsoleGameEnding subject = new ConsoleGameEnding(fakeReader, fakeWriter);

            //Act
            subject.Display();

            //Assert
            fakeWriter.AssertLinesWritten("Game over", "Press Enter to Exit");
            fakeReader.AssertReadLineInvoked();
        }

        [TestMethod, TestCategory("functional")]
        public void ShouldValidateTheVariables()
        {
            //Arrange
            ClassVariableTypeValidation classVariableTypeValidation = new ClassVariableTypeValidation()
                .Add<ConsoleReaderBookEnd>("_reader");

            //Act
            ConsoleGameEnding subject = new ConsoleGameEnding();

            //Assert
            classVariableTypeValidation.AssertExpectedVariables(subject);
        }
    }
}