using System;
using System.Collections.Generic;
using LanguageCompilerBase.Parsing;

namespace LanguageCompilerBase.Listing
{
    public abstract class SyntaxListener
    {
        public delegate void CallSyntaxFunc<T>(T syntax, Scope scope);
        
        private abstract class CallSyntax
        {
            public abstract void Begin(object syntax, Scope scope);
            public abstract void End(object syntax, Scope scope);
        }
        
        private class CallSyntaxClass<T> : CallSyntax
            where T : Syntax
        {
            private CallSyntaxFunc<T> beginFunc;
            private CallSyntaxFunc<T> endFunc;
            
            public CallSyntaxClass(CallSyntaxFunc<T> begin, CallSyntaxFunc<T> end)
            {
                beginFunc = begin;
                endFunc = end;
            }
            
            public override void Begin(object syntax,Scope scope)
            {
                if (beginFunc == null)
                    return;

                var callSyntax = (T) syntax;
                beginFunc(callSyntax,scope);
            }
            
            public override void End(object syntax,Scope scope)
            {
                if (endFunc == null)
                    return;

                var callSyntax = (T) syntax;
                endFunc(callSyntax,scope);
            }
        }
        
        Dictionary<Type,CallSyntax> syntaxs = new Dictionary<Type, CallSyntax>();
        
        public Scope Listen(SyntaxTree tree)
        {
            var scope = new Scope();
            Listen(tree.Statments,scope);
            return scope;
        }

        public void Listen(Syntax syntax,Scope scope)
        {
            CallSyntax callSyntax = null;
            if (syntaxs.ContainsKey(syntax.GetType()))
                callSyntax = syntaxs[syntax.GetType()];
            
            callSyntax?.Begin(syntax,scope);
            
            foreach (var child in syntax.GetElements())
            {
                Listen(child,scope);
            }

            callSyntax?.End(syntax,scope);
        }

        protected virtual void AttachSyntax<T>(CallSyntaxFunc<T> beginFunc, CallSyntaxFunc<T> endFunc)
            where T : Syntax
        {
            syntaxs.Add(typeof(T),new CallSyntaxClass<T>(beginFunc,endFunc));
        }


    }
}