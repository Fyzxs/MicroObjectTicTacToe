using tictactoe.Library.Bools;

namespace tictactoe.Cells
{
    public sealed class NullCell : ICell
    {
        public static readonly ICell Instance = new NullCell();

        private NullCell() { }

        public string Value() => string.Empty;

        public Bool IsSelected() => Bool.True;

        public ICell AsSelected() => this;
    }
}