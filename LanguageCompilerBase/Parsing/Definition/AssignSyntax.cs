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

        public override ParseStatus Check(SyntaxStream stream)
        {
            if ( stream.Count > 1 && stream[1].Name == "AssignEqual")
            {
                
            }
            else if( stream.Count > 2 && stream[2].Name == "AssignEqual")
            {
                Variable = new VariableDecleration();
                if (Variable.Check(stream.Take(2)) == ParseStatus.Error)
                    return ParseStatus.Error;

                
                Expression = new ExpressionSyntax();
                if (Expression.Check(stream.Skip(2)) == ParseStatus.Error)
                    return ParseStatus.Error;
                
                stream.Replace(0,3,this);
                
                return ParseStatus.Ok;
            }
            
            
            return ParseStatus.Error;
        }

        public override IEnumerable<Syntax> GetElements()
        {
            yield return Variable;
            yield return Expression;
        }
    }
}