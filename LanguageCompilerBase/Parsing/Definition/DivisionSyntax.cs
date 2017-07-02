using System;
using System.Reflection.Emit;
using LanguageCompilerBase.Listing;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class DivisionSyntax : OperatorSyntax
    {        
        public DivisionSyntax() 
            : base(nameof(DivisionSyntax),"Divisor")
        {
        }
    }
}