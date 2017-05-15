using System;

namespace Lessons._01
{
    /// <summary>
    /// Define a delegate "string MapString(string @string)" and write all possible forms according to _03_LambdaExpressionBasics.
    /// Print results from each expression.
    /// </summary>
    public class TaskB
    {
        public delegate string MapString(string s);

        public static void Run()
        {
            MapString map1 = delegate(string s) { return s.ToUpper(); };
            MapString map2 = (string s) => { return s.ToUpper(); };
            MapString map3 = (s) => { return s.ToUpper(); };
            MapString map4 = s => { return s.ToUpper(); };
            MapString map5 = s => s.ToUpper();

            Console.WriteLine($"map1(HelloWorld) = {map1("Hello World")}");
            Console.WriteLine($"map2(HelloWorld) = {map2("Hello World")}");
            Console.WriteLine($"map3(HelloWorld) = {map3("Hello World")}");
            Console.WriteLine($"map4(HelloWorld) = {map4("Hello World")}");
            Console.WriteLine($"map5(HelloWorld) = {map5("Hello World")}");
        }
    }
}