using System;

namespace Lessons._01
{
    /// <summary>
    /// Define a delegate "string MapString(string @string)" and write all possible forms according to _03_LambdaExpressionBasics.
    /// Print results from each expression.
    /// </summary>
    public class TaskB
    {
        private delegate string MapString(string str);

        public static void Run()
        {
            MapString operation1 = delegate(string x) { return x + "X"; };
            MapString operation2 = (string x) => { return x + "X"; };
            MapString operation3 = (x) => { return x + "X"; };
            MapString operation4 = x => { return x + "X"; };
            MapString operation5 = x => x + "X";

            Console.WriteLine($"operation1(1) = {operation1("Some string")}");
            Console.WriteLine($"operation2(1) = {operation2("Some string")}");
            Console.WriteLine($"operation3(1) = {operation3("Some string")}");
            Console.WriteLine($"operation4(1) = {operation4("Some string")}");
            Console.WriteLine($"operation5(1) = {operation5("Some string")}");

        }
    }
}