using System;

namespace Lessons._01
{
    /// <summary>
    /// Define a delegate "string MapString(string @string)" and write all possible forms according to _03_LambdaExpressionBasics.
    /// Print results from each expression.
    /// </summary>
    public class TaskB
    {
        private delegate string MapString(string @string);

        public static void Run()
        {
            MapString operation1 = delegate (string x) { return x + 1; };   // Anonymous method
            MapString operation2 = (string x) => { return x + 1; };   // Lambda expression (explicitly typed parameter)
            MapString operation3 = (x) => { return x + 1; };   // Lambda expression (implicitly typed parameter)
            MapString operation4 = x => { return x + 1; };   // Lambda expression (implicitly typed parameter)
            MapString operation5 = x => x + 1;   // Lambda expression (implicitly typed parameter)

            Console.WriteLine($"operation1(1) = {operation1("1")}");
            Console.WriteLine($"operation2(1) = {operation2("1")}");
            Console.WriteLine($"operation3(1) = {operation3("1")}");
            Console.WriteLine($"operation4(1) = {operation4("1")}");
            Console.WriteLine($"operation5(1) = {operation5("1")}");
        }
    }
}