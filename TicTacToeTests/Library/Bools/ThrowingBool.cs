using System;
using tictactoe.Library.Bools;

namespace TicTacToeTests.Library.Bools {
    public class ThrowingBool : Bool
    {
        protected override bool RawValue() => throw new Exception("You shouldn't get this");
    }
}