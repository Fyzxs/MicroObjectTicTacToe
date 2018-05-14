using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Game;
using tictactoe.IO;
using TicTacToeTests.Fakes;
using TicTacToeTests.Validators;

namespace TicTacToeTests.Game
{
    [TestClass]
    public class ConsoleGameStartingTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldDisplayWelcome()
        {
            //Arrange
            FakeWriter fakeWriter = new FakeWriter();
            ConsoleGameStarting subject = new ConsoleGameStarting(fakeWriter);

            //Act
            subject.DisplayWelcome();

            //Assert
            fakeWriter.AssertLinesWritten("Welcome to Tic-Tac-Toe!");
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldPrintBoard()
        {
            //Arrange
            FakeWriter fakeWriter = new FakeWriter();
            ConsoleGameStarting subject = new ConsoleGameStarting(fakeWriter);
            FakeBoard fakeBoard = new FakeBoard.Builder().Print().Build();
            //Act
            subject.DisplayInitialBoard(fakeBoard);

            //Assert
            fakeBoard.AssertPrintInvoked();
        }

        [TestMethod, TestCategory("functional")]
        public void ShouldValidateTheVariables()
        {
            //Arrange
            ClassVariableTypeValidation classVariableTypeValidation = new ClassVariableTypeValidation()
                .Add<ConsoleWriterBookEnd>("_writer");

            //Act
            ConsoleGameStarting subject = new ConsoleGameStarting();

            //Assert
            classVariableTypeValidation.AssertExpectedVariables(subject);
        }
    }
}
