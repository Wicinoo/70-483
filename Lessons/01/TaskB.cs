using System;
using System.Linq;

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
            MapString op1 = delegate(string s)    { return s.ToUpper(); };
            MapString op2 =         (string s) => { return s.ToUpper(); };
            MapString op3 =                (s) => { return s.ToUpper(); };
            MapString op4 =                 s  => { return s.ToUpper(); };
            MapString op5 =                 s  =>          s.ToUpper();

            Console.WriteLine($"operation1(1) = {op1("foobar")}");
            Console.WriteLine($"operation2(1) = {op1("foobar")}");
            Console.WriteLine($"operation3(1) = {op1("foobar")}");
            Console.WriteLine($"operation4(1) = {op1("foobar")}");
            Console.WriteLine($"operation5(1) = {op1("foobar")}");
        }
    }
}