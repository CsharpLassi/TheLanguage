using System.Collections.Generic;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class VariableTypeSyntax : Syntax
    {
        public string TypeName { get; set; }
        
        public VariableTypeSyntax(string name,string typeName) : base(name)
        {
            TypeName = typeName;
        }

        public override ParseStatus Check(SyntaxStream stream, ParseScope scope)
        {
            return ParseStatus.Ok;
        }

        public override IEnumerable<Syntax> GetElements()
        {
            yield break;
        }
    }
}