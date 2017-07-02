using System.Collections.Generic;
using LanguageCompilerBase.Parsing.Definition;
using LanguageCompilerBase.Scanning;

namespace LanguageCompilerBase.Parsing
{
    public class Parser
    {

        public Parser()
        {
        }

        public SyntaxTree Parse(List<Token> tokens)
        {

            var statment = new StatmentListSyntax();

            SyntaxStream stream = new SyntaxStream(tokens);
            
            var scope = new ParseScope();
            
            statment.Check(stream,scope);

            return new SyntaxTree(statment);
        }
    }
}
