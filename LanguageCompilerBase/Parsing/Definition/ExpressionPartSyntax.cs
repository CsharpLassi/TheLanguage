namespace LanguageCompilerBase.Parsing.Definition
{
    public abstract class ExpressionPartSyntax : Syntax
    {
        public string ExpressionType { get; set; }

        public ExpressionPartSyntax(string name) : base(name)
        {
        }
    }
}