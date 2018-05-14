using System.Text.RegularExpressions;
using tictactoe.Library.Bools;

namespace tictactoe.Library.Regexs
{
    public sealed class RegexBookEnd : IRegexBookEnd
    {
        private readonly Regex _regex;

        public RegexBookEnd(string pattern) : this(new Regex(pattern)) { }

        private RegexBookEnd(Regex regex) => _regex = regex;

        public Bool IsMatch(string value) => new BoolOf(_regex.IsMatch(value));
    }
    public interface IRegexBookEnd
    {
        Bool IsMatch(string value);
    }
}