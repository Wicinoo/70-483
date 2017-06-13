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
                throw new Exception("Exception with inner exception", new Exception("Inner Exception"));
            }
            catch (Exception e)
            {
                PrintExceptionDetails(e);
            }

            try
            {
                var dic = new Dictionary<int, int>();
                dic[0] = 1;
                dic.Add(0, 2);
            }
            catch (Exception e)
            {
                PrintExceptionDetails(e);
            }
        }

        private static void PrintExceptionDetails(Exception exception)
        {

            foreach (var prop in exception.GetType().GetProperties())
            {
                Console.WriteLine($"{prop.Name}: {prop.GetValue(exception, null)}");
            }
        }
    }
}
