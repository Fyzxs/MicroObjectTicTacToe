using tictactoe.GameMode.Actions;
using tictactoe.IO;

namespace tictactoe.GameMode
{
    public sealed class GameModeSelection : IGameModeSelection
    {
        private readonly IValidResponse<IGameMode> _validResponse;
        private const string AcceptedInput = "^[1|2|3]$";
        private static readonly string[] PromptLines = { "Please select the Game Mode:", "1) Human vs Computer", "2) Human vs Human", "3) Computer vs Computer" };

        public GameModeSelection() : this(new ValidResponse<IGameMode>(AcceptedInput, PromptLines, new GameModeSelectionAction())) { }

        public GameModeSelection(IValidResponse<IGameMode> validResponse) => _validResponse = validResponse;

        public IGameMode Select() => _validResponse.Response();
    }

    public interface IGameModeSelection
    {
        IGameMode Select();
    }
}