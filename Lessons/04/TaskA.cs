using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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
            ValidInnerExcpetion();

            NonEmptyDataDictionary();
        }

        private static void NonEmptyDataDictionary()
        {
            IDictionary<int, string> numbers =
                new Dictionary<int, string>
                {
                    { 1, "one" },
                    { 2, "two" },
                    { 3, "three" },
                    { 4, "four" }
                };

            try
            {
                try
                {
                    Console.WriteLine(numbers[5]);
                }
                catch (Exception inner)
                {
                    Console.WriteLine(numbers[6]);
                }
            }
            catch (Exception ex)
            {
                PrintExceptionDetails(ex);
            }

        }

        public static void ValidInnerExcpetion()
        {
            int[] numbers = new[] { 1, 2, 3, 4, 5 };

            try
            {
                try
                {
                    Console.WriteLine(numbers[-1]);
                }
                catch (Exception inner)
                {
                    try
                    {
                        var openLog = File.Open("DoesNotExist", FileMode.Open);
                    }
                    catch
                    {
                        throw new FileNotFoundException("OutterException", inner);
                    }
                }

            }
            catch (Exception ex)
            {
                PrintExceptionDetails(ex);
            }
        }

        private static void PrintExceptionDetails(Exception exception)
        {
            IList<PropertyInfo> properties = new List<PropertyInfo>(exception.GetType().GetProperties());

            foreach (var property in properties)
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(exception)}");
            }
        }
    }
}
