using System;
using System.Reflection.Emit;
using LanguageCompilerBase.Parsing.Definition;

namespace LanguageCompilerBase.Listing
{
    public sealed class CodeListener : SyntaxListener
    {
        public CodeListener()
        {
            AttachSyntax<IntegerSyntax>(null,IntegerEnd);
            AttachSyntax<AdditionSyntax>(null,AdditionEnd);
            AttachSyntax<SubstractionSyntax>(null,SubstractionEnd);
            AttachSyntax<MultiplicationSyntax>(null,MultiplicationEnd);
            AttachSyntax<DivisionSyntax>(null,DivisionEnd);
            AttachSyntax<AssignSyntax>(null,AssignEnd);
            
            AttachSyntax<VariableCallSyntax>(null,VariableCallEnd);
            AttachSyntax<VariableDecleration>(VariableDeclerationStart,null);
        }

        private void VariableDeclerationStart(VariableDecleration syntax, Scope scope)
        {
            var name = syntax.VariableName;
            var type = Type.GetType(syntax.VariableType);
            
            Console.WriteLine($"Create {name}");
            
            scope.CreateVariable(name,typeof(int));
        }

        private void VariableCallEnd(VariableCallSyntax syntax, Scope scope)
        {
            Console.WriteLine($"LD {syntax.VariableName}");
            scope.Generator.Emit(OpCodes.Ldloc,scope.LocalVariables[syntax.VariableName]);
        }

        private void SubstractionEnd(SubstractionSyntax syntax, Scope scope)
        {
            Console.WriteLine("Sub");
            scope.Generator.Emit(OpCodes.Sub);
        }

        private void MultiplicationEnd(MultiplicationSyntax syntax, Scope scope)
        {
            Console.WriteLine("Mul");
            scope.Generator.Emit(OpCodes.Mul);
        }

        private void IntegerEnd(IntegerSyntax syntax, Scope scope)
        {
            Console.WriteLine(syntax.Value);
            scope.Generator.Emit(OpCodes.Ldc_I4,syntax.Value);
        }

        private void DivisionEnd(DivisionSyntax syntax, Scope scope)
        {
            Console.WriteLine("Div");
            scope.Generator.Emit(OpCodes.Div);
        }

        private void AssignEnd(AssignSyntax syntax, Scope scope)
        {
             Console.WriteLine($"STLoc {syntax.Variable.VariableName}");

            var variable = scope.LocalVariables[syntax.Variable.VariableName];
            
             scope.Generator.Emit(OpCodes.Stloc,variable);
        }

        private void AdditionEnd(AdditionSyntax syntax, Scope scope)
        {
            Console.WriteLine("Add");
            scope.Generator.Emit(OpCodes.Add);
        }
    }
}