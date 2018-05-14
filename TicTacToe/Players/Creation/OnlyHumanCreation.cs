using tictactoe.IO;

namespace tictactoe.Players.Creation
{
    public sealed class OnlyHumanCreation : IPlayerCreation
    {
        public const string AcceptedInput = "^.$";
        public static readonly string[] PromptLines = { "Select a single character for your mark:" };

        private readonly IValidResponse<IPlayer> _validResponse;

        public OnlyHumanCreation() : this(new ValidResponse<IPlayer>(AcceptedInput, PromptLines, new HumanPlayerValidInputResponseAction())) { }

        public OnlyHumanCreation(IValidResponse<IPlayer> validResponse) => _validResponse = validResponse;

        public IPlayer Player(string mark) => _validResponse.Response();
    }
}