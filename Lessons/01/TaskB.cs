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
            MapString PossibleForm1 = delegate(string a)    { return a + "b"; };   // Anonymous method
            MapString PossibleForm2 = (string a) => { return a + "b"; };   // Lambda expression (explicitly typed parameter)
            MapString PossibleForm3 = (a) => { return a + "b"; };   // Lambda expression (implicitly typed parameter)
            MapString PossibleForm4 = a => { return a + "b"; };   // Lambda expression (implicitly typed parameter)
            MapString PossibleForm5 = a => a + "b";   // Lambda expression (implicitly typed parameter)

            Console.WriteLine($"PossibleForm1(\"a\") = {PossibleForm1("a")}");
            Console.WriteLine($"PossibleForm2(\"a\") = {PossibleForm2("a")}");
            Console.WriteLine($"PossibleForm3(\"a\") = {PossibleForm3("a")}");
            Console.WriteLine($"PossibleForm4(\"a\") = {PossibleForm4("a")}");
            Console.WriteLine($"PossibleForm5(\"a\") = {PossibleForm5("a")}");
        }
    }
}
