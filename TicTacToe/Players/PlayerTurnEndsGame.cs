using tictactoe.Boards;
using tictactoe.EndGame.Actions.Player;
using tictactoe.Library.Bools;

namespace tictactoe.Players
{
    public sealed class PlayerTurnEndsGame : Bool
    {
        private readonly IBoard _board;
        private readonly IPlayer _activePlayer;
        private readonly IPlayer _inactivePlayer;
        private readonly IPlayerEndsGameAction _playerActionCommand;
        public PlayerTurnEndsGame(IBoard board, IPlayer activePlayer, IPlayer inactivePlayer) :
            this(board, activePlayer, inactivePlayer, new PlayerEndsGameAction())
        { }
        public PlayerTurnEndsGame(IBoard board, IPlayer activePlayer, IPlayer inactivePlayer, IPlayerEndsGameAction playerActionCommand)
        {
            _board = board;
            _activePlayer = activePlayer;
            _inactivePlayer = inactivePlayer;
            _playerActionCommand = playerActionCommand;
        }

        protected override bool RawValue() => _playerActionCommand.Act(_board, _activePlayer, _inactivePlayer);
    }
}