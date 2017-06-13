using System;

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
            TaskA ex = new TaskA();

            try
            {
                ex.CatchInner();
            }
            catch (Exception e)
            {
                PrintExceptionDetails(e);
            }
        }

        public void ThrowInner()
        {
            throw new Exception("Exception in ThrowInner method.");
        }

        public void CatchInner()
        {
            try
            {
                this.ThrowInner();
            }
            catch (Exception e)
            {
                throw new Exception("Error in CatchInner caused by calling the ThrowInner method.", e);
            }
        }

        private static void PrintExceptionDetails(Exception exception)
        {
            Console.WriteLine($"[Message]: [{exception.Message}]");
            Console.WriteLine($"[Data]: [{exception.Data}]");
            Console.WriteLine($"[InnerException]: [{exception.InnerException}]");
            Console.WriteLine($"[HResult]: [{exception.HResult}]");
            Console.WriteLine($"[Source]: [{exception.Source}]");
            Console.WriteLine($"[TargetSite]: [{exception.TargetSite}]");
            Console.WriteLine($"[HelpLink]: [{exception.HelpLink}]");
            Console.WriteLine($"[StackTrace]: [{exception.StackTrace}]");
        }


    }
}
