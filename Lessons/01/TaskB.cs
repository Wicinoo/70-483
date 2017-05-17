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
            MapString operation1 = delegate(string @string) { return @string; };
            Console.WriteLine($"Operation1(stringToMap): {operation1("stringToMap")}");

            MapString operation2 = (string @string) => { return @string; };
            Console.WriteLine($"Operation2(stringToMap): {operation2("stringToMap")}");

            MapString operation3 = (@string) => { return @string; };
            Console.WriteLine($"Operation3(stringToMap): {operation3("stringToMap")}");

            MapString operation4 = @string => { return @string; };
            Console.WriteLine($"Operation4(stringToMap): {operation4("stringToMap")}");

            MapString operation5 = @string => @string;
            Console.WriteLine($"Operation5(stringToMap): {operation5("stringToMap")}");
        }
    }
}