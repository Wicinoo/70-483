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
            PrintExceptionDetails(new Exception("Some message"));

            try
            {
                ThrowSomeException();
            }
            catch (Exception ex)
            {
                PrintExceptionDetails(ex);
            }

            
        }

        private static void ThrowSomeException()
        {
            NullReferenceException nre = new NullReferenceException("Entity not found.", new FormatException("Cannot parse postcode."));
            nre.Data.Add("PostCode", "ca2xx");
            nre.Data.Add("CountryCode", "UK");
            throw nre;
        }

        public static void PrintExceptionDetails(Exception exception)
        {
            Console.WriteLine();
            Console.WriteLine($"Exception type: {exception.GetType().Name}");

            Console.Write(nameof(exception.Message));
            Console.Write(": ");
            Console.WriteLine(exception.Message);

            Console.Write(nameof(exception.Source));
            Console.Write(": ");
            Console.WriteLine(exception.Source);

            Console.Write(nameof(exception.TargetSite));
            Console.Write(": ");
            Console.WriteLine(exception.TargetSite);

            Console.Write(nameof(exception.HelpLink));
            Console.Write(": ");
            Console.WriteLine(exception.HelpLink);

            Console.Write(nameof(exception.StackTrace));
            Console.Write(": ");
            Console.WriteLine(exception.StackTrace);

            Console.Write(nameof(exception.InnerException));
            Console.Write(": ");
            Console.WriteLine(exception.InnerException);

            Console.Write(nameof(exception.Data));
            Console.Write(":");
            foreach (var key in exception.Data.Keys)
            {
                Console.Write($" {key}/{exception.Data[key]}");
            }
            Console.WriteLine();
        }
    }
}
