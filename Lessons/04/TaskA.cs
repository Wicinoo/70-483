using System;
using System.Collections.Generic;
using Xunit.Sdk;

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
                throw new Exception("Bla");
            }
            catch (Exception ex)
            {
                PrintExceptionDetails(ex);
            }

            try
            {
                DictionaryException();
            }
            catch (Exception ex)
            {
                PrintExceptionDetails(ex);
            }
        }


        private static void DictionaryException()
        {
            var customDict = new Dictionary<string, string>();

            try
            {
                string res = customDict["aa"];
            }
            catch (Exception ex)
            {
                throw new Exception("Dictionary exception", ex);
            }
        }

        private static void PrintExceptionDetails(Exception exception)
        {
            foreach (var prop in exception.GetType().GetProperties())
            {
                Console.WriteLine("{0} : {1}", prop.Name, prop.GetValue(exception));
            }
        }
    }
}
