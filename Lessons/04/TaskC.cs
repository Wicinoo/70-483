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
            Console.WriteLine("TaskC: throw; (full stack)");
            Console.WriteLine("=============");
            try
            {
                try
                {
                    int.Parse("NaN");
                }
                catch (FormatException exception)
                {
                    Console.WriteLine("An FormatException was caught.");
                    throw;
                }
            }
            catch (Exception exception)
            {
                TaskA.PrintExceptionDetails(exception);
            }

            Console.WriteLine();

            Console.WriteLine("TaskC: throw exception; (new object, previous stacktrace empty)");
            Console.WriteLine("=======================");
            try
            {
                try
                {
                    int.Parse("NaN");
                }
                catch (FormatException exception)
                {
                    Console.WriteLine("An FormatException was caught.");
                    throw exception;
                }
            }
            catch (Exception exception)
            {
                TaskA.PrintExceptionDetails(exception);
            }
        }
    }
}