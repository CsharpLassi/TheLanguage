using System.Collections.Generic;
using System.Threading;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class DynamicTypeSyntax : VariableTypeSyntax
    {
        private static int dynamicNumber = 0;
        
        public DynamicTypeSyntax() : base(nameof(DynamicTypeSyntax),"DynamicType")
        {
            TypeName = $"DynamicType_{Interlocked.Increment(ref dynamicNumber)}";
        }

        public override ParseStatus Check(SyntaxStream stream, ParseScope scope)
        {
            return ParseStatus.Ok;
        }

        public override IEnumerable<Syntax> GetElements()
        {
            yield break ;
        }
    }
}