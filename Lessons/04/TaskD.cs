using System;

namespace Lessons._04
{
    /// <summary>
    /// Create your own custom exception.
    /// Use it in a reasonable context and simulate throwing and catching.
    /// </summary>
    public class TaskD
    {
        public static void Run()
        {
            decimal number = 2;
            
            try
            {
                PrintOddNumber(number);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void PrintOddNumber(decimal number)
        {
            if (number % 2 == 0)
            {
                throw new EvenNumberException();
            }
            
            Console.WriteLine($"Odd number you entered: {number}");
        }
    }

    public class EvenNumberException : Exception { }
}