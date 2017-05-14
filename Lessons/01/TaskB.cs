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
            //MapString operation1 = delegate (string s)      { return s; };   // Anonymous method
            //MapString operation2 =          (string s) =>   { return s; };   // Lambda expression (explicitly typed parameter)
            //MapString operation3 =                 (s) =>   { return s; };   // Lambda expression (implicitly typed parameter)
            //MapString operation4 =                  s  =>   { return s; };   // Lambda expression (implicitly typed parameter)
            //MapString operation5 =                  s  =>            s;      // Lambda expression (implicitly typed parameter)

            MapString operation1 = delegate (string s) { return s; };   // Anonymous method
            MapString operation2 = (string s) => { return s; };   // Lambda expression (explicitly typed parameter)
            MapString operation3 = (s) => { return s; };   // Lambda expression (implicitly typed parameter)
            MapString operation4 = s => { return s; };   // Lambda expression (implicitly typed parameter)
            MapString operation5 = s => s;      // Lambda expression (implicitly typed parameter)

            Console.WriteLine($"operation1(foo) = {operation1("foo")}");
            Console.WriteLine($"operation2(foo) = {operation2("foo")}");
            Console.WriteLine($"operation3(foo) = {operation3("foo")}");
            Console.WriteLine($"operation4(foo) = {operation4("foo")}");
            Console.WriteLine($"operation5(foo) = {operation5("foo")}");
        }
    }
}