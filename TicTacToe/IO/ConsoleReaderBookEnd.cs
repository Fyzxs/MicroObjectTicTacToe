using System;

namespace tictactoe.IO
{
    public sealed class ConsoleReaderBookEnd : IReader
    {
        public static IReader TestReader;

        public string ReadLine() => TestReader == null
            ? Console.ReadLine()
            : TestReader.ReadLine();
    }

    public interface IReader
    {
        string ReadLine();
    }
}