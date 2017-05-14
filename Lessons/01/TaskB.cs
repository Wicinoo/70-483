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
            MapString operation1 = delegate (string @string) { return @string; };

            MapString operation2 = (string @string) => { return @string; };

            MapString operation3 = (@string) => { return @string; };

            MapString operation4 = @string => { return @string; };

            MapString operation5 = @string => @string;

            Console.WriteLine($"operation1(1) = {operation1("stringToMap")}");
            Console.WriteLine($"operation2(1) = {operation2("stringToMap")}");
            Console.WriteLine($"operation3(1) = {operation3("stringToMap")}");
            Console.WriteLine($"operation4(1) = {operation4("stringToMap")}");
            Console.WriteLine($"operation5(1) = {operation5("stringToMap")}");
        }
    }
}