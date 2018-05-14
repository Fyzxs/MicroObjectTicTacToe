using tictactoe.IO;
using tictactoe.Players.Difficulity;
using tictactoe.Players.Moves;

namespace tictactoe.Players.Creation
{
    public sealed class ComputerCreation : IPlayerCreation
    {
        private const string RegexPatternFormat = "^[1|2|3]$";
        private static readonly string[] PromptLineFormat = { "Select a difficulty level for computer '{0}':", "1) Easy", "2) Medium", "3) Hard" };
        private readonly IFormattedValidInput<ISelectMoveAction> _formattedValidInput;

        public ComputerCreation() : this(new FormattedValidInput<ISelectMoveAction>(RegexPatternFormat, PromptLineFormat, new DifficultySelectionAction())) { }

        public ComputerCreation(IFormattedValidInput<ISelectMoveAction> formattedValidInput) => _formattedValidInput = formattedValidInput;

        public IPlayer Player(string mark)
        {
            _formattedValidInput.AddPromptArg(mark);

            return new ComputerPlayer(mark[0], _formattedValidInput.ValidInput().Response());
        }
    }
}