using System;
using System.Collections;

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
            try
            {
                var nre = new NullReferenceException();
                var argNullEx = new ArgumentNullException("Exception message", nre);
                argNullEx.Data["Foo"] = "Bar";
                throw argNullEx;
            }
            catch (ArgumentNullException ex)
            {
                PrintExceptionDetails(ex);
            }

        }

        private static void PrintExceptionDetails(Exception exception)
        {
            foreach (var propertyInfo in exception.GetType().GetProperties())
            {
                Console.WriteLine($"[{propertyInfo.Name}]: [{propertyInfo.GetValue(exception, null)}]");
            }
            foreach (DictionaryEntry data in exception.Data)
            {
                Console.WriteLine($"{data.Key} : {data.Value}");
            }
        }
    }
}
