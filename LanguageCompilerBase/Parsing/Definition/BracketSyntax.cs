using System.Collections.Generic;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class BracketSyntax : Syntax
    {
        public ExpressionSyntax ExpressionSyntax { get; set; }
        
        public BracketSyntax() 
            : base(nameof(BracketSyntax))
        {
        }

        public override ParseStatus Check(SyntaxStream stream, ParseScope scope)
        {
            for (int i = 0; i < stream.Count; i++)
            {
                if (stream[i].Name == "OpenBracket")
                {
                    int openCount = 0;
                    
                    for (int j = i +1 ; j < stream.Count; j++)
                    {
                        if (stream[j].Name == "OpenBracket")
                            openCount++;

                        
                        if (stream[j].Name == "CloseBracket")
                        {
                            if (openCount != 0)
                                openCount--;
                            else
                            {



                                var expression = new ExpressionSyntax();
                                var expressionStream = stream.Get(i + 1, j - (i + 1));

                                if (expression.Check(expressionStream, scope) == ParseStatus.Ok)
                                {
                                    ExpressionSyntax = expression;
                                    stream.Replace(i, 3, this);
                                    return ParseStatus.Ok;
                                }
                            }
                        }
                    }
                }
            }
            
            
            
            return ParseStatus.Error;
        }

        public override IEnumerable<Syntax> GetElements()
        {
            yield return ExpressionSyntax;
        }
    }
}