using tictactoe.Library.Bools;

namespace tictactoe.GameMode.TurnOrder
{
    public interface IPlayerOrder
    {
        Bool HumanFirst();
    }
    public sealed class HumanFirstOrder : IPlayerOrder
    {
        public Bool HumanFirst() => Bool.True;
    }

    public sealed class ComputerFirstOrder : IPlayerOrder
    {
        public Bool HumanFirst() => Bool.False;
    }
}