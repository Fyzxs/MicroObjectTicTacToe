using tictactoe.Boards;
using tictactoe.Cells;
using tictactoe.GameMode.TurnOrder;
using tictactoe.IO;
using tictactoe.Players;
using tictactoe.Players.Creation;

namespace tictactoe.GameMode
{
    public sealed class HumanVsComputerGameMode : IGameMode
    {
        private const string AcceptedValues = "^[1|2]$";
        private static readonly string[] PromptLines = { "Would you like to go first or second?", "1) First", "2) Second", "" };

        private readonly IValidResponse<IPlayerOrder> _validResponse;
        private readonly IPlayerCreation _humanCreation;
        private readonly IPlayerCreation _computerCreation;

        public HumanVsComputerGameMode() : this(new ValidResponse<IPlayerOrder>(AcceptedValues, PromptLines, new PlayerTurnsOrderAction()), new OnlyHumanCreation(), new ComputerCreation()) { }
        public HumanVsComputerGameMode(IValidResponse<IPlayerOrder> validResponse, IPlayerCreation humanCreation, IPlayerCreation computerCreation)
        {
            _validResponse = validResponse;
            _humanCreation = humanCreation;
            _computerCreation = computerCreation;
        }

        public IPlayersTurns ConfigurePlayers(IBoard board)
        {
            IPlayer human = HumanPlayer();
            IPlayer computer = ComputerPlayer(human.Cell());

            return PlayersTurns(board, _validResponse.Response(), human, computer);
        }

        private static IPlayersTurns PlayersTurns(IBoard board, IPlayerOrder order, IPlayer human, IPlayer computer) =>
            order.HumanFirst()
                ? new PlayersTurns(board, human, computer)
                : new PlayersTurns(board, computer, human);
        private IPlayer HumanPlayer() => _humanCreation.Player(NullCell.Instance.Value());
        private IPlayer ComputerPlayer(ICell playerCell) => _computerCreation.Player(playerCell.Value() == "O" ? "X" : "O");
    }
}