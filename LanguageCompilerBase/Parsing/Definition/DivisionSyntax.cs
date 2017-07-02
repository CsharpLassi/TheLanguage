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

        public override void End(Scope scope)
        {
            Console.WriteLine("Div");
            scope.Generator.Emit(OpCodes.Div);
        }
    }
}