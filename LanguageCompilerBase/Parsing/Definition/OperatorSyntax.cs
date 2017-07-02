using System.Collections.Generic;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class OperatorSyntax : ExpressionPartSyntax
    {
        
        public ExpressionSyntax Left { get; set; }
        public ExpressionSyntax Right { get; set; }

        public string Operator { get; set; }
        
        public OperatorSyntax(string name, string operatorName) : base(name)
        {
            Operator = operatorName;
        }

        public override ParseStatus Check(SyntaxStream stream)
        {
            if (stream.Count < 3)
                return ParseStatus.Error;

            for (int i = 1; i < stream.Count; i++)
            {
                if (stream[i].Name == Operator )
                {

                    Left = new ExpressionSyntax();
                    Right = new ExpressionSyntax();
                    
                    if (Left.Check(stream.Get(i-1,1)) == ParseStatus.Ok &&
                        Right.Check(stream.Get(i + 1,1)) == ParseStatus.Ok)
                    {
                        stream.Replace(i-1,3,this);
                        return ParseStatus.Ok;
                    }
                }
            }

            return ParseStatus.Error;
        }

        public override IEnumerable<Syntax> GetElements()
        {
            
            yield return Left;
            yield return Right;
            
        }
    }
}