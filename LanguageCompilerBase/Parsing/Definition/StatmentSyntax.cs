using System.Collections.Generic;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class StatmentSyntax : Syntax
    {
        public ExpressionSyntax Expression { get; set; }
        
        public StatmentSyntax() : base(nameof(StatmentSyntax))
        {
        }

        public override ParseStatus Check(SyntaxStream stream)
        {
            for (int i = 0; i < stream.Count; i++)
            {
                if (stream[i].Name == "StatmentEnd")
                {
                    Expression = new ExpressionSyntax();
                    if (Expression.Check(stream.Take(i)) == ParseStatus.Ok)
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