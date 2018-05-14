using System;

namespace tictactoe.IO
{
    public sealed class ConsoleWriterBookEnd : IWriter
    {
        public static IWriter TestWriter;

        public void WriteLine(string line)
        {
            if (Shim(line, l => TestWriter.WriteLine(l))) return;

            Console.WriteLine(line);
        }

        public void Write(string line)
        {
            if (Shim(line, l => TestWriter.Write(l))) return;

            Console.Write(line);
        }

        private static bool Shim(string line, Action<string> call)
        {
            if (TestWriter == null) return false;
            call(line);
            return true;
        }
    }

    public interface IWriter
    {
        void WriteLine(string line);
        void Write(string line);
    }
}