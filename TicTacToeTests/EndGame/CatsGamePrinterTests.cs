using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.EndGame;
using tictactoe.IO;
using TicTacToeTests.Fakes;
using TicTacToeTests.Validators;

namespace TicTacToeTests.EndGame
{
    [TestClass]
    public class CatsGamePrinterTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldPrintExpected()
        {
            //Arrange
            FakeWriter fakeWriter = new FakeWriter();
            CatsGamePrinter subject = new CatsGamePrinter(fakeWriter);

            //Act
            subject.Print();

            //Assert
            fakeWriter.AssertLastLine("It's a draw!");
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldValidateDependencyConstructors()
        {
            new ClassVariableTypeValidation()
                .Add<ConsoleWriterBookEnd>("_writer")
                .AssertExpectedVariables(new CatsGamePrinter());
        }
    }
}
