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
            MapString form1 = delegate  (string x) { return x; };
            MapString form2 =           (string x) => { return x; };
            MapString form3 =           (x) => { return x; };
            MapString form4 =           x => { return x; };
            MapString form5 =           x =>  x;

            Console.WriteLine(form1("abc"));
            Console.WriteLine(form2("abc"));
            Console.WriteLine(form3("abc"));
            Console.WriteLine(form4("abc"));
            Console.WriteLine(form5("abc"));
        }


        private delegate string MapString(string @string);
    }
}