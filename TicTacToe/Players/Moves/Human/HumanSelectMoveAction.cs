using tictactoe.Boards;
using tictactoe.Cells;

namespace tictactoe.Players.Moves.Human
{
    public sealed class HumanSelectMoveAction : ISelectMoveAction
    {
        private readonly IMoveInput _moveInput;
        public HumanSelectMoveAction() : this(new HumanMoveInput()) { }
        public HumanSelectMoveAction(IMoveInput moveInput) => _moveInput = moveInput;

        public ICell Act(IBoard board, IPlayer thisPlayer, IPlayer otherPlayer)
        {
            while (true)
            {
                ICell cell = SelectedCell(thisPlayer.Cell());
                if (board.Available(cell)) return cell;
            }
        }

        private ICell SelectedCell(ICell cell) => new UnselectedCell(_moveInput.Input(cell));
    }
}