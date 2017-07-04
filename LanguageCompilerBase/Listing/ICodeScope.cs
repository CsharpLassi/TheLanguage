using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LanguageCompilerBase.Listing
{
    public interface ICodeScope : IScopeParent<ExpressionScope>
    {
        ILGenerator Generator { get; }

        Dictionary<string, LocalBuilder> LocalVariables { get; }

        LocalBuilder CreateVariable(string name, Type variableType);
    }
}
