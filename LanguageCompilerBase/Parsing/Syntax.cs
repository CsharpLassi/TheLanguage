using System.Collections.Generic;
using LanguageCompilerBase.Listing;

namespace LanguageCompilerBase.Parsing
{
    public abstract class Syntax
    {

        public string Name { get; set; }

        public Syntax(string name )
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public abstract ParseStatus Check(SyntaxStream stream);

        public abstract  IEnumerable<Syntax> GetElements();
    }
}
