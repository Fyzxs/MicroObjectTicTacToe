using tictactoe.IO;

namespace tictactoe.Players.Creation
{
    public sealed class HumanPlayerValidInputResponseAction : IValidInputResponseAction<IPlayer>
    {
        public IPlayer Response(string validInput) => new HumanPlayer(validInput[0]);
    }
}