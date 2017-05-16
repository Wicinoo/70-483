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
            // All right-side forms are equivalent.
            MapString operation1 = delegate (string x) { return x; };   // Anonymous method
            MapString operation2 = (string x) => { return x; };   // Lambda expression (explicitly typed parameter)
            MapString operation3 = (x) => { return x; };   // Lambda expression (implicitly typed parameter)
            MapString operation4 = x => { return x; };   // Lambda expression (implicitly typed parameter)
            MapString operation5 = x => x;   // Lambda expression (implicitly typed parameter)

            Console.WriteLine($"operation1(MapString) = {operation1("MapString")}");
            Console.WriteLine($"operation2(MapString) = {operation2("MapString")}");
            Console.WriteLine($"operation3(MapString) = {operation3("MapString")}");
            Console.WriteLine($"operation4(MapString) = {operation4("MapString")}");
            Console.WriteLine($"operation5(MapString) = {operation5("MapString")}");
        }
    }
}