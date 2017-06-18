using System;
using System.Linq;
using System.Runtime.InteropServices;

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
            PrintExceptionDetails(new ArgumentNullException());
        }

        private static void PrintExceptionDetails(Exception exception)
        {
            var properties = exception.GetType().GetProperties().ToList();

            properties.ForEach(prop => Console.WriteLine($"{prop.Name}: {prop.GetValue(exception, null)}"));
        }
    }
}
