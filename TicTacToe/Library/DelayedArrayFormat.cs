using System.Collections.Generic;

namespace tictactoe.Library
{
    public sealed class DelayedArrayFormat : IDelayedArrayFormat
    {
        private readonly string[] _promptLineFormat;
        private readonly List<string> _args;

        public DelayedArrayFormat(string[] promptLineFormat) : this(promptLineFormat, new List<string>()) { }

        private DelayedArrayFormat(string[] promptLineFormat, List<string> args)
        {
            _promptLineFormat = promptLineFormat;
            _args = args;
        }

        public void Add(string arg) => _args.Add(arg);

        public string[] Value()
        {
            string[] formatted = new string[_promptLineFormat.Length];
            string[] args = _args.ToArray();
            for (int index = 0; index < _promptLineFormat.Length; index++)
            {
                formatted[index] = string.Format(_promptLineFormat[index], args);
            }

            return formatted;
        }
    }

    public interface IDelayedArrayFormat
    {
        void Add(string arg);
        string[] Value();
    }
}