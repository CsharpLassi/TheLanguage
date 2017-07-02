using System;

namespace LanguageCompilerBase.Listing
{
    public class ExpressionScope : Scope
    {
        
        public ExpressionScope(Scope parentScope, string name) : base(parentScope, name)
        {
        }

        public override void CreateVariable(string name, Type typeNetType)
        {
            ParentScope.CreateVariable(name, typeNetType);
        }
    }
}