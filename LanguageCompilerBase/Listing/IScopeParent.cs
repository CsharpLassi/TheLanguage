using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageCompilerBase.Listing
{
    public interface IScopeParent<T> : IScopeParent
        where T : Scope
    {
    }

    public interface IScopeParent : IScope
    {
        T CreateChild<T>(string name)
            where T : Scope;
    }
}
