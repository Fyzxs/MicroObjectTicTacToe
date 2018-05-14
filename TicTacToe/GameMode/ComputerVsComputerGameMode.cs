using tictactoe.Boards;
using tictactoe.Players;
using tictactoe.Players.Creation;

namespace tictactoe.GameMode
{
    public sealed class ComputerVsComputerGameMode : IGameMode
    {
        private readonly IPlayerCreation _computerCreation;

        public ComputerVsComputerGameMode() : this(new ComputerCreation()) { }
        public ComputerVsComputerGameMode(IPlayerCreation computerCreation) => _computerCreation = computerCreation;
        public IPlayersTurns ConfigurePlayers(IBoard board) => new PlayersTurns(board,
            _computerCreation.Player("O"),
            _computerCreation.Player("X"));
    }
}