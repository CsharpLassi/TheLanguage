﻿using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace LanguageCompilerBase.Listing
{
    public class Scope
    {
        private readonly DynamicMethod methode;
        public ILGenerator Generator { get; }

        public Dictionary<string,LocalBuilder> LocalVariables { get; private set; }
        
        public Scope()
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