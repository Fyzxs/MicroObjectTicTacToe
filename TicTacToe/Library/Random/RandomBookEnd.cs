using tictactoe.Library.Ints;

namespace tictactoe.Library.Random
{
    public sealed class RandomBookEnd : IRandomBookEnd
    {
        private static readonly System.Random Generator = new System.Random();

        public Int NextInt(Int inclusiveMin, Int exclusiveMax) => new IntOf(Generator.Next(inclusiveMin, exclusiveMax));
    }

    public interface IRandomBookEnd
    {
        Int NextInt(Int inclusiveMin, Int exclusiveMax);
    }
}