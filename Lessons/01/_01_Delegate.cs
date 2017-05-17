using System;

namespace Lessons._01
{
    public delegate int BinaryOperation(int x, int y);

    public static class _01_Delegate
    {
        public static void Run()
        {
            BinaryOperation addition = Addition;
            Console.WriteLine("Addition(4,5): {0}", addition(4, 5));

            BinaryOperation multiplication = Multiplication;
            Console.WriteLine("Multiplication(4,5): {0}", multiplication(4, 5));
        }

        public static int Addition(int a, int b)
        {
            return a + b;
        }

        public static int Multiplication(int a, int b)
        {
            return a * b;
        }
    }
}