using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using LanguageCompilerBase.Listing;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class VariableDecleration : VariableSyntax
    {
        public string VariableType { get; set; }
        

        
        
        public VariableDecleration() 
            : base(nameof(VariableDecleration))
        {
        }

        public override ParseStatus Check(SyntaxStream stream)
        {
            var typeToken = stream[0] as TokenSyntax;
            var nameToken = stream[1] as TokenSyntax;
            
            if (typeToken != null && typeToken.Name == "Identifier" &&
                nameToken != null && nameToken.Name == "Identifier")
            {
                VariableType = typeToken.Token.Value;
                VariableName = nameToken.Token.Value;
                
                stream.Replace(0,2,this);
                
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
            Console.WriteLine($"Create {VariableName}");

            var type = Type.GetType(VariableType);
            
            Variable = scope.CreateVariable(VariableName,typeof(int));
        }
    }
}