using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Emit;
using LanguageCompilerBase.Listing;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class IntegerSyntax : ExpressionPartSyntax
    {
        public int Value { get; set; }

        public IntegerSyntax() 
            : base(nameof(IntegerSyntax))
        {
        }

        public override ParseStatus Check(SyntaxStream stream, ParseScope scope)
        {
            if (stream.Count != 1)
                return ParseStatus.Error;

            var token = stream[0] as TokenSyntax;
            
            if (token != null && token.Name == "Integer")
            {
                Value = int.Parse(token.Token.Value);
                stream.Replace(0,1,this);
                return ParseStatus.Ok;
            }

            return ParseStatus.Error;
        }

        public override IEnumerable<Syntax> GetElements()
        {
            yield break;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
