using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using tictactoe.IO;

namespace TicTacToeTests.Fakes
{
    public class FakeWriter : IWriter
    {
        private readonly List<string> _lines = new List<string>();

        public void WriteLine(string line) => _lines.Add(line);
        public void Write(string line) => _lines.Add(line);

        public void AssertLinesWritten(params string[] expectedLines)
        {
            for (int index = 0; index < expectedLines.Length; index++)
            {
                _lines[index].Should().Be(expectedLines[index]);
            }
        }

        public void AssertLastLine(string expected) => _lines.Last().Should().Be(expected);

        public void AssertWriteInvokedCountMatches(int expected) => _lines.Count.Should().Be(expected);
    }
}