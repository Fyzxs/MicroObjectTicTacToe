namespace tictactoe.Cells
{
    public sealed class Glyph : IGlyph
    {
        private readonly char _symbol;

        public Glyph(char symbol) => _symbol = symbol;

        public string Value() => _symbol.ToString();
    }

    public interface IGlyph
    {
        string Value();
    }
}