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
            MapString operation1 = delegate (string x) { return x; };
            MapString operation2 = (string x) => { return x; };
            MapString operation3 = (x) => { return x; };
            MapString operation4 = x => { return x; };
            MapString operation5 = x => x;

            Console.WriteLine($"operation1(\"value1\") = {operation1("value1")}");
            Console.WriteLine($"operation2(\"value2\") = {operation2("value2")}");
            Console.WriteLine($"operation3(\"value3\") = {operation3("value3")}");
            Console.WriteLine($"operation4(\"value4\") = {operation4("value4")}");
            Console.WriteLine($"operation5(\"value5\") = {operation5("value5")}");
        }
    }
}