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
            MapString FirstOperation = delegate(string @string) { return @string; };
            MapString SecondOperation = (string @string) => { return @string; };
            MapString ThirdOperation = (@string) => { return @string; };
            MapString FourthOperation = @string => { return @string; };
            MapString FifthOperation = @string => @string;

            Console.WriteLine(FirstOperation("Hello, world!"));
            Console.WriteLine(SecondOperation("Hello, world!"));
            Console.WriteLine(ThirdOperation("Hello, world!"));
            Console.WriteLine(FourthOperation("Hello, world!"));
            Console.WriteLine(FifthOperation("Hello, world!"));
        }
    }
}