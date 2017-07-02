using System;
using System.Reflection.Emit;
using LanguageCompilerBase.Listing;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class SubstractionSyntax : OperatorSyntax
    {
        public SubstractionSyntax() 
            : base(nameof(SubstractionSyntax),"Minus")
        {
        }
    }
}
