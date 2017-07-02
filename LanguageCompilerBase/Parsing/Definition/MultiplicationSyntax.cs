using System;
using System.Reflection.Emit;
using LanguageCompilerBase.Listing;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class MultiplicationSyntax : OperatorSyntax
    {
        
        public MultiplicationSyntax() 
            : base(nameof(MultiplicationSyntax),"Point")
        {
        }
    }
}