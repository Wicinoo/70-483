using System;

namespace Lessons._04
{
    /// <summary>
    /// Write a code that demonstrates differences between 
    /// "throw;" and "throw exception;" in catch block.
    /// </summary>
    public class TaskC
    {
        public static void Run()
        {
            try
            {
                int number = 0;

                decimal result = Divide(1, number);
            }
            catch (DivideByZeroException exception)
            {
                Console.WriteLine("You don't divide by zero");

                //Doesn't reset the stacktrace
                //throw;

                //Resets the stacktrace
                throw exception;
            }
        }

        private static decimal Divide(int x, int y)
        {
            return (decimal)x / y;
        }
    }
}