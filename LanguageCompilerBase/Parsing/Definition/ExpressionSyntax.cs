using System;
using System.Collections.Generic;
using LanguageCompilerBase.Listing;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class ExpressionSyntax : Syntax
    {

        public Syntax Expression { get; set; }

        private readonly Type[] syntaxes;
        
        public ExpressionSyntax() 
            : base(nameof(ExpressionSyntax))
        {
            syntaxes = new Type[]
            {
               
               typeof(BracketSyntax),
               typeof(DivisionSyntax),
               typeof(MultiplicationSyntax),
               typeof(SubstractionSyntax),
               typeof(AdditionSyntax),
               typeof(VariableCallSyntax),
               typeof(IntegerSyntax),
            };
        }

        private ExpressionSyntax(Syntax syntax)
            :base(nameof(ExpressionSyntax))
        {
            Expression = syntax;
        }


        public override ParseStatus Check(SyntaxStream stream)
        {
            
            
            for (int i = 0; i < syntaxes.Length ; i++)
            {
                bool repeat = false;
                
                do
                {
                    repeat = false;
                    var syntaxType = syntaxes[i];
                
                    if (stream.Count == 1 && stream[0].GetType() == syntaxType)
                    {
                        Expression = stream[0];
                        stream.Replace(0,1,this);
                        return ParseStatus.Ok;
                    }
                
                    var syntax = (Syntax)Activator.CreateInstance(syntaxType);
                
                    var result = syntax.Check(stream);

                    if (result == ParseStatus.Ok)
                    {
                        repeat = true;
                    }
                } while (repeat);
                
                
            }
            
            return ParseStatus.Ok;
        }


        public override IEnumerable<Syntax> GetElements()
        {
            yield return Expression;
        }
    }
}
