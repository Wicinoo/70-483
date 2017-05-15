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
            MapString operation1 = delegate(string foo) { return foo + " Field"; }; // Anonymous method
            MapString operation2 = (string foo) => { return foo + " Field"; };   // Lambda expression (explicitly typed parameter)
            MapString operation3 = (foo) => { return foo + " Field"; }; // Lambda expression (implicitly typed parameter)
            MapString operation4 = foo => { return foo + " Field"; }; // Lambda expression (implicitly typed parameter)
            MapString operation5 = foo => foo + " Field"; // Lambda expression (implicitly typed parameter)

            Console.WriteLine($"operation1(Steve) = {operation1("Steve")}");
            Console.WriteLine($"operation2(Steve) = {operation2("Steve")}");
            Console.WriteLine($"operation3(Steve) = {operation3("Steve")}");
            Console.WriteLine($"operation4(Steve) = {operation4("Steve")}");
            Console.WriteLine($"operation5(Steve) = {operation5("Steve")}");
        }
    }
}