using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.IO;
using tictactoe.Players;
using TicTacToeTests.Fakes;
using TicTacToeTests.Validators;

namespace TicTacToeTests.Players
{
    [TestClass]
    public class PlayerWinPrinterTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldPrintExpected()
        {
            //Arrange
            FakeWriter fakeWriter = new FakeWriter();
            FakeCell fakeCell = new FakeCell.Builder().Value("YEAH").Build();
            FakePlayer fakePlayer = new FakePlayer.Builder().Cell(fakeCell).Build();
            PlayerWinPrinter subject = new PlayerWinPrinter(fakePlayer, fakeWriter);

            //Act
            subject.Print();

            //Assert
            fakeWriter.AssertLastLine("Player 'YEAH' has won!");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldValidateDependencyConstructors()
        {
            new ClassVariableTypeValidation()
                .Add<ConsoleWriterBookEnd>("_writer")
                .AssertExpectedVariables(new PlayerWinPrinter(null));
        }
    }
}
