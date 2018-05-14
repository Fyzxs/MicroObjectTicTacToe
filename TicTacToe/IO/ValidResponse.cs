using tictactoe.Library.Bools;
using tictactoe.Library.Regexs;

namespace tictactoe.IO
{
    public sealed class ValidResponse<T> : IValidResponse<T>
    {

        private readonly IRegexBookEnd _acceptedInput;
        private readonly string[] _promptLines;
        private readonly IValidInputResponseAction<T> _responseAction;
        private readonly IReader _reader;
        private readonly IWriter _writer;

        public ValidResponse(string regexPattern, string[] promptLines, IValidInputResponseAction<T> responseAction) : this(new RegexBookEnd(regexPattern), promptLines, responseAction) { }
        public ValidResponse(IRegexBookEnd acceptedInput, string[] promptLines, IValidInputResponseAction<T> responseAction) : this(acceptedInput, promptLines, responseAction, new ConsoleWriterBookEnd(), new ConsoleReaderBookEnd()) { }
        public ValidResponse(IRegexBookEnd acceptedInput, string[] promptLines, IValidInputResponseAction<T> responseAction, IWriter writer, IReader reader)
        {
            _acceptedInput = acceptedInput;
            _promptLines = promptLines;
            _responseAction = responseAction;
            _writer = writer;
            _reader = reader;
        }

        public T Response()
        {
            string input;
            Prompt();
            if (Valid(input = Receive())) return _responseAction.Response(input);

            return UserInputLoop(input);
        }

        private T UserInputLoop(string previousInput)
        {
            string input = previousInput;
            do
            {
                InvalidPrompt(input);
                Prompt();
            }
            while (Invalid(input = Receive()));

            return _responseAction.Response(input);
        }
        private string Receive()
        {
            string readLine = _reader.ReadLine();
            _writer.WriteLine("");
            return readLine;
        }
        private void Prompt()
        {
            foreach (string promptLine in _promptLines)
            {
                _writer.WriteLine(promptLine);
            }
        }
        private Bool Valid(string line) => _acceptedInput.IsMatch(line);
        private Bool Invalid(string line) => Valid(line).Not();
        private void InvalidPrompt(string input) => _writer.WriteLine($"Your selection '{input}' is not valid.");
    }

    public interface IValidInputResponseAction<out T>
    {
        T Response(string validInput);
    }

    public interface IValidResponse<out T>
    {
        T Response();
    }
}