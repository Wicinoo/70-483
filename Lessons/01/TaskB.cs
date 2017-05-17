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
            MapString operation1 = delegate(string x) { return x + 1; };
            MapString operation2 =         (string x) => { return x + 2; };
            MapString operation3 =         (x) => { return x + 3; };
            MapString operation4 =         x => { return x + 4; };
            MapString operation5 =         x =>  x + 5;


            Console.WriteLine($"operation1(test) = {operation1("test")}");
            Console.WriteLine($"operation2(test) = {operation2("test")}");
            Console.WriteLine($"operation3(test) = {operation3("test")}");
            Console.WriteLine($"operation4(test) = {operation4("test")}");
            Console.WriteLine($"operation5(test) = {operation5("test")}");
        }
    }
}