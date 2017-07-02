using System.Reflection.Emit;

namespace LanguageCompilerBase.Parsing.Definition
{
    public abstract class VariableSyntax : Syntax
    {
        public string VariableName { get; set; }
        
        public VariableSyntax(string name) : base(name)
        {
        }
    }
}