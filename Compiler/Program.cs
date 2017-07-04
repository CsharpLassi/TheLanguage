using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using LanguageCompilerBase;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "def i = 5;i = 10; i"; // 8
            

            var compiler = new LanguageCompiler();

            var func = compiler.Compile(input);

            Console.WriteLine();
            Console.WriteLine(func());

            Console.ReadLine();
        }
    }
}