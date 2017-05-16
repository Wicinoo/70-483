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
            MapString operation1 = delegate (string x) { return x; };   // Anonymous method
            MapString operation2 = (string x) => { return x; };   // Lambda expression (explicitly typed parameter)
            MapString operation3 = (x) => { return x; };   // Lambda expression (implicitly typed parameter)
            MapString operation4 = x => { return x; };   // Lambda expression (implicitly typed parameter)
            MapString operation5 = x => x;   // Lambda expression (implicitly typed parameter)

            string input = "None shall pass";
            Console.WriteLine($"operation1({input}) = {operation1(input)}");

            input = "I move, for no man.";
            Console.WriteLine($"operation2({input}) = {operation2(input)}");

            input = "It's just a flesh wound!";
            Console.WriteLine($"operation3({input}) = {operation3(input)}");

            input = "Running away, eh? You yellow bastards!";
            Console.WriteLine($"operation4({input}) = {operation4(input)}");

            input = "Come back here and take what's coming to ya! I'll bite your legs off!";
            Console.WriteLine($"operation5({input}) = {operation5(input)}");
        }
    }
}