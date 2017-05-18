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
            MapString str1 = delegate(string x) { return x; };
            MapString str2 = (string x) => { return x; };
            MapString str3 = (x) => { return x; };
            MapString str4 = x => { return x; };
            MapString str5 = x => x;

            Console.WriteLine(str1("str1 example"));
            Console.WriteLine(str2("str2 example"));
            Console.WriteLine(str3("str3 example"));
            Console.WriteLine(str4("str4 example"));
            Console.WriteLine(str5("str5 example"));
        }
    }
}