using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace LanguageCompilerBase.Listing
{
    public class ExpressionScope : Scope<ExpressionScope,ICodeScope> , IScopeParent<ExpressionScope> ,  ICodeScope
    {
        public Dictionary<string, LocalBuilder> LocalVariables => ParentScope.LocalVariables;
        public ILGenerator Generator => ParentScope.Generator;

        public Type ExpressionType { get; set; }

        public ExpressionScope(string name, MethodeScope parentScope) : base( name,parentScope)
        {
        }

        public LocalBuilder CreateVariable(string name, Type netType)
        {
            return ParentScope.CreateVariable(name, netType);
        }
    }
}