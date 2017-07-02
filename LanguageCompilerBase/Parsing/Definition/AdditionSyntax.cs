using System;
using System.Reflection.Emit;
using LanguageCompilerBase.Listing;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class AdditionSyntax : OperatorSyntax
    {


        public AdditionSyntax() 
            : base(nameof(AdditionSyntax),"Plus")
        {
        }



        public override void End(Scope scope)
        {
            Console.WriteLine("Add");
            scope.Generator.Emit(OpCodes.Add);
        }
    }
}
