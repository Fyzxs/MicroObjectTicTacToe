using tictactoe.Boards;
using tictactoe.IO;

namespace tictactoe.Game
{
    public sealed class ConsoleGameStarting : IGameStarting
    {
        private readonly IWriter _writer;

        public ConsoleGameStarting() : this(new ConsoleWriterBookEnd()) { }

        public ConsoleGameStarting(IWriter writer) => _writer = writer;

        public void DisplayWelcome() => _writer.WriteLine("Welcome to Tic-Tac-Toe!");

        public void DisplayInitialBoard(IBoard board) => board.Print();
    }

    public interface IGameStarting
    {
        void DisplayWelcome();
        void DisplayInitialBoard(IBoard board);
    }
}