using tictactoe.Library;

namespace tictactoe.IO
{
    public sealed class FormattedValidInput<T> : IFormattedValidInput<T>
    {
        private readonly IDelayedFormat _regexPatternFormat;
        private readonly IDelayedArrayFormat _promptLineFormat;
        private readonly IValidInputResponseAction<T> _action;

        public FormattedValidInput(string regexPatternFormat, string promptLineFormat, IValidInputResponseAction<T> action) :
            this(regexPatternFormat, new[] { promptLineFormat }, action)
        { }
        public FormattedValidInput(string regexPatternFormat, string[] promptLineFormat, IValidInputResponseAction<T> action) :
            this(new DelayedFormat(regexPatternFormat), new DelayedArrayFormat(promptLineFormat), action)
        { }
        public FormattedValidInput(IDelayedFormat regexPatternFormat, IDelayedArrayFormat promptLineFormat, IValidInputResponseAction<T> action)
        {
            _regexPatternFormat = regexPatternFormat;
            _promptLineFormat = promptLineFormat;
            _action = action;
        }

        public void AddPatternArg(string arg) => _regexPatternFormat.Add(arg);

        public void AddPromptArg(string arg) => _promptLineFormat.Add(arg);

        public IValidResponse<T> ValidInput() => new ValidResponse<T>(_regexPatternFormat.Value(), _promptLineFormat.Value(), _action);
    }

    public interface IFormattedValidInput<out T>
    {
        void AddPatternArg(string arg);
        void AddPromptArg(string arg);
        IValidResponse<T> ValidInput();
    }
}