using System;

namespace Lessons._01
{
    /// <summary>
    /// Define a delegate "string MapString(string @string)" and write all possible forms according to _03_LambdaExpressionBasics.
    /// Print results from each expression.
    /// </summary>
    public class TaskB
    {
        delegate string MapString(string @string);

        public static void Run()
        {
            MapString usage1 = delegate(string someString) { return "your string has been surrounded ..." + someString + "..."; };

            MapString usage2 = (string someString) => { return "your string has been surrounded ..." + someString + "..."; };

            MapString usage3 = (someString) => { return "your string has been surrounded ..." + someString + "..."; };

            MapString usage4 = someString => { return "your string has been surrounded ..." + someString + "..."; };

            MapString usage5 = someString => "your string has been surrounded ..." + someString + "...";

            Console.WriteLine(usage1("S panom bohom"));
            Console.WriteLine(usage2("Idem od vas"));
            Console.WriteLine(usage3("Neublizil som"));
            Console.WriteLine(usage4("Neublizil som"));
            Console.WriteLine(usage5("Ziadnemu z vas"));
        }
    }
}