using System;
using System.Collections.Generic;

namespace LanguageCompilerBase
{
    public class TypeList : Dictionary<string,CompilerType>
    {
        public TypeList()
        {
            this.Add("int",new CompilerType("int",typeof(int)));
        }
    }
}