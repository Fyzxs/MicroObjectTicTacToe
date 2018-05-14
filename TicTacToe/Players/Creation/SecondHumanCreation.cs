using tictactoe.IO;

namespace tictactoe.Players.Creation
{
    public sealed class SecondHumanCreation : IPlayerCreation
    {
        private const string AcceptedInputFormat = "^[^{0}]$";
        private const string PromptLineFormat = "Player Two: Select a single character (other than {0}) for your mark:";

        private readonly IFormattedValidInput<IPlayer> _formatedValidInput;

        public SecondHumanCreation() : this(new FormattedValidInput<IPlayer>(AcceptedInputFormat, PromptLineFormat, new HumanPlayerValidInputResponseAction())) { }

        public SecondHumanCreation(IFormattedValidInput<IPlayer> formatedValidInput) => _formatedValidInput = formatedValidInput;

        public IPlayer Player(string mark)
        {
            _formatedValidInput.AddPatternArg(mark);
            _formatedValidInput.AddPromptArg(mark);
            return _formatedValidInput.ValidInput().Response();
        }
    }
}