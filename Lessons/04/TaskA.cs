using System;
using System.Collections.Generic;

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
                RunWithInnerException();
            }
            catch (Exception exception)
            {
                PrintExceptionDetails(exception);
            }

            try
            {
                RunWithData();
            }
            catch (Exception exception)
            {

                PrintExceptionDetails(exception);
            }

        }

        private static void RunWithInnerException()
        {
            try
            {
                var dictionary = new Dictionary<int, string>()[1];
            }
            catch (Exception exception)
            {
                throw new Exception("Failed to read from dictionary", exception);
            }
        }

        private static void RunWithData()
        {
            try
            {
                var queue = new Queue<string>().Peek();
            }
            catch (Exception exception)
            {
                exception.Data.Add("Failed to read from queue", exception);
                throw;
            }
        }

        private static void PrintExceptionDetails(Exception exception)
        {
            foreach (var prop in exception.GetType().GetProperties())
            {
                Console.WriteLine($"{prop.Name}: {prop.GetValue(exception)}");
            }
        }
    }
}
