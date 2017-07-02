using System;
using System.Collections.Generic;
using LanguageCompilerBase.Parsing;

namespace LanguageCompilerBase.Listing
{
    public abstract class SyntaxListener
    {
        public delegate void BeginCallSyntaxFunc<T, S>(T syntax, S scope)
            where T : Syntax
            where S : Scope;
        
        public delegate void EndCallSyntaxFunc<T,S>(T syntax, S scope)
            where T : Syntax
            where S : Scope;
        
        private abstract class CallSyntax
        {
            public abstract Scope Begin(object syntax, Scope scope);
            public abstract void End(object syntax, Scope scope);
        }
        
        private class CallSyntaxClass<T,S> : CallSyntax
            where T : Syntax
            where S : Scope
        {
            private BeginCallSyntaxFunc<T,S> beginFunc;
            private EndCallSyntaxFunc<T,S> endFunc;
            
            public CallSyntaxClass(BeginCallSyntaxFunc<T,S> begin, EndCallSyntaxFunc<T,S> end)
            {
                beginFunc = begin;
                endFunc = end;
            }
            
            public override Scope Begin(object syntax, Scope scope)
            {
                

                var callSyntax = (T) syntax;
                
                var newScope = scope.CreateChild<S>(callSyntax.Name);
                
                beginFunc?.Invoke(callSyntax, newScope);

                return scope;
            }
            
            public override void End(object syntax,Scope scope)
            {
                if (endFunc == null)
                    return;

                var callSyntax = (T) syntax;
                endFunc(callSyntax,(S)scope);
            }


        }
        
        Dictionary<Type,CallSyntax> syntaxs = new Dictionary<Type, CallSyntax>();
        
        public Scope Listen(SyntaxTree tree)
        {
            var scope = Scope.CreateGlobalScope();
            var methodeScope = new MethodeScope(scope,"Main");
            Listen(tree.Statments,scope);
            return scope;
        }

        public void Listen(Syntax syntax,Scope scope)
        {
            CallSyntax callSyntax = null;
            if (syntaxs.ContainsKey(syntax.GetType()))
                callSyntax = syntaxs[syntax.GetType()];
            
            var newScope = callSyntax?.Begin(syntax,scope);
            
            foreach (var child in syntax.GetElements())
            {
                Listen(child,newScope);
            }

            callSyntax?.End(syntax,newScope);
        }

        protected virtual void AttachSyntax<T,S>(BeginCallSyntaxFunc<T,S> beginFunc, EndCallSyntaxFunc<T,S> endFunc)
            where T : Syntax
            where S : Scope
        {
            if (beginFunc != null) syntaxs.Add(typeof(T), new CallSyntaxClass<T, S>(beginFunc, endFunc));
        }


    }
}