using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageCompilerBase.Listing
{
    public interface IScope
    {
        TypeList Types { get; }
    }
}
