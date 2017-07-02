using System.Collections.Generic;
using LanguageCompilerBase.Scanning;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class TokenSyntax : Syntax
    {
        public Token Token { get; private set; }
        
        public TokenSyntax(Token token) 
            : base(token.Name)
        {
            Token = token;
        }

        public override ParseStatus Check(SyntaxStream tokens, ParseScope scope)
        {
            return ParseStatus.Error;
        }

        public override IEnumerable<Syntax> GetElements()
        {
            yield break;
        }


    }
}