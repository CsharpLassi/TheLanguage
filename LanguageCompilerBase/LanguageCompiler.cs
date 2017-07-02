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
        private SyntaxListener codeListener;

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
                new TokenDefinition("Define","def"),
                new TokenDefinition("Identifier","[_a-zA-Z][_a-zA-Z0-9]*"),
                new TokenDefinition("DoublePoint","[:]"),
                new TokenDefinition("AssignEqual","[=]"),
            };


            tokenizer = new Tokenizer(tokenDefinitions);
            parser = new Parser();

            
            
            codeListener = new CodeListener();
            
            
        }
        
        public Func<int> Compile(string code)
        {
            var tokenResult = tokenizer.Parse(code);
            var syntaxTree = parser.Parse(tokenResult);
            
            var scope = (MethodeScope)codeListener.Listen(syntaxTree);

            var func = scope.Create();

            return func;
        }
    }
}