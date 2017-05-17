using System;

namespace Lessons._01
{
    /// <summary>
    /// Define a delegate "string MapString(string @string)" and write all possible forms according to _03_LambdaExpressionBasics.
    /// Print results from each expression.
    /// </summary>
    public delegate string MapString(string @string);

    public class TaskB
    {
        public static void Run()
        {
            // All right-side forms are equivalent.
            MapString operation1 = delegate (string x) { return x; };   // Anonymous method
            MapString operation2 = (string x) => { return x; };   // Lambda expression (explicitly typed parameter)
            MapString operation3 = (x) => { return x; };   // Lambda expression (implicitly typed parameter)
            MapString operation4 = x => { return x; };   // Lambda expression (implicitly typed parameter)
            MapString operation5 = x => x;   // Lambda expression (implicitly typed parameter)

            string param ="string";
            Console.WriteLine($"operation1(string) = {operation1(param)}");
            Console.WriteLine($"operation2(string) = {operation2(param)}");
            Console.WriteLine($"operation3(string) = {operation3(param)}");
            Console.WriteLine($"operation4(string) = {operation4(param)}");
            Console.WriteLine($"operation5(string) = {operation5(param)}");
        }
    }
}