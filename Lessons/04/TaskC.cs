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
                int y = 10 - 10;

                decimal x = CalculateSpeedOfLight(5, y);
            }
            catch(DivideByZeroException exception)
            {
                Console.WriteLine("Black magic is forbidden.");

                //Does not reset the stacktrace
                //throw;

                //Resets the stacktrace
                throw exception;
            }
        }

        private static decimal CalculateSpeedOfLight(int x, int y)
        {
            return x / CalculateSpeed(y);
        }

        private static decimal CalculateSpeed(int s)
        {
            return s*2;
        }
    }
}