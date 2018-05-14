using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe;
using tictactoe.Boards;
using tictactoe.Game;
using tictactoe.GameMode;
using tictactoe.Library.Bools;
using TicTacToeTests.Fakes;
using TicTacToeTests.Validators;

namespace TicTacToeTests
{
    [TestClass]
    public class TicTacToeTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldRunTheLoop()
        {
            //Arrange
            FakeBoard fakeBoard = new FakeBoard.Builder().Build();
            FakePlayersTurns fakePlayersTurns = new FakePlayersTurns.Builder().GameOver(Bool.True).Build();
            FakeGameMode fakeGameMode = new FakeGameMode.Builder().ConfigurePlayers(fakePlayersTurns).Build();
            FakeGameModeSelection fakeGameModeSelection = new FakeGameModeSelection.Builder().Select(fakeGameMode).Build();
            FakeGameStarting fakeGameStarting = new FakeGameStarting.Builder().DisplayWelcome().DisplayInitialBoard().Build();
            FakeGameEnding fakeGameEnding = new FakeGameEnding.Builder().Display().Build();
            TicTacToeGame subject = new TicTacToeGame(fakeBoard, fakeGameModeSelection, fakeGameStarting, fakeGameEnding);

            //Act
            subject.Run();

            //Assert
            fakeGameStarting.AssertDisplayWelcomeInvoked();
            fakeGameModeSelection.AssertSelectInvoked();
            fakeGameMode.AssertConfigurePlayersInvokedWith(fakeBoard);
            fakeGameStarting.AssertDisplayInitialBoardInvoked();
            fakePlayersTurns.AssertGameOverInvokedCountMatches(1);
            fakeGameEnding.AssertDisplayInvoked();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldRunTheLoopMultipleTimes()
        {
            //Arrange
            FakeBoard fakeBoard = new FakeBoard.Builder().Build();
            FakePlayersTurns fakePlayersTurns = new FakePlayersTurns.Builder().GameOver(Bool.False, Bool.False, Bool.False, Bool.True).Build();
            FakeGameMode fakeGameMode = new FakeGameMode.Builder().ConfigurePlayers(fakePlayersTurns).Build();
            FakeGameModeSelection fakeGameModeSelection = new FakeGameModeSelection.Builder().Select(fakeGameMode).Build();
            FakeGameStarting fakeGameStarting = new FakeGameStarting.Builder().DisplayWelcome().DisplayInitialBoard().Build();
            FakeGameEnding fakeGameEnding = new FakeGameEnding.Builder().Display().Build();
            TicTacToeGame subject = new TicTacToeGame(fakeBoard, fakeGameModeSelection, fakeGameStarting, fakeGameEnding);

            //Act
            subject.Run();

            //Assert
            fakePlayersTurns.AssertGameOverInvokedCountMatches(4);
        }

        [TestMethod, TestCategory("functional")]
        public void ShouldValidateTheVariables()
        {
            //Arrange
            ClassVariableTypeValidation classVariableTypeValidation = new ClassVariableTypeValidation()
                .Add<Board>("_board")
                .Add<ConsoleGameEnding>("_ending")
                .Add<GameModeSelection>("_gameModeSelection")
                .Add<ConsoleGameStarting>("_starting");

            //Act
            TicTacToeGame subject = new TicTacToeGame();

            //Assert
            classVariableTypeValidation.AssertExpectedVariables(subject);
        }
    }
}
