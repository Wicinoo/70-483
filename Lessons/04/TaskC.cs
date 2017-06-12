using System;
using System.Runtime.ExceptionServices;

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
                Int32.Parse("NaN");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Stack trace of exception in variable");
                Console.WriteLine(exception.StackTrace);
                var originalException = ExceptionDispatchInfo.Capture(exception);
                Console.WriteLine("");
                Console.WriteLine("Stack trace of original exception from ExceptionDispatchInfo");
                originalException.Throw();
            }
        }
    }
}