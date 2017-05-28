using System;

namespace Lessons._01
{
    /// <summary>
    /// Define a delegate "string MapString(string @string)" and write all possible forms according to _03_LambdaExpressionBasics.
    /// Print results from each expression.
    /// </summary>
    public class TaskB
    {
        public delegate string MapString(string @string);

        public static void Run()
        {
            MapString mapper1 = delegate (string input) { return input; };   // Anonymous method
            MapString mapper2 = (string input) => { return input; };   // Lambda expression (explicitly typed parameter)
            MapString mapper3 = (input) => { return input; };   // Lambda expression (implicitly typed parameter)
            MapString mapper4 = input => { return input; };   // Lambda expression (implicitly typed parameter)
            MapString mapper5 = input => input;   // Lambda expression (implicitly typed parameter)

            Console.WriteLine($"mapper1(Hello) = {mapper1("Hello")}");
            Console.WriteLine($"mapper2(Hello) = {mapper2("Hello")}");
            Console.WriteLine($"mapper3(Hello) = {mapper3("Hello")}");
            Console.WriteLine($"mapper4(Hello) = {mapper4("Hello")}");
            Console.WriteLine($"mapper5(Hello) = {mapper5("Hello")}");
        }
    }
}