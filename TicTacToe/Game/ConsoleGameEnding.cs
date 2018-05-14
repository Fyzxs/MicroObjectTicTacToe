using tictactoe.IO;

namespace tictactoe.Game
{
    public sealed class ConsoleGameEnding : IGameEnding
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        public ConsoleGameEnding() : this(new ConsoleReaderBookEnd(), new ConsoleWriterBookEnd()) { }

        public ConsoleGameEnding(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public void Display()
        {
            _writer.WriteLine("Game over");
            _writer.WriteLine("Press Enter to Exit");
            _reader.ReadLine();
        }
    }

    public interface IGameEnding
    {
        void Display();
    }
}