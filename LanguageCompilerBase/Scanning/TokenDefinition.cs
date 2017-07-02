using System.Text.RegularExpressions;

namespace LanguageCompilerBase.Scanning
{
    public class TokenDefinition
    {
        public string Name { get; private set; }
        public Regex Expression { get; private set; }

        public bool Skip { get; private set; }

        public TokenDefinition(string name, string pattern)
        {
            Name = name;
            Expression = new Regex(pattern);
        }

        public TokenDefinition(string name, string pattern, bool skip) : this(name, pattern)
        {
            Skip = skip;
        }
    }
}
