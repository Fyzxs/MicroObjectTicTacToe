using tictactoe.IO;

namespace tictactoe.Players
{
    public sealed class PlayerWinPrinter : IPrinter
    {
        private readonly IPlayer _player;
        private readonly IWriter _writer;

        public PlayerWinPrinter(IPlayer player) : this(player, new ConsoleWriterBookEnd()) { }

        public PlayerWinPrinter(IPlayer player, IWriter writer)
        {
            _player = player;
            _writer = writer;
        }

        public void Print() => _writer.WriteLine($"Player '{_player.Cell().Value()}' has won!");
    }
}