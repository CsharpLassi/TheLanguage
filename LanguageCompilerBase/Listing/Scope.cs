using System;
using System.Reflection.Emit;

namespace LanguageCompilerBase.Listing
{
    public class Scope
    {
        private readonly DynamicMethod methode;
        public ILGenerator Generator { get; }
        
        
        
        public Scope()
        {
           methode = new DynamicMethod("Test", typeof(int), null);
           Generator = methode.GetILGenerator();
        }

        public Func<int> Create()
        {
            Generator.Emit(OpCodes.Ret);
            return (Func<int>)methode.CreateDelegate(typeof(Func<int>));
        }
    }
}