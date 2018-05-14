using tictactoe.Boards;
using tictactoe.Game;
using tictactoe.GameMode;
using tictactoe.Players;

namespace tictactoe
{
    public sealed class TicTacToeGame
    {
        private readonly IBoard _board;
        private readonly IGameModeSelection _gameModeSelection;
        private readonly IGameStarting _starting;
        private readonly IGameEnding _ending;

        public TicTacToeGame() : this(new Board()) { }
        private TicTacToeGame(IBoard board) : this(board, new GameModeSelection(), new ConsoleGameStarting(), new ConsoleGameEnding()) { }

        public TicTacToeGame(IBoard board, IGameModeSelection gameModeSelection, IGameStarting starting, IGameEnding ending)
        {
            _board = board;
            _gameModeSelection = gameModeSelection;
            _starting = starting;
            _ending = ending;
        }

        public void Run()
        {
            _starting.DisplayWelcome();

            IPlayersTurns playersTurns = _gameModeSelection.Select().ConfigurePlayers(_board);

            _starting.DisplayInitialBoard(_board);

            while (playersTurns.GameOver().Not()) { }

            _ending.Display();
        }
    }
}