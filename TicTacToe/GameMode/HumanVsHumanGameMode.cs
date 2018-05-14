using tictactoe.Boards;
using tictactoe.Cells;
using tictactoe.Players;
using tictactoe.Players.Creation;

namespace tictactoe.GameMode
{
    public sealed class HumanVsHumanGameMode : IGameMode
    {
        private readonly IPlayerCreation _firstPlayerCreation;
        private readonly IPlayerCreation _secondPlayerCreation;

        public HumanVsHumanGameMode() : this(new FirstHumanCreation(), new SecondHumanCreation()) { }

        public HumanVsHumanGameMode(IPlayerCreation firstPlayerCreation, IPlayerCreation secondPlayerCreation)
        {
            _firstPlayerCreation = firstPlayerCreation;
            _secondPlayerCreation = secondPlayerCreation;
        }

        public IPlayersTurns ConfigurePlayers(IBoard board)
        {
            IPlayer firstPlayer = _firstPlayerCreation.Player(NullCell.Instance.Value());
            IPlayer secondPlayer = _secondPlayerCreation.Player(firstPlayer.Cell().Value());

            return new PlayersTurns(board, firstPlayer, secondPlayer);
        }
    }
}