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
            MapString string1 = delegate (string @string) { return @string; };
            MapString string2 = (string @string) => { return @string; };
            MapString string3 = (@string) => { return @string; };
            MapString string4 = @string => { return @string; };
            MapString string5 = @string => @string;

            Console.WriteLine(string1("string1"));
            Console.WriteLine(string2("string2"));
            Console.WriteLine(string3("string3"));
            Console.WriteLine(string4("string4"));
            Console.WriteLine(string5("string5"));
        }
    }
}