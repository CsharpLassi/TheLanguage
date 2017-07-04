using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace LanguageCompilerBase.Listing
{
    public class MethodeScope : Scope<MethodeScope,Scope> ,  ICodeScope, IScopeParent<ExpressionScope> 
    {
        private readonly DynamicMethod methode;
        public ILGenerator Generator { get; }
        
        public Dictionary<string,LocalBuilder> LocalVariables { get; private set; }

        public MethodeScope( string name, Scope parentScope) 
            : base( name, parentScope)
        {
            methode = new DynamicMethod("Test", typeof(int), null);
            Generator = methode.GetILGenerator();
            
            LocalVariables = new Dictionary<string, LocalBuilder>();
        }
        
        public Func<int> Create()
        {
            Generator.Emit(OpCodes.Ret);
            return (Func<int>)methode.CreateDelegate(typeof(Func<int>));
        }
        
        public LocalBuilder CreateVariable(string name, Type variableType)
        {
            var localBuilder = Generator.DeclareLocal(variableType);
            
            LocalVariables.Add(name,localBuilder);
            return localBuilder;
        }

       
    }
}