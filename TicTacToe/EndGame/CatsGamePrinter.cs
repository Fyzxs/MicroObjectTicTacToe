using tictactoe.IO;

namespace tictactoe.EndGame
{
    public sealed class CatsGamePrinter : IPrinter
    {
        private readonly IWriter _writer;

        public CatsGamePrinter() : this(new ConsoleWriterBookEnd()) { }

        public CatsGamePrinter(IWriter writer) => _writer = writer;

        public void Print() => _writer.WriteLine("It's a draw!");
    }
}