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
                int.Parse("NaN");
            }
            catch (FormatException exception)
            {
                Console.WriteLine("An FormatException was caught.");

                //w/o changes on callstack
                //throw;

                //change callstack
                throw exception;
            }
        }
    }
}