using System.Diagnostics;
using tictactoe.Library.Bools;

namespace tictactoe.Cells
{
    [DebuggerDisplay("Cell=[{_glyph.Value()}]")]
    public abstract class Cell : ICell
    {
        protected static readonly object Selected = new object();
        protected static readonly object Unselected = new object();

        private readonly IGlyph _glyph;
        private readonly object _selection;

        protected Cell(IGlyph glyph, object selection)
        {
            _glyph = glyph;
            _selection = selection;
        }

        public string Value() => _glyph.Value();

        public Bool IsSelected() => new ReferenceEquals(_selection, Selected);

        public ICell AsSelected() => IsSelected() ? this : new SelectedCell(_glyph);
    }

    [DebuggerDisplay("SelectedCell=[{_glyph.Value()}]")]
    public sealed class SelectedCell : Cell
    {
        public SelectedCell(IGlyph glyph) : base(glyph, Selected) { }
    }

    [DebuggerDisplay("UnselectedCell=[{_glyph.Value()}]")]
    public sealed class UnselectedCell : Cell
    {
        public UnselectedCell(IGlyph glyph) : base(glyph, Unselected) { }
    }
}