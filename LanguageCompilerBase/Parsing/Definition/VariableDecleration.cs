using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using LanguageCompilerBase.Listing;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class VariableDecleration : VariableSyntax
    {
        public VariableTypeSyntax VariableType { get; set; }
        
        public VariableDecleration() 
            : base(nameof(VariableDecleration))
        {
        }

        public override ParseStatus Check(SyntaxStream stream, ParseScope scope)
        {
            if (stream.Count < 2)
                return ParseStatus.Error;
            
            var defineToken = stream[0] as TokenSyntax;
            var nameToken = stream[1] as TokenSyntax;
            
            if (defineToken != null && defineToken.Name == "Define" &&
                nameToken != null && nameToken.Name == "Identifier")
            {
                VariableName = nameToken.Token.Value;

                if (stream.Count == 2)
                {
                    VariableType = new DynamicTypeSyntax();
                    stream.Replace(0,2,this); 
                }
                else
                {
                    var pointToken = stream[2] as TokenSyntax;
                    var typeToken = stream[3] as TokenSyntax;

                    if (pointToken != null && pointToken.Name == "DoublePoint" &&
                        typeToken != null && typeToken.Name == "Identifier")
                    {
                        VariableType = new VariableTypeSyntax(typeToken.Token.Value,typeToken.Token.Value);
                        stream.Replace(0,4,this);
                    }
                }
                
                
                
                return ParseStatus.Ok;
            }
            
            return ParseStatus.Error;
        }

        public override IEnumerable<Syntax> GetElements()
        {
           yield return VariableType;
        }

    }
}