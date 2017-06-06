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
            MapString operation1 = delegate(string s) { return s; };    // Anonymous method
            MapString operation2 = (string s) => { return s; };         // Lambda expression (explicitly typed parameter)
            MapString operation3 = (s) => { return s; };                // Lambda expression (implicitly typed parameter)
            MapString operation4 = s => { return s; };                  // Lambda expression (implicitly typed parameter)
            MapString operation5 = s => s;                              // Lambda expression (implicitly typed parameter)

            var str = "SomeString";
            Console.WriteLine($"operation1(str) = {operation1(str)}");
            Console.WriteLine($"operation2(str) = {operation2(str)}");
            Console.WriteLine($"operation3(str) = {operation3(str)}");
            Console.WriteLine($"operation4(str) = {operation4(str)}");
            Console.WriteLine($"operation5(str) = {operation5(str)}");
        }
    }
}