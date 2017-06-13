using System;
using System.Linq;

namespace Lessons._04
{
    /// <summary>
    /// Write a method to print a structured listing of all properties of an exception. 
    /// Keep format [property_name]: [value]\n.
    /// Let your code throw an exception, handle it and use the method for printing.
    /// Simulate a situation with valid InnerException.
    /// Simulate a situation with non-empty Data dictionary.
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            var taskA = new TaskA();

            try
            {
                var toNeverBePopulated = int.Parse("YouShallNotParseThisEver");
            }
            catch(Exception e)
            {
                e.Data.Add("customData", "custom exception info");
                taskA.PrintExceptionDetails(e);
            }
        }

        private void PrintExceptionDetails(Exception exception)
        {
            Console.WriteLine("[Data]: [{0}]", exception.Data);
            Console.WriteLine("[HResult]: [{0}]", exception.HResult);
            Console.WriteLine("[HelpLink]: [{0}]", exception.HelpLink);
            Console.WriteLine("[InnerException]: [{0}]", exception.InnerException);
            Console.WriteLine("[Message]: [{0}]", exception.Message);
            Console.WriteLine("[Source]: [{0}]", exception.Source);
            Console.WriteLine("[StackTrace]: [{0}]", exception.StackTrace);
            Console.WriteLine("[TargetSite]: [{0}]", exception.TargetSite);
        }
    }
}
