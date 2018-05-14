using tictactoe.Cells;
using tictactoe.IO;

namespace tictactoe.Players.Moves
{
    public sealed class HumanMoveInput : IMoveInput
    {
        private static readonly string[] Prompt = { "Please select a value [0-8]:" };
        private const string AcceptedInput = "^[0|1|2|3|4|5|6|7|8]$";

        private readonly IValidResponse<IGlyph> _validResponse;
        private readonly IWriter _writer;

        public HumanMoveInput() : this(new ValidResponse<IGlyph>(AcceptedInput, Prompt, new GlyphValidInputResponseAction()), new ConsoleWriterBookEnd()) { }

        public HumanMoveInput(IValidResponse<IGlyph> validResponse, IWriter writer)
        {
            _validResponse = validResponse;
            _writer = writer;
        }

        public IGlyph Input(ICell playerCell)
        {
            _writer.WriteLine($"Player {playerCell.Value()}'s Turn");
            return _validResponse.Response();
        }
    }

    public interface IMoveInput
    {
        IGlyph Input(ICell playerCell);
    }
}