using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using LanguageCompilerBase.Listing;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class VariableCallSyntax : Syntax
    {
        public string VariableName { get; set; }
        
        public VariableCallSyntax() 
            : base(nameof(VariableCallSyntax))
        {
        }

        public override ParseStatus Check(SyntaxStream stream)
        {
            if (stream.Count != 1)
                return ParseStatus.Error;

            var token = stream[0] as TokenSyntax;
            
            if (token != null && token.Name == "Identifier")
            {
                VariableName = token.Token.Value;
                stream.Replace(0,1,this);
                return ParseStatus.Ok;
            }

            return ParseStatus.Error;
            
        }

        public override IEnumerable<Syntax> GetElements()
        {
            yield break;
        }

        public override void Start(Scope scope)
        {
            Console.WriteLine($"LD {VariableName}");
            scope.Generator.Emit(OpCodes.Ldloc,scope.LocalVariables[VariableName]);
        }
    }
}