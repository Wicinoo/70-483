using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using Microsoft.CSharp;

namespace Lessons._08
{
    public class _01_CodeDomExample
    {
        public static void Run()
        {
            var myClassCompileUnit = CreateCompileUnitForMyClass();
            GenerateMyClass(myClassCompileUnit);

            Console.WriteLine($"MyClass has been generated.\r\nCheck result in {AppDomain.CurrentDomain.BaseDirectory}MyClass.cs");
        }

        private static CodeCompileUnit CreateCompileUnitForMyClass()
        {
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace myNamespace = new CodeNamespace("MyNamespace");
            myNamespace.Imports.Add(new CodeNamespaceImport("System"));

            CodeTypeDeclaration myClass = new CodeTypeDeclaration("MyClass");
            CodeEntryPointMethod startMethod = new CodeEntryPointMethod();

            CodeMethodInvokeExpression writeToConsoleStatement = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("Console"), "WriteLine", new CodePrimitiveExpression("Hello World!"));

            compileUnit.Namespaces.Add(myNamespace);
            myNamespace.Types.Add(myClass);
            myClass.Members.Add(startMethod);
            startMethod.Statements.Add(writeToConsoleStatement);

            return compileUnit;
        }

        private static void GenerateMyClass(CodeCompileUnit compileUnit)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();

            using (StreamWriter sw = new StreamWriter("HelloWorld.cs", false))
            {
                IndentedTextWriter tw = new IndentedTextWriter(sw, "    ");
                provider.GenerateCodeFromCompileUnit(compileUnit, tw,
                    new CodeGeneratorOptions());
                tw.Close();
            }
        }
    }
}