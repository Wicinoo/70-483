using System;

namespace Lessons._01
{
    public static class _03_LambdaExpressionBasics
    {
        delegate int UnaryOperation(int argument);

        public static void Run()
        {
            // All right-side forms are equivalent.
            UnaryOperation operation1 = delegate(int x)    { return x + 1; };   // Anonymous method
            UnaryOperation operation2 =         (int x) => { return x + 1; };   // Lambda expression (explicitly typed parameter)
            UnaryOperation operation3 =             (x) => { return x + 1; };   // Lambda expression (implicitly typed parameter)
            UnaryOperation operation4 =              x  => { return x + 1; };   // Lambda expression (implicitly typed parameter)
            UnaryOperation operation5 =              x  =>          x + 1   ;   // Lambda expression (implicitly typed parameter)

            Console.WriteLine($"operation1(1) = {operation1(1)}");
            Console.WriteLine($"operation2(1) = {operation2(1)}");
            Console.WriteLine($"operation3(1) = {operation3(1)}");
            Console.WriteLine($"operation4(1) = {operation4(1)}");
            Console.WriteLine($"operation5(1) = {operation5(1)}");
        }
    }
}