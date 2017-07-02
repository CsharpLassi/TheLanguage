using LanguageCompilerBase.Parsing;

namespace LanguageCompilerBase.Listing
{
    public class SyntaxListener
    {
        public Scope Listen(SyntaxTree tree)
        {
            var scope = new Scope();
            Listen(tree.Statments,scope);
            return scope;
        }

        public void Listen(Syntax syntax,Scope scope)
        {
            syntax.Start(scope);
            
            foreach (var child in syntax.GetElements())
            {
                Listen(child,scope);
            }

            syntax.End(scope);
        }


    }
}