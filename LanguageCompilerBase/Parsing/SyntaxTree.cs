using LanguageCompilerBase.Parsing.Definition;

namespace LanguageCompilerBase.Parsing
{
    public class SyntaxTree
    {
        public StatmentListSyntax Statments { get; set; }

        public SyntaxTree(StatmentListSyntax statments)
        {
            Statments = statments;
        }
    }
}