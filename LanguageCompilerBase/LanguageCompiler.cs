using System;
using System.Collections.Generic;
using LanguageCompilerBase.Listing;
using LanguageCompilerBase.Parsing;
using LanguageCompilerBase.Scanning;

namespace LanguageCompilerBase
{
    public class LanguageCompiler
    {
        private List<TokenDefinition> tokenDefinitions;
        private Tokenizer tokenizer;
        private Parser parser;
        private SyntaxListener listener;

        public LanguageCompiler()
        {
             tokenDefinitions = new List<TokenDefinition>() {
                new TokenDefinition("Integer", "[0-9]+"),
                new TokenDefinition("Space", " ", true),
                new TokenDefinition("Minus", "[-]"),
                new TokenDefinition("Plus", "[+]"),
                new TokenDefinition("Point", "[*]"),
                new TokenDefinition("Divisor", "[/]"),
                new TokenDefinition("OpenBracket","[(]"),
                new TokenDefinition("CloseBracket","[)]"),
                new TokenDefinition("StatmentEnd",";"),
            };


            tokenizer = new Tokenizer(tokenDefinitions);
            parser = new Parser();

            
            
            listener = new SyntaxListener();
            
            
        }
        
        public Func<int> Compile(string code)
        {
            var tokenResult = tokenizer.Parse(code);
            var syntaxTree = parser.Parse(tokenResult);
            
            var scope = listener.Listen(syntaxTree);

            var func = scope.Create();

            return func;
        }
    }
}