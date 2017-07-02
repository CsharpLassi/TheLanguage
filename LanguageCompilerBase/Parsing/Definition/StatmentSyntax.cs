using System.Collections.Generic;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class StatmentSyntax : Syntax
    {
        public Syntax Expression { get; set; }
        
        public StatmentSyntax() : base(nameof(StatmentSyntax))
        {
        }

        public override ParseStatus Check(SyntaxStream stream, ParseScope scope)
        {
            for (int i = 0; i < stream.Count; i++)
            {
                if (stream[i].Name == "StatmentEnd")
                {
                    Expression = new AssignSyntax();

                    var newStream = stream.Take(i);
                    
                    if (Expression.Check(newStream, scope) == ParseStatus.Ok)
                    {
                        stream.Replace(0,2,this);
                        return ParseStatus.Ok;
                    }
                    
                    Expression = new ExpressionSyntax();
                    if (Expression.Check(newStream, scope) == ParseStatus.Ok)
                    {
                        stream.Replace(0,2,this);
                        return ParseStatus.Ok;
                    }



                    return ParseStatus.Error;
                }
            }
            
            return ParseStatus.Error;
        }

        public override IEnumerable<Syntax> GetElements()
        {
            yield return Expression;
        }
    }
}