using System;
using System.Reflection.Emit;
using LanguageCompilerBase.Parsing.Definition;

namespace LanguageCompilerBase.Listing
{
    public sealed class CodeListener : SyntaxListener
    {
        
        public CodeListener()
        {   
            AttachSyntax<IntegerSyntax,ExpressionScope>(null,IntegerEnd);
            AttachSyntax<AdditionSyntax,ExpressionScope>(null,AdditionEnd);
            AttachSyntax<SubstractionSyntax,ExpressionScope>(null,SubstractionEnd);
            AttachSyntax<MultiplicationSyntax,ExpressionScope>(null,MultiplicationEnd);
            AttachSyntax<DivisionSyntax,ExpressionScope>(null,DivisionEnd);

            AttachSyntax<AssignSyntax,ExpressionScope>(AssignStart,AssignEnd);
            
            AttachSyntax<VariableCallSyntax,ExpressionScope>(null,VariableCallEnd);
            AttachSyntax<VariableDeclerationSyntax,ExpressionScope>(VariableDeclerationStart, null);
        }

        

        private Scope VariableDeclerationStart(VariableDeclerationSyntax syntax, ExpressionScope scope)
        {
            var name = syntax.VariableName;
            var type = !syntax.IsDynamic ? scope.Types[syntax.VariableType.TypeName].NetType : scope.ExpressionType;
            
            Console.WriteLine($"Create {name}");
            

            scope.CreateVariable(name,type);

            return scope;

        }



        private void VariableCallEnd(VariableCallSyntax syntax, ExpressionScope scope)
        {
            Console.WriteLine($"LD {syntax.VariableName}");
            scope.Generator.Emit(OpCodes.Ldloc,scope.LocalVariables[syntax.VariableName]);
        }

        private void SubstractionEnd(SubstractionSyntax syntax, ExpressionScope scope)
        {
            Console.WriteLine("Sub");
            scope.Generator.Emit(OpCodes.Sub);
        }

        private void MultiplicationEnd(MultiplicationSyntax syntax, ExpressionScope scope)
        {
            Console.WriteLine("Mul");
            scope.Generator.Emit(OpCodes.Mul);
        }

        private void IntegerEnd(IntegerSyntax syntax, ExpressionScope scope)
        {
            scope.ExpressionType = scope.Types["int"].NetType;
            Console.WriteLine(syntax.Value);
            scope.Generator.Emit(OpCodes.Ldc_I4,syntax.Value);
        }

        private void DivisionEnd(DivisionSyntax syntax, ExpressionScope scope)
        {
            Console.WriteLine("Div");
            scope.Generator.Emit(OpCodes.Div);
        }

        private Scope AssignStart(AssignSyntax syntax, ExpressionScope scope)
        {
            return scope;
        }

        private void AssignEnd(AssignSyntax syntax, ExpressionScope scope)
        {
             Console.WriteLine($"STLoc {syntax.Variable.VariableName}");

            var variable = scope.LocalVariables[syntax.Variable.VariableName];
            
             scope.Generator.Emit(OpCodes.Stloc,variable);
        }

        private void AdditionEnd(AdditionSyntax syntax, ExpressionScope scope)
        {
            Console.WriteLine("Add");
            scope.Generator.Emit(OpCodes.Add);
        }
    }
}