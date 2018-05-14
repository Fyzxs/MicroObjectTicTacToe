using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.Cells;
using tictactoe.IO;
using tictactoe.Players.Moves;
using TicTacToeTests.Fakes;
using TicTacToeTests.Validators;

namespace TicTacToeTests.Players.Moves
{
    [TestClass]
    public class HumanMoveInputTests
    {
        [TestMethod, TestCategory("unit")]
        public void Input_ShouldWritePrompt()
        {
            //Arrange
            FakeCell fakeCell = new FakeCell.Builder().Value("?").Build();
            FakeValidResponse<IGlyph> fakeValidResponse = new FakeValidResponse<IGlyph>.Builder().Response(null).Build();
            FakeWriter fakeWriter = new FakeWriter();
            HumanMoveInput subject = new HumanMoveInput(fakeValidResponse, fakeWriter);

            //Act
            subject.Input(fakeCell);

            //Assert
            fakeWriter.AssertLinesWritten("Player ?'s Turn");

        }
        [TestMethod, TestCategory("unit")]
        public void ShouldValidateDependencyConstructors()
        {
            new ClassVariableTypeValidation()
                .Add<ValidResponse<IGlyph>>("_validResponse")
                .Add<ConsoleWriterBookEnd>("_writer")
                .AssertExpectedVariables(new HumanMoveInput());
        }
    }
}