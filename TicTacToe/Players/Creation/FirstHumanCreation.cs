using tictactoe.IO;

namespace tictactoe.Players.Creation
{
    public sealed class FirstHumanCreation : IPlayerCreation
    {
        private readonly IValidResponse<IPlayer> _validResponse;
        public const string AcceptedInput = "^.$";
        public static readonly string[] PromptLines = { "Player One: Select a single character for your mark:" };

        public FirstHumanCreation() : this(new ValidResponse<IPlayer>(AcceptedInput, PromptLines, new HumanPlayerValidInputResponseAction())) { }

        public FirstHumanCreation(IValidResponse<IPlayer> validResponse) => _validResponse = validResponse;

        public IPlayer Player(string mark) => _validResponse.Response();
    }
}