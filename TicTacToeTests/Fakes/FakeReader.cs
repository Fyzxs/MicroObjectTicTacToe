using FluentAssertions;
using tictactoe.IO;

namespace TicTacToeTests.Fakes
{
    public class FakeReader : IReader
    {
        private readonly string[] _lines;
        private int _lineCounter;

        public FakeReader(params string[] lines) => _lines = lines;

        public string ReadLine() => _lines[_lineCounter++];

        public void AssertReadLineInvoked() => _lineCounter.Should().BeGreaterThan(0);
    }
}