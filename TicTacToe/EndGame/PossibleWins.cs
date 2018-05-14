using tictactoe.Cells;
using tictactoe.Library.Bools;

namespace tictactoe.EndGame
{
    public sealed class PossibleWins : IWin
    {
        private readonly IWin[] _wins;

        public PossibleWins(ICellCollection cells) : this(
            new TopRightSlashWin(cells),
            new TopLeftSlashWin(cells),
            new RightColumnWin(cells),
            new CenterColumnWin(cells),
            new LeftColumnWin(cells),
            new BottomRowWin(cells),
            new CenterRowWin(cells),
            new TopRowWin(cells))
        { }

        public PossibleWins(params IWin[] wins) => _wins = wins;

        public Bool IsWin() => new Any<IWin>(_wins, win => win.IsWin());
    }
}