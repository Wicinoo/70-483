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
            MapString f1 = delegate (string s) { return s.ToUpper() + '!'; };
            MapString f2 = (string s) => { return s.ToUpper() + '!'; };
            MapString f3 = (s) => { return s.ToUpper() + '!'; };
            MapString f4 = s => { return s.ToUpper() + '!'; };
            MapString f5 = s => s.ToUpper() + '!';

            Console.WriteLine($@"f1(""Hello"") = {f1("Hello")}");
            Console.WriteLine($@"f2(""Hello"") = {f2("Hello")}");
            Console.WriteLine($@"f3(""Hello"") = {f3("Hello")}");
            Console.WriteLine($@"f4(""Hello"") = {f4("Hello")}");
            Console.WriteLine($@"f5(""Hello"") = {f5("Hello")}");
        }
    }
}