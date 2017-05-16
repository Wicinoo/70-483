using System;

namespace Lessons._01
{
    /// <summary>
    /// Define a delegate "string MapString(string @string)" and write all possible forms according to _03_LambdaExpressionBasics.
    /// Print results from each expression.
    /// </summary>
    public class TaskB
    {
        public delegate string MapString(string @string);

        public static void Run()
        {
            MapString @delegate = delegate (string @string) { return @string; };
            MapString @explicitLambda = (string @string) => { return @string; };
            MapString @implicitLambda1 = (@string) => { return @string; };
            MapString @implicitLambda2 = @string => { return @string; };
            MapString @lambda= @string => @string;

            PrintString(@delegate("delegate syntax"));
            PrintString(@explicitLambda("explicit lambda syntax"));
            PrintString(@implicitLambda1("implicit lambda syntax with parameter parenthesis"));
            PrintString(@implicitLambda2("implicit lambda syntax with function braces"));
            PrintString(@lambda("lambda syntax"));
        }

        public static void PrintString(string @string)
        {
            Console.WriteLine($"{@string}");
        }
    }
}