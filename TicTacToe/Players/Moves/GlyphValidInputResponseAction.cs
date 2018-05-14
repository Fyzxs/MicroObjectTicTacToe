using tictactoe.Cells;
using tictactoe.IO;

namespace tictactoe.Players.Moves
{
    public sealed class GlyphValidInputResponseAction : IValidInputResponseAction<IGlyph>
    {
        public IGlyph Response(string validInput) => new Glyph(validInput[0]);
    }
}