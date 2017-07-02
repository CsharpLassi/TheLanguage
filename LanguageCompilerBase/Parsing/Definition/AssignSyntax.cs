using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using LanguageCompilerBase.Listing;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class AssignSyntax : Syntax
    {
        public VariableSyntax Variable { get; set; }
        
        public ExpressionSyntax Expression { get; set; }
        
        public AssignSyntax() 
            : base(nameof(AssignSyntax))
        {
        }

        public override ParseStatus Check(SyntaxStream stream, ParseScope scope)
        {
            for (int i = 0; i < stream.Count; i++)
            {
                if (stream[i].Name == "AssignEqual")
                {
                    Variable = new VariableDecleration();
                    if (Variable.Check(stream.Take(i), scope) == ParseStatus.Error)
                        return ParseStatus.Error;

                
                    Expression = new ExpressionSyntax();
                    if (Expression.Check(stream.Skip(2), scope) == ParseStatus.Error)
                        return ParseStatus.Error;
                
                    stream.Replace(0,3,this);
                
                    return ParseStatus.Ok;
                }
            }
            
            
            
            return ParseStatus.Error;
        }

        public override IEnumerable<Syntax> GetElements()
        {
            yield return Expression;
            yield return Variable;
            
        }
    }
}