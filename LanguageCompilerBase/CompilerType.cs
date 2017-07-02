using System;

namespace LanguageCompilerBase
{
    public class CompilerType
    {
        public CompilerType( string name,Type netType)
        {
            NetType = netType;
            Name = name;
        }

        public Type NetType { get; }
        public string Name { get; }
    }
}