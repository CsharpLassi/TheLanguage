using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace LanguageCompilerBase.Listing
{
    public class Scope
    {
        public string Name { get; private set; }

        private TypeList types;
        public TypeList Types
        {
            get
            {
                if (ParentScope != null)
                    return ParentScope.Types;

                if (types != null)
                    types = new TypeList();
                
                return types;
            }
        }

        public Scope ParentScope { get; private set; }
        
        protected Scope() 
            : this("General")
        {
           
        }

        public T CreateChild<T>(string name)
            where  T: Scope
        {
            var instance = (T)Activator.CreateInstance(typeof(T), this, name);

            return instance;
        }

        protected Scope(Scope parentScope,string name)
        {
            ParentScope = parentScope;
            Name = $"{ParentScope.Name}.{name}";
        }

        public static Scope CreateGlobalScope()
        {
            return new Scope();
        }
        
        private Scope(string name)
        {
            Name = name;
        }


        public virtual void CreateVariable(string name, Type typeNetType)
        {
            
        }
    }
}