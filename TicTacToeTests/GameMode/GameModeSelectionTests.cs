using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe.GameMode;
using tictactoe.IO;
using TicTacToeTests.Fakes;
using TicTacToeTests.Validators;

namespace TicTacToeTests.GameMode
{
    [TestClass]
    public class GameModeSelectionTests
    {

        [TestMethod, TestCategory("functional")]
        public void ShouldValidateTheVariables()
        {
            //Arrange
            ClassVariableTypeValidation classVariableTypeValidation = new ClassVariableTypeValidation()
                .Add<ValidResponse<IGameMode>>("_validResponse");

            //Act
            GameModeSelection subject = new GameModeSelection();

            //Assert
            classVariableTypeValidation.AssertExpectedVariables(subject);
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldGetGameModeFromInput()
        {
            //Arrange
            FakeGameMode fakeGameMode = new FakeGameMode.Builder().Build();
            FakeValidResponse<IGameMode> fakeValidResponse = new FakeValidResponse<IGameMode>.Builder().Response(fakeGameMode).Build();

            GameModeSelection subject = new GameModeSelection(fakeValidResponse);

            //Act
            IGameMode gameMode = subject.Select();

            //Assert
            gameMode.Should().Be(fakeGameMode);
        }
    }
}