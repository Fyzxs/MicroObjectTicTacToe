using System.Collections.Generic;

namespace tictactoe.Library
{
    public sealed class DelayedFormat : IDelayedFormat
    {
        private readonly string _formatString;
        private readonly List<string> _formatArgs;

        public DelayedFormat(string formatString) : this(formatString, new List<string>()) { }

        private DelayedFormat(string formatString, List<string> formatArgs)
        {
            _formatString = formatString;
            _formatArgs = formatArgs;
        }

        public void Add(string value) => _formatArgs.Add(value);

        public string Value() => string.Format(_formatString, _formatArgs.ToArray());
    }
    public interface IDelayedFormat
    {
        void Add(string value);
        string Value();
    }
}