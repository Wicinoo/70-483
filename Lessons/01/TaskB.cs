using System;

namespace Lessons._01
{
    /// <summary>
    /// Define a delegate "string MapString(string @string)" and write all possible forms according to _03_LambdaExpressionBasics.
    /// Print results from each expression.
    /// </summary>
    public class TaskB
    {
        public static void Run()
        {
            MapString op1 = s => "op1: " + s;
            MapString op2 = s => { return "op2: " + s; };
            MapString op3 = (s) => "op3: " + s;
            MapString op4 = (string s) => "op4: " + s;
            MapString op5 = (s) => { return "op5: " + s; };
            MapString op6 = (string s) => { return "op6: " + s; };
            MapString op7 = delegate(string s) { return "op7: " + s; };


            Console.WriteLine("TaskB:");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(op1("Completed!"));
            Console.WriteLine(op2("Completed!"));
            Console.WriteLine(op3("Completed!"));
            Console.WriteLine(op4("Completed!"));
            Console.WriteLine(op5("Completed!"));
            Console.WriteLine(op6("Completed!"));
            Console.WriteLine(op7("Completed!"));
            Console.WriteLine("---------------------------------------");
        }
    }

    delegate string MapString(string @string);
}
