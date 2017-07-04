using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace LanguageCompilerBase.Listing
{
    public abstract class Scope<C,P> : Scope
        where C : Scope
        where P : IScope,IScopeParent<C> 
    {
        public P ParentScope { get; private set; }

        public new  TypeList Types
        {
            get
            {
                return ParentScope.Types;
            }
        }

        public Scope(string name,P parent)
            :base(name)
        {
            ParentScope = parent;
        }
    }

    public class Scope : IScopeParent<Scope>, IScopeParent<MethodeScope>
    {
        public string Name { get; private set; }

        public TypeList Types { get; }

        private Scope() 
            : this("General")
        {
           
        }

        protected Scope(string name)
        {
            Types = new TypeList();
        }

        public static Scope CreateGlobalScope()
        {
            return new Scope();
        }

        public T CreateChild<T>(string name) where T : Scope
        {
            if (!((this is IScopeParent<T>)) )
                throw new Exception("Cannot create Scope");

            var instance = (T)Activator.CreateInstance(typeof(T), name, this);

            return instance;
        }
    }
}